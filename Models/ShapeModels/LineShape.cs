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
    public class LineShape : ShapeOrigin
    {
        public LineShape(Shape? shape = null) : base(shape)
        {
        }

        public override void Draw(Point CurrentPoint, Point MousePoint)
        {
            Line line = new Line();
            line.Stroke = Config.brush.ColorPrimary;
            line.StrokeThickness = Config.brush.Thickness;
            line.X1 = CurrentPoint.X;
            line.Y1 = CurrentPoint.Y;
            line.X2 = MousePoint.X;
            line.Y2 = MousePoint.Y;
            shape = line;
        }

        public override void Move(Point CurrentPoint, Point MousePoint)
        {
            MessageBox.Show("Not yet!");
        }
    }
}
