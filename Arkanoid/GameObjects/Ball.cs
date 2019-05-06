﻿using System;
using System.Windows;
using System.Windows.Media.Media3D;

namespace Arkanoid.GameObjects
{
    class Ball : MovingGameObject {

        private static double DEFAULT_SPEED = 10;
        private Random rand;
        public static Point3D DEFAULT_SIZE = new Point3D(7, 7, 7);
        public bool isSticked;
        public Ball(Point3D size, Point position) : base(size, position)
        {
            init();
        }

        public Ball(Point position) : base(DEFAULT_SIZE, position)
        {
            init();
        }

        private void randomizeDirection(){
            int randDir = rand.Next(0, 2);
            if (randDir % 2 == 0)
                movement.right = true;
            else
                movement.left = true;
        }

        private void init()
        {
            rand = new Random();
           
            speed = DEFAULT_SPEED;
            isSticked = true;

            movement.down = false;
            movement.up = false;
            movement.left = false;
            movement.right = false;
        }

        public override Model3DGroup draw() {
            return null;
        }

        public override void reactToCollision(Collision collision) {
            switch (collision){
                case Collision.LEFT: updateXaxisMovement(false, true); break;
                case Collision.RIGHT: updateXaxisMovement(true, false); break;
                case Collision.UP: updateYaxisMovement(false, true); break;
                case Collision.DOWN: updateYaxisMovement(true, false); break;
            }

        }

        public void throwBall() {
            isSticked = false;
            speed = DEFAULT_SPEED;
            randomizeDirection();
            updateYaxisMovement(true, false);
        }

        public override void update(double delta)
        {
            if (isSticked)
                speed = Player.DEFAULT_SPEED;
           
            base.update(delta);
        }
    }
}
