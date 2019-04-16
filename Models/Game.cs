
namespace FinalProject.Models
{
    public class Game
    {
        public string id;
        public int pongX = 400, pongY = 400;
        public Paddle[] paddle = new Paddle[3];

        public Game() {
            paddle[1] = new Paddle();
            paddle[2] = new Paddle();
        }

        public void calculate()
        {
            if(paddle[1].occupied == "" || paddle[2].occupied == "") return;
            pongX += Constants.pongVx;
            pongY += Constants.pongVy;
            if (pongY <= Constants.pongSize / 2 + 1 || Constants.pongVx >= Constants.mapWidth - (Constants.pongSize / 2 + 1))
            {
                Constants.pongVx *= -1;
            }

            if (pongY > Constants.upperPaddle -5 && pongY < Constants.upperPaddle + Constants.pongSize / 2 + 1)
            {
                if (paddle[1].gotThis(pongX))
                {
                    Constants.pongVy *= -1;
                }
            }

            if (pongY > Constants.lowerPaddle - (Constants.pongSize / 2 + 1) && pongY < Constants.lowerPaddle + 5)
            {
                if (paddle[2].gotThis(pongX))
                {
                    Constants.pongVy *= -1;
                }
            }
        }

    }

}