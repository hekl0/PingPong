using System;

namespace FinalProject.Models {
    public class Game {
        public int numplayer, time;
        public int winner;
        public string id;
        public Pong pong;
        public Paddle[] paddle = new Paddle[3];
        public bool inGame, gameOver;

        public Game () {
            numplayer = 0;
            inGame = false;
            gameOver = false;
            reset();
        }

        public void calculate () {
            pong.move();

            if (pong.y > Constants.mapHeight || pong.y < 0) {
                gameOver = true;
                if(pong.y > Constants.mapHeight) winner = 2;
                else winner = 1;
            }

            if (pong.x - pong.width <= 0 || pong.x + pong.width >= Constants.mapWidth) {
                pong.vx *= -1;
            }

            //check collision with paddles
            if (paddle[1].checkCollision(pong) || paddle[2].checkCollision(pong))
                pong.vy *= -1;
        }

        public void reset () {
            paddle[1] = new Paddle(Constants.mapWidth / 2, Constants.mapHeight - 50);
            paddle[2] = new Paddle(Constants.mapWidth / 2, 50);
            pong = new Pong(Constants.mapWidth / 2, Constants.mapHeight / 2);
            time = 0;
        }

    }

}