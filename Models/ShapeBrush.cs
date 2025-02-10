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
using DrawSoftware.Models.ShapeModels;

namespace DrawSoftware.Models
{
    public class ShapeBrush
    {
        public TriangleShape? triangleShape = new TriangleShape();
        public CircleShape? circleShape = new CircleShape();
        public RetangleShape? retangleShape = new RetangleShape();
        public LineShape? lineShape = new LineShape();

        public Shape lastShape { get; set; }
        public int shapeType { get; set; }
        public ShapeBrush(int shapeType, Shape? shape = null)
        {
            this.shapeType = shapeType;
            this.lastShape = shape;
        }
        public void Create(Point currentPoint, Point MousePoint)
        {
            switch (shapeType)
            {
                case 0:
                    lineShape.Draw(currentPoint, MousePoint);
                    lastShape = lineShape.shape;
                    break;
                case 1:
                    circleShape.Draw(currentPoint, MousePoint);
                    lastShape = circleShape.shape;
                    break;
                    
                case 2:
                    retangleShape.Draw(currentPoint, MousePoint);
                    lastShape = retangleShape.shape;
                    break;
                case 3:
                    triangleShape.Draw(currentPoint, MousePoint);
                    lastShape = triangleShape.shape;
                    break;
                default:
                    break;
            }
        }
        public void Move(Point currentPoint, Point MousePoint)
        {
            switch (shapeType)
            {
                case 0:
                    lineShape.shape = lastShape;
                    lineShape.Move(currentPoint, MousePoint);
                    lastShape = lineShape.shape;
                    break;
                case 1:
                    circleShape.shape = lastShape;
                    circleShape.Move(currentPoint, MousePoint);
                    lastShape = circleShape.shape;
                    break;
                case 2:
                    retangleShape.shape = lastShape;
                    retangleShape.Move(currentPoint, MousePoint);
                    lastShape = retangleShape.shape;
                    break;
                case 3:
                    triangleShape.shape = lastShape;
                    triangleShape.Move(currentPoint, MousePoint);
                    lastShape = triangleShape.shape;
                    break;
                default:
                    break;
            }
        }
        
    }
}
