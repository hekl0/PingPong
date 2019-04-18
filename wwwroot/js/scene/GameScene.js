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

        this.load.image('win', '../assets/end_game/win.png');
        this.load.image('lose', '../assets/end_game/lose.png');
        this.load.image('msg', '../assets/end_game/msg.png');
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
        if (this.ball == null) return;
        this.ball.setDepth(10);
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

    endGame(result) {
        let endMessage;
        switch (result) {
            case 1:
                endMessage = this.add.image(Constant.MAP_WIDTH / 2, Constant.MAP_HEIGHT / 2, 'win');
                break;
            case 2:
                endMessage = this.add.image(Constant.MAP_WIDTH / 2, Constant.MAP_HEIGHT / 2, 'lose');
                break;
        }

        if (endMessage != null) {
            endMessage.setScale(0.2, 0.2);
            endMessage.setPosition(Constant.MAP_WIDTH / 2, -100);

            this.tweens.add({
                targets: endMessage,
                x: Constant.MAP_WIDTH / 2,
                y: Constant.MAP_HEIGHT / 2,
                scaleX: 0.6,
                scaleY: 0.5,
                duration: 700,
                ease: 'Back.easeOut',
                onComplete: function() {
                    let instrucMessage = this.add.image(Constant.MAP_WIDTH / 2, Constant.MAP_HEIGHT / 2 + 100, 'msg');
                    instrucMessage.setScale(0.1, 0.1);
                    this.tweens.add({
                        targets: instrucMessage,
                        scaleX: 1,
                        scaleY: 1,
                        duration: 100
                    });
                }.bind(this)
            });
        }
    }

}

// game.scene.scenes[0].ball.setPosition(100, 100)