namespace FinalProject.Models {
    public abstract class Entity {

        public int x, y;
        public int width, height;
        public bool checkCollision(Entity otherObj) {
            if (x - width / 2 <= otherObj.x + otherObj.width / 2 && x + width / 2 >= otherObj.x - otherObj.width / 2
                && y - height / 2 <= otherObj.y + otherObj.height / 2 && y + height / 2 >= otherObj.y - otherObj.height / 2)
                    return true;
            return false;
        }
    }
}