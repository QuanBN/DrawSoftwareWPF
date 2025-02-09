using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using DrawSoftware.ConfigArea;

namespace DrawSoftware.Models.ShapeModels
{
    public class RetangleShape : ShapeOrigin
    {
        public RetangleShape(Shape? shape = null) : base(shape)
        {
        }

        public override void Draw(Point CurrentPoint, Point MousePoint)
        {
            Polygon rectangle = new Polygon();
            rectangle.Stroke = Config.brush.ColorSecondary;
            rectangle.StrokeThickness = Config.brush.Thickness;
            rectangle.Fill = Config.brush.ColorPrimary;
            PointCollection points = new PointCollection();
            points.Add(CurrentPoint);
            points.Add(new Point(MousePoint.X, CurrentPoint.Y));
            points.Add(MousePoint);
            points.Add(new Point(CurrentPoint.X, MousePoint.Y));
            rectangle.Points = points;
            this.shape = rectangle;
        }

        public override void Move(Point CurrentPoint, Point MousePoint)
        {
            Polygon rectangle = shape as Polygon;
            Point V = new Point(MousePoint.X - CurrentPoint.X, MousePoint.Y - CurrentPoint.Y);
            rectangle.Points[0] = new Point(rectangle.Points[0].X + V.X, rectangle.Points[0].Y + V.Y);
            rectangle.Points[1] = new Point(rectangle.Points[1].X + V.X, rectangle.Points[1].Y + V.Y);
            rectangle.Points[2] = new Point(rectangle.Points[2].X + V.X, rectangle.Points[2].Y + V.Y);
            rectangle.Points[3] = new Point(rectangle.Points[3].X + V.X, rectangle.Points[3].Y + V.Y);
        }
    }
}
