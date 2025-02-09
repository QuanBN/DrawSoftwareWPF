using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DrawSoftware.ConfigArea;
using System.Windows.Shapes;
using System.Windows;

namespace DrawSoftware.Models.ShapeModels
{
    public class TriangleShape : ShapeOrigin
    {
        public TriangleShape(Shape? shape = null) : base(shape)
        {
        }

        public override void Draw(Point currentPoint,Point MousePoint)
        {
            Polygon triangle = new Polygon();
            triangle.Fill = Config.brush.ColorPrimary;
            PointCollection points = new PointCollection();
            Point G = new Point(currentPoint.X, currentPoint.Y);
            double scaleFactor = Math.Sqrt(
                Math.Pow(MousePoint.X - currentPoint.X, 2) + Math.Pow(MousePoint.Y - currentPoint.Y, 2)
            );
            Point A = new Point(currentPoint.X, currentPoint.Y - scaleFactor);
            Point B = new Point((3 * G.X - A.X - Math.Sqrt(3) * (A.Y - G.Y)) / 2, (3 * G.Y - A.Y + Math.Sqrt(3) * (A.X - G.X)) / 2);
            Point C = new Point((3 * G.X - A.X + Math.Sqrt(3) * (A.Y - G.Y)) / 2, (3 * G.Y - A.Y - Math.Sqrt(3) * (A.X - G.X)) / 2);

            points.Add(A);
            points.Add(C);
            points.Add(B);
            triangle.Points = points;
            this.shape = triangle;
        }

        public override void Move(Point currentPoint, Point MousePoint)
        {
            Polygon triangle = shape as Polygon;
            //Point G = new Point((triangle.Points[0].X + triangle.Points[1].X + triangle.Points[2].X)/3, (triangle.Points[0].Y + triangle.Points[1].Y + triangle.Points[2].Y) / 3);
            Point V = new Point(MousePoint.X - currentPoint.X, MousePoint.Y - currentPoint.Y);
            triangle.Points[0] = new Point(triangle.Points[0].X + V.X, triangle.Points[0].Y + V.Y);
            triangle.Points[1] = new Point(triangle.Points[1].X + V.X, triangle.Points[1].Y + V.Y);
            triangle.Points[2] = new Point(triangle.Points[2].X + V.X, triangle.Points[2].Y + V.Y);
        }
    }
}
