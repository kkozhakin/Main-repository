using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Ellipse_in_Square
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Координаты курсора на момент захвата эллипса
        /// </summary>
        private Point offsetInEllipse;
        /// <summary>
        /// Геометрия элиипса для упрощения рабты с радиусом и центром
        /// </summary>
        private EllipseGeometry ellipse = new EllipseGeometry(new Point(-1, -1), 0, 0);
        /// <summary>
        /// Площадь квадрата (количество точек)
        /// </summary>
        private int s;

        public MainWindow()
        {
            InitializeComponent();

            var rand = new Random();

            int r = rand.Next(100, 300);
            square.Rect = new Rect(rand.Next(0, (int)(canvas.MinWidth - r - 1)), rand.Next(0, (int)(canvas.MinHeight - r - 1)), r, r);
            s = Square();

            el.Width = rand.Next(50, 200);
            el.Height = rand.Next(50, 200);
            ellipse = new EllipseGeometry(new Point(el.Width / 2, el.Height / 2), el.Width / 2, el.Height / 2);
            elstroke.Height = el.Height;
            elstroke.Width = el.Width;
            
            el.MouseDown += new MouseButtonEventHandler(ellipse_MouseDown);
            el.MouseMove += new MouseEventHandler(ellipse_MouseMove);
            el.MouseUp += new MouseButtonEventHandler(ellipse_MouseUp);

            elstroke.MouseDown += new MouseButtonEventHandler(ellipseStroke_MouseDown);
            elstroke.MouseMove += new MouseEventHandler(ellipseStroke_MouseMove);
            elstroke.MouseUp += new MouseButtonEventHandler(ellipseStroke_MouseUp);
        }

        void ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;

            el.CaptureMouse();
            offsetInEllipse = e.GetPosition(el);
        }

        void ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed || !el.IsMouseCaptured)
                return;

            var pos = e.GetPosition(canvas);
            //Сдвиг фигур (еллипс и контур эллипса)
            if (pos.X > 0 && pos.Y > 0 && pos.X < canvas.ActualWidth && pos.Y < canvas.ActualHeight)
            {
                Canvas.SetLeft(el, pos.X - offsetInEllipse.X);
                Canvas.SetTop(el, pos.Y - offsetInEllipse.Y);
                Canvas.SetLeft(elstroke, pos.X - offsetInEllipse.X);
                Canvas.SetTop(elstroke, pos.Y - offsetInEllipse.Y);
            }
        }

        void ellipse_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!el.IsMouseCaptured)
                return;

            var pos = e.GetPosition(canvas);
            el.ReleaseMouseCapture();

            ellipse.Center = new Point(pos.X - offsetInEllipse.X + ellipse.RadiusX, pos.Y - offsetInEllipse.Y + ellipse.RadiusY);
            int i = Square();
            label.Content = "Рассогласование: " + (i == s ? -1 : i);
            //Проверка на приблизительную точность вписывания эллипса в квадрат
            if (Math.Abs(i + Math.PI * s / 4 - s) < s / 150 && Math.Abs(square.Rect.X - ellipse.Center.X) < s / 200 && Math.Abs(square.Rect.Y - ellipse.Center.Y) < s / 200)
                label.Background = Brushes.Green;
            else label.Background = Brushes.White;
        }

        void ellipseStroke_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;

            elstroke.CaptureMouse();
            offsetInEllipse = Mouse.GetPosition(this);
        }

        void ellipseStroke_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed || !elstroke.IsMouseCaptured)
                return;

            var pos = Mouse.GetPosition(this);
            //Растягивание (сжатие) фигур, при чрезмерном сжатии восстанавливает исходнвй размер
            if (pos.X > 0 && pos.Y > 0 && pos.X < canvas.ActualWidth && pos.Y < canvas.ActualHeight)
                try
                {
                    el.Width = pos.X - offsetInEllipse.X + 2 * ellipse.RadiusX;
                    el.Height = pos.Y - offsetInEllipse.Y + 2 * ellipse.RadiusY;
                    elstroke.Width = pos.X - offsetInEllipse.X + 2 * ellipse.RadiusX;
                    elstroke.Height = pos.Y - offsetInEllipse.Y + 2 * ellipse.RadiusY;
                }
                catch (ArgumentException)
                {
                    el.Width = 2 * ellipse.RadiusX;
                    el.Height = 2 * ellipse.RadiusY;
                    elstroke.Width = 2 * ellipse.RadiusX;
                    elstroke.Height = 2 * ellipse.RadiusY;
                }
        }

        void ellipseStroke_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!elstroke.IsMouseCaptured)
                return;
            elstroke.ReleaseMouseCapture();

            ellipse.Center = new Point(ellipse.Center.X + el.Width / 2 - ellipse.RadiusX, ellipse.Center.Y + el.Height / 2 - ellipse.RadiusY);
            ellipse.RadiusY = el.Height / 2;
            ellipse.RadiusX = el.Width / 2;
            int i = Square();
            label.Content = "Рассогласование: " + (i == s ? -1 : i);
            //Проверка на приблизительную точность вписывания эллипса в квадрат
            if (Math.Abs(i + Math.PI * s / 4 - s) < s / 150 && Math.Abs(square.Rect.X - ellipse.Center.X) < s / 200 && Math.Abs(square.Rect.Y - ellipse.Center.Y) < s / 200)
                label.Background = Brushes.Green;
            else label.Background = Brushes.White;
        }
        /// <summary>
        /// Расчитывает разность площадей квадрата и части эллипса внутри него (количество точек) 
        /// </summary>
        /// <returns>Площадь</returns>
        private int Square()
        {
            int sum = 0;
            double i = square.Rect.X;
            while (i <= square.Rect.X + square.Rect.Width)
            {
                double j = square.Rect.Y;
                while (j <= square.Rect.Y + square.Rect.Height)
                {
                    if (Math.Pow((i - ellipse.Center.X) / ellipse.RadiusX, 2) + Math.Pow((j - ellipse.Center.Y) / ellipse.RadiusY, 2) > 1)
                        ++sum;
                    j += 1;
                }
                i += 1;
            }
            return sum;
        }
    }
}
