using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using DrawSoftware.ConfigArea;

namespace DrawSoftware.Models.ShapeModels
{
    public class CircleShape : ShapeOrigin
    {
        public CircleShape(Shape? shape = null) : base(shape)
        {
        }

        public override void Draw(Point CurrentPoint, Point MousePoint)
        {
            double scaleFactor = Math.Sqrt(
                Math.Pow(MousePoint.X - CurrentPoint.X, 2) + Math.Pow(MousePoint.Y - CurrentPoint.Y, 2)
            );
            Ellipse circle = new Ellipse();
            circle.Stroke = Config.brush.ColorSecondary;
            circle.StrokeThickness = Config.brush.Thickness;
            circle.Fill = Config.brush.ColorPrimary;
            circle.Width = Math.Abs(2 * scaleFactor);
            circle.Height = Math.Abs(2 * scaleFactor);
            this.shape = circle;
            Canvas.SetLeft(shape, CurrentPoint.X - shape.Width / 2);
            Canvas.SetTop(shape, CurrentPoint.Y - shape.Height / 2);
        }

        public override void Move(Point CurrentPoint, Point MousePoint)
        {
            Canvas.SetLeft(shape, MousePoint.X - shape.ActualWidth / 2);
            Canvas.SetTop(shape, MousePoint.Y - shape.ActualHeight / 2);
        }
    }
}
