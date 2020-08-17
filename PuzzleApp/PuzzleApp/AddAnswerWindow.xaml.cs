using System.Windows;

namespace PuzzleApp
{
    /// <summary>
    /// Логика взаимодействия для AddAnswerWindow.xaml
    /// </summary>
    public partial class AddAnswerWindow : Window
    {
        int cat = 0;
        public bool f = false;

        public AddAnswerWindow()
        {
            InitializeComponent();
        }

        private void addAns_Click(object sender, RoutedEventArgs e)
        {
            f = true;
            this.Close();
        }

        public int getCat { get { return cat; } }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (((System.Windows.Controls.RadioButton)sender).Foreground == System.Windows.Media.Brushes.Blue)
                cat = 1;
            else if (((System.Windows.Controls.RadioButton)sender).Foreground == System.Windows.Media.Brushes.Black)
                cat = 2;
            else if (((System.Windows.Controls.RadioButton)sender).Foreground == System.Windows.Media.Brushes.Green)
                cat = 3;
            else
                cat = 0;
        }
    }
}
