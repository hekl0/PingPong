namespace FinalProject.Models
{
    public class Paddle
    {
        public int x;

        public bool gotThis(int x)
        {
            if (x <= x + Constants.paddleSize && x >= x) return true;
            else return false;
        }

    }
}