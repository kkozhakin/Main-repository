using Activision_Mendeleyev_table.HelperClasses;
using System.Windows;

namespace Activision_Mendeleyev_table
{
    /// <summary>
    /// Логика взаимодействия для DateSettings.xaml
    /// </summary>
    public partial class DateSettings : Window
    {
        private BinSystem sys;
        public DateSettings(BinSystem sys)
        {
            InitializeComponent();
            this.sys = sys;
        }

        public BinSystem GetBS() { return sys; }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            //sys.setData();
            //sys.symbols[0] =
            //sys.symbols[1] =
            //sys.symbols[2] =
            //sys.symbols[3] =
            //sys.symbols[4] =
        }
    }
}
