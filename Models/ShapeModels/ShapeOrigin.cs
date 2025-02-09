using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace DrawSoftware.Models.ShapeModels
{
    public abstract class ShapeOrigin
    {
        public Shape shape { get; set; }
        public ShapeOrigin(Shape shape) { 
            this.shape = shape;
        }
        public abstract void Draw(Point CurrentPoint, Point MousePoint);
        public abstract void Move(Point CurrentPoint, Point MousePoint);

    }
}
