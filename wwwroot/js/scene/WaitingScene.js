//Lobby
class WaitingScene extends Phaser.Scene {
    
    constructor() {
        super('WaitingScene');
    }

    preload() {
        let src = '../assets/kitchen/';
        this.load.image('background', src + 'background.png');
        this.load.image('ball', src + 'ball.png');
        this.load.image('bar', src + 'bar.png');
    }

    create() {
        this.add.image(INFO.MAP_WIDTH / 2, INFO.MAP_HEIGHT / 2, 'background');
        let image = this.add.image(300, 300, 'ball');
        image = this.add.image(300, 500, 'bar');
    }
}