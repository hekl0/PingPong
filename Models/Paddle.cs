namespace FinalProject.Models {
    public class Paddle {
        public int x = 200;
        public int y;
        public string occupied = "";

        public Paddle (int up) {
            if (up == 1) y = Constants.upperPaddle;
            else y = Constants.lowerPaddle;
        }

        public bool gotThis (int pos) {
            if (pos <= x + Constants.paddleSize && pos >= x) return true;
            else return false;
        }

    }
}