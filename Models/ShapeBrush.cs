using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using DrawSoftware.ConfigArea;

namespace DrawSoftware.Models
{
    public class ShapeBrush
    {
        public Polygon Triangle(Point currentPoint, Point MousePoint)
        {
            
            Polygon triangle = new Polygon();
            triangle.Stroke = Config.brush.ColorSecondary;
            triangle.StrokeThickness = Config.brush.Thickness;

            triangle.Fill = Config.brush.ColorPrimary;
            PointCollection points = new PointCollection();
            Point G = new Point(currentPoint.X,currentPoint.Y);
            double scaleFactor = Math.Sqrt(
                Math.Pow(MousePoint.X - currentPoint.X, 2) + Math.Pow(MousePoint.Y - currentPoint.Y, 2)
            );
            Point A = new Point(currentPoint.X, currentPoint.Y-scaleFactor);
            Point B = new Point((3 * G.X - A.X - Math.Sqrt(3) * (A.Y - G.Y)) / 2, (3 * G.Y - A.Y + Math.Sqrt(3) * (A.X - G.X)) / 2);
            Point C = new Point((3 * G.X - A.X + Math.Sqrt(3) * (A.Y - G.Y)) / 2, (3 * G.Y - A.Y - Math.Sqrt(3) * (A.X - G.X)) / 2);

            points.Add(A);
            points.Add(C);
            points.Add(B); 
            triangle.Points = points;
            return triangle;
        }
        public Polygon Rectangle(Point currentPoint, Point MousePoint)
        {
            /*if (currentPoint.X > MousePoint.X)
                MousePoint = new Point(MousePoint.X + 10, MousePoint.Y);
            else
            {
                MousePoint = new Point(MousePoint.X - 10, MousePoint.Y);
            }*/
            Polygon rectangle = new Polygon();
            rectangle.Stroke = Config.brush.ColorSecondary;
            rectangle.StrokeThickness = Config.brush.Thickness;
            rectangle.Fill = Config.brush.ColorPrimary;
            PointCollection points = new PointCollection();
            points.Add(currentPoint);
            points.Add(new Point(MousePoint.X, currentPoint.Y));
            points.Add(MousePoint);
            points.Add(new Point(currentPoint.X, MousePoint.Y));
            rectangle.Points = points;
            return rectangle;
        }
        public Ellipse Circle(Point currentPoint, Point MousePoint)
        {
            double scaleFactor = Math.Sqrt(
                Math.Pow(MousePoint.X - currentPoint.X, 2) + Math.Pow(MousePoint.Y - currentPoint.Y, 2)
            );
            Ellipse circle = new Ellipse();
            circle.Stroke = Config.brush.ColorSecondary;
            circle.StrokeThickness = Config.brush.Thickness;
            circle.Fill = Config.brush.ColorPrimary;
            circle.Width = Math.Abs(2*scaleFactor);
            circle.Height = Math.Abs(2*scaleFactor);
            return circle;
        }
    }
}
