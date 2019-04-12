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

    updateLocation(ballLocation, oppBarLocation, userBarLocation) {
        this.ball.setPosition(
            ballLocation.x * Constant.MAP_WIDTH / Constant.ORIGINAL_WIDTH, 
            ballLocation.y * Constant.MAP_HEIGHT / Constant.ORIGINAL_HEIGHT);
        this.oppBar.setPosition(
            oppBarLocation.x * Constant.MAP_WIDTH / Constant.ORIGINAL_WIDTH, 
            oppBarLocation.y * Constant.MAP_HEIGHT / Constant.ORIGINAL_HEIGHT);
        this.userBar.setPosition(
            userBarLocation.x * Constant.MAP_WIDTH / Constant.ORIGINAL_WIDTH, 
            userBarLocation.y * Constant.MAP_HEIGHT / Constant.ORIGINAL_HEIGHT);
    }
}

// game.scene.scenes[0].ball.setPosition(100, 100)