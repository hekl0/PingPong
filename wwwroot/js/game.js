Constant.MAP_HEIGHT = window.innerHeight;
Constant.MAP_WIDTH = window.innerWidth / 1.8;

let config = {
    type: Phaser.AUTO,
    width: Constant.MAP_WIDTH,
    height: Constant.MAP_HEIGHT,
    parent: 'container',
    scene: [GameScene]
};

let game = new Phaser.Game(config);