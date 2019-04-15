
namespace FinalProject.Models
{
    public class Pong
    {
        public int x = 400, y = 400;
        public Paddle[] p = new Paddle[3];

        public void calculate()
        {
            if (x <= Constants.pongSize / 2 + 1 || Constants.pongVx >= Constants.mapWidth - (Constants.pongSize / 2 + 1))
            {
                Constants.pongVx *= -1;
            }

            if (y > -5 && y < Constants.pongSize / 2 + 1)
            {
                if (p[1].gotThis(x))
                {
                    Constants.pongVy *= -1;
                }
            }

            if (y > Constants.mapHeight - (Constants.pongSize / 2 + 1) && y < Constants.mapHeight + 5)
            {
                if (p[2].gotThis(x))
                {
                    Constants.pongVy *= -1;
                }
            }
        }

    }

}