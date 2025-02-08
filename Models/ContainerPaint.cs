using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace DrawSoftware.Models
{
    public static class ContainerPaint
    {
        private static bool _isDrag = false;
        private static List<Shape> _shapes = new List<Shape>();
        private static Shape _selectedShape = null;
        public delegate void ShapeEventHandler(Shape shape);
        public static event ShapeEventHandler ShapeAdded;
        public static event ShapeEventHandler DrageEvent;
        public static event ShapeEventHandler ShapeSelected;
        public static List<Shape> Shapes
        {
            get { return _shapes; }
        }
        public static Shape SelectedShape
        {
            set
            {
                _selectedShape = value;
                ShapeSelected?.Invoke(value);
            }
            get { return _selectedShape; }
        }
        public static bool IsDrag
        {
            set { 
                _isDrag = value;
                DrageEvent?.Invoke(null);
            }
            get { return _isDrag; }
        }
        public static void AddShape(Shape shape)
        {
            _shapes.Add(shape);
            ShapeAdded?.Invoke(shape);
        }
        

    }
}
