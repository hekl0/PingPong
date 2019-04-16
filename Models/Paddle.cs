namespace FinalProject.Models {
    public class Paddle {

        public int x = 240;
        public int y;
        public string occupied = "";


        public Paddle (int up) {
            if (up == 1) y = Constants.lowerPaddle;
            else y = Constants.upperPaddle;
        }

        public bool gotThis (int pos) {
            if (pos <= x + Constants.paddleSize/2 + 1 && pos >= x - Constants.paddleSize/2 - 1) return true;
            else return false;
        }

    }
}