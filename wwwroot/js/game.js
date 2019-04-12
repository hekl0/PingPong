Constant.MAP_HEIGHT = window.innerHeight;
Constant.MAP_WIDTH = window.innerWidth / 1.8;

let playerIndex = 0;
let config = {
    type: Phaser.AUTO,
    width: Constant.MAP_WIDTH,
    height: Constant.MAP_HEIGHT,
    parent: 'container',
    scene: [GameScene]
};

let game = new Phaser.Game(config);

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/gameHub")
    .build();

connection.start().then(function () {
    console.log("connected");
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

connection.on("ReceiveIndex", (index) => {
    playerIndex = index;
    console.log(index);
});

connection.on("ReceiveData", () => {
});

let lastKey = 0;
document.addEventListener('keydown', function(event) {
    if(event.keyCode == 37 && lastKey == 0) {
        //lastKey = event.keyCode;
        console.log('Left was pressed');
        connection.invoke("movePaddle", 1, -1);
    }
    else if(event.keyCode == 39 && lastKey == 0) {
        //lastKey = event.keyCode;
        console.log('Right was pressed');
        connection.invoke("movePaddle", 1, 1);
    }
});

document.addEventListener('keyup', function(event) {
    if(event.keyCode == 37) { //left arrow
        console.log('Left was released');
        lastKey = 0;
    }
    else if(event.keyCode == 39) { //right arrow invoke movePaddle(playerindex, direction(1 or -1));
        console.log('Right was released');
        lastKey = 0;
    }
});