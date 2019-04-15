namespace FinalProject.Models
{
    public class Paddle
    {
        public int x = 200;


        public bool gotThis(int pos)
        {
            if (pos <= x + Constants.paddleSize && pos >= x) return true;
            else return false;
        }

    }
}