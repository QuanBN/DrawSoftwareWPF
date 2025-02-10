using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DrawSoftware.ConfigArea;
using DrawSoftware.Models;
using DrawSoftware.Models.ShapeModels;

namespace DrawSoftware
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ShapeBrush shapeBrush = new ShapeBrush(0);
        Point currentPoint = new Point();
        Object currObj = null;
        bool isHold = false;
        
        public MainWindow()
        {
            InitializeComponent();
            Config.brush.BrushChanged += BrushChanged;
            ContainerPaint.DrageEvent += DragEventHande;
            btnDraw_OnClick();

        }

        private void DragEventHande(Shape shape)
        {
            if(ContainerPaint.IsDrag)
            {
                Cursor = Cursors.Hand;
                if(ContainerPaint.SelectedShape != null)
                    ContainerPaint.SelectedShape.Opacity = 0.7;
            }
            else
            {
                Cursor = Cursors.Arrow;
                if (ContainerPaint.SelectedShape != null)
                {
                    ContainerPaint.SelectedShape.Opacity = 1;
                    ContainerPaint.SelectedShape = null;
                }
            }
        }

        private void BrushChanged()
        {
            //MessageBox.Show("Brush Changed");
        }

        private void btnDraw_OnClick()
        {
            paintSurface.MouseMove -= Draw_MouseMove;
            paintSurface.MouseMove += Draw_MouseMove;
           
        }
        private void Draw_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();
                line.Stroke = Config.brush.ColorPrimary;
                line.StrokeThickness = 1;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y - stPanel.ActualHeight - Menu.ActualHeight;
                currentPoint = new Point(e.GetPosition(this).X, e.GetPosition(this).Y - stPanel.ActualHeight - Menu.ActualHeight);
                paintSurface.Children.Add(line);
            }
        }
        private void Shapes_MouseMove(object sender, MouseEventArgs e)
        {
            
            Shape old_el = currObj as Shape;
            Shape el = null;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                shapeBrush.shapeType = lbShapes.SelectedIndex;
                shapeBrush.Create(currentPoint, new Point(e.GetPosition(this).X, e.GetPosition(this).Y - stPanel.ActualHeight - Menu.ActualHeight));
                el = shapeBrush.lastShape;
                switch (lbShapes.SelectedIndex)
                {
                    case 1:
                        //el.Name = "Circle_" + ContainerPaint.Shapes.Count.ToString();
                        el.Name = "Circle";
                        break;
                    case 2:
                        //el.Name = "Retangle_" + ContainerPaint.Shapes.Count.ToString();
                        el.Name = "Retangle";
                        break;
                    case 3:
                        //el.Name = "Triangle_" + ContainerPaint.Shapes.Count.ToString();
                        el.Name = "Triangle";
                        break;
                    default:
                        el = null;
                        btnDraw_OnClick();
                        break;
                }
                paintSurface.Children.Remove(old_el);
                if(el != null)
                {
                    paintSurface.Children.Add(el);
                    currObj = el;
                }
            }
            else
            {
                if (currObj != null)
                {
                    ContainerPaint.Shapes.Add(currObj as Shape);
                    MessageBox.Show(ContainerPaint.Shapes.Count().ToString());
                }
                currObj = null;
            }
        }

        private void ClearCanvas(object sender, RoutedEventArgs e)
        {
            ContainerPaint.IsDrag = false;
            paintSurface.Children.Clear();
        }

        private void paintSurface_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = new Point(e.GetPosition(this).X,e.GetPosition(this).Y - stPanel.ActualHeight - Menu.ActualHeight);
        }

        private void paintSurface_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
        }
        private void cursor_Action()
        {
            paintSurface.MouseMove -= Draw_MouseMove;
            paintSurface.MouseMove -= Shapes_MouseMove;
            foreach (UIElement el in paintSurface.Children)
            {
                el.MouseLeftButtonDown += Cursor_MouseDown;
                el.MouseLeftButtonUp += Cursor_MouseUp;
                el.MouseMove += Cursor_MouseMove;
            }
        }
        private void Cursor_MouseMove(object sender, MouseEventArgs e)
        {
            var obj = ContainerPaint.SelectedShape;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (ContainerPaint.IsDrag && isHold)
                {
                    Point position = e.GetPosition(paintSurface);
                    if (obj != null)
                    {
                        if (obj.Name == "Circle")
                        {
                            shapeBrush.shapeType = 1;
                        }
                        else if (obj.Name == "Retangle")
                        {
                            shapeBrush.shapeType = 2;
                        }
                        else if (obj.Name == "Triangle")
                        {
                            shapeBrush.shapeType = 3;
                        }
                        shapeBrush.lastShape = obj as Shape;
                        shapeBrush.Move(currentPoint, position);
                        currentPoint = position;
                    }
                }
            }
            else
            {
                isHold = false;
            }
        }
        private void Cursor_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //ContainerPaint.IsDrag = false;
            isHold = false;
        }

        private void Cursor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UIElement obj = sender as UIElement;
            Shape shap = ContainerPaint.SelectedShape;
            if (shap != null)
                shap.Opacity = 1;
            shap = obj as Shape;
            ContainerPaint.SelectedShape = shap;
            shap.Opacity = 0.7;
            if(obj != null)
            {
                ContainerPaint.IsDrag = true;
                isHold = true;
            }
            else
            {
                ContainerPaint.IsDrag = false;
                isHold = false;
            }
            

        }

        private void lbShapes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            paintSurface.MouseMove -= Draw_MouseMove;
            paintSurface.MouseMove -= Shapes_MouseMove;

            if (lbShapes.SelectedIndex == 0)
            {
                cursor_Action();
            }
            else
            {
                ContainerPaint.IsDrag = false;
                isHold = false;
                foreach (UIElement el in paintSurface.Children)
                {
                    el.MouseLeftButtonDown -= Cursor_MouseDown;
                    el.MouseLeftButtonUp -= Cursor_MouseUp;
                    el.MouseMove -= Cursor_MouseMove;
                }
                paintSurface.MouseMove += Shapes_MouseMove;
            }
        }

        private void ColorPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Config.brush.ColorPrimary = new SolidColorBrush((Color)ColorConverter.ConvertFromString(((ComboBoxItem)ColorPicker.SelectedItem).Content.ToString()));
        }

        private void ColorPickerSecondary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Config.brush.ColorSecondary = new SolidColorBrush((Color)ColorConverter.ConvertFromString(((ComboBoxItem)ColorPicker2.SelectedItem).Content.ToString()));
        }

        private void btnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (UIElement el in paintSurface.Children)
            {
                if(el == ContainerPaint.SelectedShape)
                {
                    paintSurface.Children.Remove(el);
                    break;
                }
            }
        }

        private void btnFill_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (UIElement el in paintSurface.Children)
            {
                if (el == ContainerPaint.SelectedShape)
                {
                    el.SetValue(Shape.FillProperty, Config.brush.ColorPrimary);
                    el.SetValue(Shape.StrokeProperty, Config.brush.ColorSecondary);
                }
            }
        }

        
    }
}