
namespace FinalProject.Models
{
    public class Pong
    {
        public string id;
        public int x = 400, y = 400;
        public Paddle[] paddle = new Paddle[3];

        public Pong() {
            paddle[1] = new Paddle();
            paddle[2] = new Paddle();
        }

        public void calculate()
        {
            if(paddle[1].occupied == "" || paddle[2].occupied == "") return;
            x += Constants.pongVx;
            y += Constants.pongVy;
            if (x <= Constants.pongSize / 2 + 1 || Constants.pongVx >= Constants.mapWidth - (Constants.pongSize / 2 + 1))
            {
                Constants.pongVx *= -1;
            }

            if (y > Constants.upperPaddle -5 && y < Constants.upperPaddle + Constants.pongSize / 2 + 1)
            {
                if (paddle[1].gotThis(x))
                {
                    Constants.pongVy *= -1;
                }
            }

            if (y > Constants.lowerPaddle - (Constants.pongSize / 2 + 1) && y < Constants.lowerPaddle + 5)
            {
                if (paddle[2].gotThis(x))
                {
                    Constants.pongVy *= -1;
                }
            }
        }

    }

}