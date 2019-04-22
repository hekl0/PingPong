
class WaitingScene extends Phaser.Scene {

    constructor() {
        super('WaitingScene');
    }

    preload() {
        let src = '../assets/' + theme + '/';
        console.log(theme);
        this.load.image('background', src + 'background.png');

        this.load.image('msg1', '../assets/waiting/msg.png');
    }

    create() {
        let bg = this.add.image(Constant.MAP_WIDTH / 2, Constant.MAP_HEIGHT / 2, 'background');
        bg.setDisplaySize(Constant.MAP_WIDTH, Constant.MAP_HEIGHT);
        this.add.image(Constant.MAP_WIDTH / 2, Constant.MAP_HEIGHT / 2, 'msg1');
    }
}