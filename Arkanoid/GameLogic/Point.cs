
namespace Arkanoid.GameLogic
{
    struct Point
    {
        public double X;
        public double Y;
        public Point(double X, double Y): this() {
            this.X = X;
            this.Y = Y;
        }

        public bool equalTo(Point point){
            if (this.X == point.X && this.Y == point.Y)
                return true;
            return false;
        }

        public void copy (Point point){
            this.X = point.X;
            this.Y = point.Y;
        }
    };
}
