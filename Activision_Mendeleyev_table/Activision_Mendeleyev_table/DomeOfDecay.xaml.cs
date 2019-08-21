using Activision_Mendeleyev_table.HelperClasses;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Activision_Mendeleyev_table
{
    /// <summary>
    /// Логика взаимодействия для DomeOfDecay.xaml
    /// </summary>
    public partial class DomeOfDecay : Window
    {
        List<List<double>> dat = new List<List<double>>();
        BinSystem sys;
        DrawingClasses.CollapseGraph graph;
        System.Windows.Forms.PictureBox diag = new System.Windows.Forms.PictureBox();

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(System.IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(System.IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_STYLE = -16;
        private const int WS_MAXIMIZEBOX = 0x10000;

        private void Window_SourceInitialized(object sender, System.EventArgs e)
        {
            var hwnd = new System.Windows.Interop.WindowInteropHelper((Window)sender).Handle;
            var value = GetWindowLong(hwnd, GWL_STYLE);
            SetWindowLong(hwnd, GWL_STYLE, (int)(value & ~WS_MAXIMIZEBOX));
        }

        public DomeOfDecay()
        {
            InitializeComponent();

            sys = new BinSystem("1", MendeleevTable.Elems.Find(x => x.Name == "Na"), MendeleevTable.Elems.Find(x => x.Name == "Ag"), MendeleevTable.Elems.Find(x => x.Name == "Cl"));
            sys.setData(2, 30, 6, 1, 1);
            host.Child = diag;
            diag.Paint += new System.Windows.Forms.PaintEventHandler(diag_Paint);

            Points.Columns.Add(new DataGridTextColumn()
            {
                Header = "x",
                Binding = new Binding("[0]")
            });
            Points.Columns.Add(new DataGridTextColumn()
            {
                Header = "y",
                Binding = new Binding("[1]")
            });
            Points.ItemsSource = dat;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите закрыть окно? Все несохраненные данные будут удалены!", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                e.Cancel = true;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MaxWidth = e.NewSize.Height + 92;
            Width = e.NewSize.Height + 92;
        }

        private void diag_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            try
            {
                graph = new DrawingClasses.CollapseGraph(g, sys, diag.Width);
                graph.DrawCollapse();
                graph.DrawAxes();
                graph.DrawExperiment();
            }
            catch
            {
                MessageBox.Show("Неверные данные для построения купола!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Points_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            double p;
            if (!double.TryParse((e.EditingElement as TextBox).Text.Replace('.', ','), out p))
            {
                MessageBox.Show("Координаты точки должны быть числом!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                (e.EditingElement as TextBox).Text = "";
                e.Cancel = true;
            }
            if (dat[e.Row.GetIndex()].Capacity == 0)
            {
                dat[e.Row.GetIndex()].Add(0);
                dat[e.Row.GetIndex()].Add(0);
            }
            if (e.Column.DisplayIndex == 0)
                dat[e.Row.GetIndex()][0] = p;
            else
                dat[e.Row.GetIndex()][1] = p;
        }

        private void Build_Click(object sender, RoutedEventArgs e)
        {
            //if (sys != null)
            //    systemForDiagram = sys.Clone();
            
            diag.Refresh(); 
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog
            {
                FileName = "Points",
                DefaultExt = ".xml",
                Filter = "XML documents (.xml)|*.xml"
            };

            if (dlg.ShowDialog() == true)
                DataGridHelper.Serialize(dlg.FileName, ref dat);
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "XML documents (.xml)|*.xml"
            };

            if (dlg.ShowDialog() == true)
                DataGridHelper.Deserialize(dlg.FileName, ref dat);
            Points.ItemsSource = dat;
        }

        private void DateSettings_Click(object sender, RoutedEventArgs e)
        {
            DateSettings ds = new DateSettings(sys);
            ds.ShowDialog();
            sys = ds.GetBS();
        }
    }
}
