let config = {
    type: Phaser.AUTO,
    width: INFO.MAP_WIDTH,
    height: INFO.MAP_HEIGHT,
    parent: 'container',
    scene: [WaitingScene, GameScene]
};

let game = new Phaser.Game(config);