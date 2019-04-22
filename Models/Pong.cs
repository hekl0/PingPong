using System;

namespace FinalProject.Models {
    public class Pong : Entity {
        public int vx, vy;
        public Pong (int x, int y) {
            this.x = x;
            this.y = y;
            this.width = Constants.pongRadius * 2;
            this.height = Constants.pongRadius * 2;
            
            this.vx = Constants.initialPongVx;
            this.vy = Constants.initialPongVy;
        }

        public void move() {
            x += vx;
            y += vy;
        }

        public void speedUp() {
            if (Math.Abs(vy) == 10) return;
            if (vy < 0) vy--;
            else vy++;
        }
    }
}