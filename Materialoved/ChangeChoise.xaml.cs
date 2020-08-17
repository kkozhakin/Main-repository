using System.Windows;

namespace Materialoved
{
    /// <summary>
    /// Логика взаимодействия для ChangeChoise.xaml
    /// </summary>
    public partial class ChangeChoise : Window
    {
        public int game { get; set; }
        public int question { get; set; }

        public ChangeChoise()
        {
            InitializeComponent();
            if (MainWindow.games != null)
            {
                game = -1;
                question = -1;
                for (int i = 0; i < MainWindow.games.Count; i++)
                    games.Items.Add("Игра " + (i + 1));
                games.SelectedIndex = 0;
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            game = games.SelectedIndex;
            if (r_1.IsChecked == true)
                question = 0;
            if (r_2.IsChecked == true)
                question = 1;
            if (r_3.IsChecked == true)
                question = 2;
            if (r_4.IsChecked == true)
                question = 3;
            if (r_5.IsChecked == true)
                question = 4;
            if (r_6.IsChecked == true)
                question = 5;
            if (r_7.IsChecked == true)
                question = 6;
            if (r_8.IsChecked == true)
                question = 7;
            if (r_9.IsChecked == true)
                question = 8;
            if (r_10.IsChecked == true)
                question = 9;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
