
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Arkanoid.GameLogic
{
    class GameDrawing
    {
        private Viewport3D viewport;
        public GameDrawing(Viewport3D viewport)
        {
            this.viewport = viewport;
        }

        public Point getsSize() {
            return new Point(viewport.Width, viewport.Height);
        }
        public void draw(Func<ModelVisual3D> drawGameObj) {

            viewport.Dispatcher.Invoke(new Action(() => {
                viewport.Children.Add(drawGameObj());
                }));
        }

        public void refresh(Action objShape){
            viewport.Dispatcher.Invoke(() => {
                objShape();
            });
        }

        public void removeShape(Func<ModelVisual3D> objShape) {
            viewport.Dispatcher.Invoke(() =>
            {
                viewport.Children.Remove(objShape());
            });
        }

        public static Model3DGroup CreateCubeModel(Point3D position, Point3D size, Color color)
        {
            Model3DGroup cube = new Model3DGroup();

            TriangleModel.color = color;
            Func<Point3D, Point3D, Point3D, Model3DGroup> CreateTriangleModel = TriangleModel.CreateTriangleModel;

            Point3D p0 = new Point3D(position.X - size.X / 2, position.Y - size.Y / 2, position.Z - size.Z / 2);
            Point3D p1 = new Point3D(position.X + size.X / 2, position.Y - size.Y / 2, position.Z - size.Z / 2);
            Point3D p2 = new Point3D(position.X + size.X / 2, position.Y - size.Y / 2, position.Z + size.Z / 2);
            Point3D p3 = new Point3D(position.X - size.X / 2, position.Y - size.Y / 2, position.Z + size.Z / 2);
            Point3D p4 = new Point3D(position.X - size.X / 2, position.Y + size.Y / 2, position.Z - size.Z / 2);
            Point3D p5 = new Point3D(position.X + size.X / 2, position.Y + size.Y / 2, position.Z - size.Z / 2);
            Point3D p6 = new Point3D(position.X + size.X / 2, position.Y + size.Y / 2, position.Z + size.Z / 2);
            Point3D p7 = new Point3D(position.X - size.X / 2, position.Y + size.Y / 2, position.Z + size.Z / 2);

            //front side triangles
            cube.Children.Add(CreateTriangleModel(p3, p2, p6));
            cube.Children.Add(CreateTriangleModel(p3, p6, p7));
            //right side triangles
            cube.Children.Add(CreateTriangleModel(p2, p1, p5));
            cube.Children.Add(CreateTriangleModel(p2, p5, p6));
            //back side triangles
            cube.Children.Add(CreateTriangleModel(p1, p0, p4));
            cube.Children.Add(CreateTriangleModel(p1, p4, p5));
            //left side triangles
            cube.Children.Add(CreateTriangleModel(p0, p3, p7));
            cube.Children.Add(CreateTriangleModel(p0, p7, p4));
            //top side triangles
            cube.Children.Add(CreateTriangleModel(p7, p6, p5));
            cube.Children.Add(CreateTriangleModel(p7, p5, p4));
            //bottom side triangles
            cube.Children.Add(CreateTriangleModel(p2, p3, p0));
            cube.Children.Add(CreateTriangleModel(p2, p0, p1));

            return cube;
        }

        public static Model3DGroup CreaeSphereModel(Point3D center, double radius, int num_phi, int num_theta, Color color)
        {
            // Make a dictionary to track the sphere's points.
            Dictionary<Point3D, int> dict = new Dictionary<Point3D, int>();
            Model3DGroup sphere = new Model3DGroup();

            double phi0, theta0;
            double dphi = Math.PI / num_phi;
            double dtheta = 2 * Math.PI / num_theta;

            phi0 = 0;
            double y0 = radius * Math.Cos(phi0);
            double r0 = radius * Math.Sin(phi0);
            for (int i = 0; i < num_phi; i++)
            {
                double phi1 = phi0 + dphi;
                double y1 = radius * Math.Cos(phi1);
                double r1 = radius * Math.Sin(phi1);

                // Point ptAB has phi value A and theta value B.
                // For example, pt01 has phi = phi0 and theta = theta1.
                // Find the points with theta = theta0.
                theta0 = 0;
                Point3D pt00 = new Point3D(
                    center.X + r0 * Math.Cos(theta0),
                    center.Y + y0,
                    center.Z + r0 * Math.Sin(theta0));
                Point3D pt10 = new Point3D(
                    center.X + r1 * Math.Cos(theta0),
                    center.Y + y1,
                    center.Z + r1 * Math.Sin(theta0));
                for (int j = 0; j < num_theta; j++)
                {
                    // Find the points with theta = theta1.
                    double theta1 = theta0 + dtheta;
                    Point3D pt01 = new Point3D(
                        center.X + r0 * Math.Cos(theta1),
                        center.Y + y0,
                        center.Z + r0 * Math.Sin(theta1));
                    Point3D pt11 = new Point3D(
                        center.X + r1 * Math.Cos(theta1),
                        center.Y + y1,
                        center.Z + r1 * Math.Sin(theta1));

                    // Create the triangles.

                    TriangleModel.color = color;
                    Func<Point3D, Point3D, Point3D, Model3DGroup> CreateTriangleModel = TriangleModel.CreateTriangleModel;

                    sphere.Children.Add(CreateTriangleModel(pt00, pt11, pt10));
                    sphere.Children.Add(CreateTriangleModel(pt00, pt01, pt11));

                    // Move to the next value of theta.
                    theta0 = theta1;
                    pt00 = pt01;
                    pt10 = pt11;
                }

                // Move to the next value of phi.
                phi0 = phi1;
                y0 = y1;
                r0 = r1;
            }
            return sphere;
        }

        private class TriangleModel
        {
            public static Color color;
            public static Model3DGroup CreateTriangleModel(Point3D p0, Point3D p1, Point3D p2)
            {
                MeshGeometry3D mesh = new MeshGeometry3D();
                Material material = new DiffuseMaterial(
                    new SolidColorBrush(color));

                mesh.Positions.Add(p0);
                mesh.Positions.Add(p1);
                mesh.Positions.Add(p2);

                mesh.TriangleIndices.Add(0);
                mesh.TriangleIndices.Add(1);
                mesh.TriangleIndices.Add(2);

                GeometryModel3D model = new GeometryModel3D(mesh, material);
                Model3DGroup modelGroup = new Model3DGroup();
                modelGroup.Children.Add(model);
                return modelGroup;
            }
        }
     
    }
}
