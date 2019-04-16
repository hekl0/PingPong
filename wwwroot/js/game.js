Constant.MAP_HEIGHT = window.innerHeight;
Constant.MAP_WIDTH = window.innerWidth / 1.8;

let playerIndex = 0;
let groupID = "test";
let gameEnd = false;
let config = {
    type: Phaser.AUTO,
    width: Constant.MAP_WIDTH,
    height: Constant.MAP_HEIGHT,
    parent: 'container',
    scene: [WaitingScene, GameScene]
};

let game = new Phaser.Game(config);

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/gameHub")
    .build();

connection.on("Test", function(msg) {
       console.log(msg);
});

connection.start().then(function () {
    console.log("connected");
    connection.invoke("AddToGroup", groupID);
});

async function start() {
    try {
        await connection.start();
        console.log("connected");
    } catch (err) {
        console.log(err);
        setTimeout(() => start(), 5000);
    }
};

connection.onclose(async () => {
    await start();
});

connection.on("StartGame", () => {
    game.scene.run("GameScene");
});

connection.on("ReceiveWinner", (winnerIndex) => {
    gameEnd = true;
    if (winnerIndex == playerIndex)
        game.scene.scenes[1].endGame(1);
    else
        game.scene.scenes[1].endGame(2);
});

connection.on("StartGame", () => {
    game.scene.run('GameScene');
});

connection.on("ReceiveIndex", (index) => {
    playerIndex = index;
    console.log(index);
});

connection.on("ReceiveData", (pong_game) => {
    console.log(pong_game);
    if (playerIndex == 2) {
        pong_game.pongX = Constant.ORIGINAL_WIDTH - pong_game.pongX;
        pong_game.pongY = Constant.ORIGINAL_HEIGHT - pong_game.pongY;
        pong_game.paddle[1].x = Constant.ORIGINAL_WIDTH - pong_game.paddle[1].x;
        pong_game.paddle[1].y = Constant.ORIGINAL_HEIGHT - pong_game.paddle[1].y;
        pong_game.paddle[2].x = Constant.ORIGINAL_WIDTH - pong_game.paddle[2].x;
        pong_game.paddle[2].y = Constant.ORIGINAL_HEIGHT - pong_game.paddle[2].y;
    }
    
    game.scene.scenes[1].updateLocation(pong_game);
});

let lastKey = 0;
document.addEventListener('keydown', function(event) {
    if(event.keyCode == 37 && lastKey == 0 && playerIndex != 0) {
        //lastKey = event.keyCode;
        console.log('Left was pressed');
        connection.invoke("movePaddle", playerIndex, (playerIndex == 1) ? -1 : 1, groupID);
    }
    else if(event.keyCode == 39 && lastKey == 0 && playerIndex != 0) {
        //lastKey = event.keyCode;
        console.log('Right was pressed');
        connection.invoke("movePaddle", playerIndex, (playerIndex == 1) ? 1 : -1, groupID);
    }
});

document.addEventListener('keyup', function(event) {
    if(event.keyCode == 37 || event.keyCode == 65) { //left arrow or a
        console.log('Left was released');
        lastKey = 0;
    }
    if(event.keyCode == 39 || event.keyCode == 68) { //right arrow or d invoke movePaddle(playerindex, direction(1 or -1));
        console.log('Right was released');
        lastKey = 0;
    }
    if (event.keyCode == 32 && gameEnd) { //space pressed
        game.scene.run('WaitingScene');
        connection.invoke("restartGame");
        gameEnd = false;
    }
});