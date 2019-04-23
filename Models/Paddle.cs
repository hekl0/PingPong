namespace FinalProject.Models
{
    public class Paddle : Entity
    {
        public string occupied;
        public Paddle(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.width = Constants.paddleSize;
            this.height = Constants.paddleHeight;

            this.occupied = "";
        }
    }
}