//Lobby
class GameScene extends Phaser.Scene {

    constructor() {
        super('GameScene');
    }

    preload() {
        let src = '../assets/kitchen/';
        this.load.image('background', src + 'background.png');
        this.load.image('ball', src + 'ball.png');
        this.load.image('bar', src + 'bar.png');
    }

    create() {
        let bg = this.add.image(Constant.MAP_WIDTH / 2, Constant.MAP_HEIGHT / 2, 'background');
        bg.setDisplaySize(Constant.MAP_WIDTH, Constant.MAP_HEIGHT);
        this.ball = this.add.image(300, 300, 'ball');
        this.ball.setDisplaySize(
            Constant.ORIGNAL_BALL_RADIUS * Constant.MAP_WIDTH / Constant.ORIGINAL_WIDTH,
            Constant.ORIGNAL_BALL_RADIUS * Constant.MAP_HEIGHT / Constant.ORIGINAL_HEIGHT);
        this.oppBar = this.add.image(300, 700, 'bar');
        this.oppBar.setDisplaySize(
            Constant.ORIGINAL_PAD_WIDTH * Constant.MAP_WIDTH / Constant.ORIGINAL_WIDTH, 
            Constant.ORIGINAL_PAD_HEIGHT * Constant.MAP_HEIGHT / Constant.ORIGINAL_HEIGHT);
        this.userBar = this.add.image(600, 70, 'bar');
        this.userBar.setDisplaySize(
            Constant.ORIGINAL_PAD_WIDTH * Constant.MAP_WIDTH / Constant.ORIGINAL_WIDTH, 
            Constant.ORIGINAL_PAD_HEIGHT * Constant.MAP_HEIGHT / Constant.ORIGINAL_HEIGHT);
    }

    updateLocation(game) {
        this.ball.setPosition(
            game.pongX * Constant.MAP_WIDTH / Constant.ORIGINAL_WIDTH, 
            game.pongY * Constant.MAP_HEIGHT / Constant.ORIGINAL_HEIGHT);
        this.oppBar.setPosition(
            game.paddle[1].x * Constant.MAP_WIDTH / Constant.ORIGINAL_WIDTH, 
            game.paddle[1].y * Constant.MAP_HEIGHT / Constant.ORIGINAL_HEIGHT);
        this.userBar.setPosition(
            game.paddle[2].x * Constant.MAP_WIDTH / Constant.ORIGINAL_WIDTH, 
            game.paddle[2].y * Constant.MAP_HEIGHT / Constant.ORIGINAL_HEIGHT);
    }
}

// game.scene.scenes[0].ball.setPosition(100, 100)