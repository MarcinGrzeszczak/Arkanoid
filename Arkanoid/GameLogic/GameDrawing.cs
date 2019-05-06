
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
        private ModelVisual3D shape;
        public GameDrawing(Viewport3D viewport)
        {
            shape = new ModelVisual3D();
            this.viewport = viewport;
        }

        public Point getsSize() {
            return new Point(viewport.Width, viewport.Height);
        }
        public void draw(Func<Model3DGroup> drawGameObj) {

            viewport.Dispatcher.Invoke(new Action(() => {
                Model3DGroup gameObj = drawGameObj();
                shape = new ModelVisual3D();
                shape.Content = gameObj;
                viewport.Children.Add(shape);
                }));
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
