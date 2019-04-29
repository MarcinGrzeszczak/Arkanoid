using System;
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
            return new Point(viewport.ActualWidth, viewport.ActualHeight);
        }
        public void draw(Model3DGroup obj) {
            viewport.Dispatcher.Invoke(() => {
                ModelVisual3D shape = new ModelVisual3D();
                shape.Content = obj;
                viewport.Children.Add(shape);
                });
        }

        public static Model3DGroup CreateCubeModel(double x, double y, double z, double sizeX, double sizeY, double sizeZ)
        {
            Model3DGroup cube = new Model3DGroup();

            Point3D p0 = new Point3D(x - sizeX / 2, y - sizeY / 2, z - sizeZ / 2);
            Point3D p1 = new Point3D(x + sizeX / 2, y - sizeY / 2, z - sizeZ / 2);
            Point3D p2 = new Point3D(x + sizeX / 2, y - sizeY / 2, z + sizeZ / 2);
            Point3D p3 = new Point3D(x - sizeX / 2, y - sizeY / 2, z + sizeZ / 2);
            Point3D p4 = new Point3D(x - sizeX / 2, y + sizeY / 2, z - sizeZ / 2);
            Point3D p5 = new Point3D(x + sizeX / 2, y + sizeY / 2, z - sizeZ / 2);
            Point3D p6 = new Point3D(x + sizeX / 2, y + sizeY / 2, z + sizeZ / 2);
            Point3D p7 = new Point3D(x - sizeX / 2, y + sizeY / 2, z + sizeZ / 2);

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

        private static Model3DGroup CreateTriangleModel(Point3D p0, Point3D p1, Point3D p2)
        {
            MeshGeometry3D mesh = new MeshGeometry3D();
            Material material = new DiffuseMaterial(
                new SolidColorBrush(Colors.Green));

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
