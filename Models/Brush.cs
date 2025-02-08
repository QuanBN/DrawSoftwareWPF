using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DrawSoftware.Models
{
    public class Brush
    {
        private SolidColorBrush _ColorPrimary;
        private SolidColorBrush _ColorSecondary;
        private double _Thickness;
        public delegate void BrushChangedDelegate();
        public BrushChangedDelegate BrushChanged;

        public SolidColorBrush ColorPrimary
        {
            get => _ColorPrimary;
            set
            {
                _ColorPrimary = value;
                BrushChanged?.DynamicInvoke();

            }
        }
        public SolidColorBrush ColorSecondary
        {
            get => _ColorSecondary;
            set
            {
                _ColorSecondary = value;
                BrushChanged?.DynamicInvoke();
            }
        }
        public double Thickness
        {
            get => _Thickness;
            set
            {
                _Thickness = value;
                BrushChanged?.DynamicInvoke();
            }
        }
        public Brush()
        {
            ColorPrimary = new SolidColorBrush(Colors.Black);
            ColorSecondary = new SolidColorBrush(Colors.White);
            Thickness = 3;
        }
        public Brush(SolidColorBrush colorPrimary, SolidColorBrush colorSecondary, double thickness)
        {
            ColorPrimary = colorPrimary;
            ColorSecondary = colorSecondary;
            Thickness = thickness;
        }
    }
}
