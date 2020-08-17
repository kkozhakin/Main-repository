using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PuzzleApp
{
    /// <summary>
    /// Логика взаимодействия для AnswerWindow.xaml
    /// </summary>
    public partial class AnswerWindow : Window
    {
        List<Question> quests;
        int q = 0;
        int[] points = new int[4];
        public bool f = false;
        int res = 0;
        System.Windows.Media.Brush rbForeground = System.Windows.Media.Brushes.Red;

        public AnswerWindow(ref List<Question> quests)
        {
            InitializeComponent();
            this.quests = quests;
            quest.Text = quests[0].question;
            for (int i = 0; i < quests[0].answers.Count; i++)
            {
                RadioButton rb = new RadioButton { IsChecked = i == 0 ? true : false, GroupName = "ans", Content = quests[0].answers[i].answer };
                switch (quests[0].answers[i].category)
                {
                    case 0:
                        rb.Foreground = System.Windows.Media.Brushes.Red;
                        break;
                    case 1:
                        rb.Foreground = System.Windows.Media.Brushes.Blue;
                        break;
                    case 2:
                        rb.Foreground = System.Windows.Media.Brushes.Black;
                        break;
                    case 3:
                        rb.Foreground = System.Windows.Media.Brushes.Green;
                        break;
                }
                rb.Checked += RadioButton_Checked;
                panel.Children.Add(rb);
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            panel.Width = e.NewSize.Width - 30;
            panel.Height = e.NewSize.Height - 200;
            quest.Width = e.NewSize.Width;
        }

        public int getResult { get { return res; } }

        private void answer_Click(object sender, RoutedEventArgs e)
        {
            if (rbForeground == System.Windows.Media.Brushes.Blue)
                points[1]++;
            else if (rbForeground == System.Windows.Media.Brushes.Black)
                points[2]++;
            else if (rbForeground == System.Windows.Media.Brushes.Green)
                points[3]++;
            else
                points[0]++;

            if (++q == quests.Count)
            {
                for (int i = 0; i < 3; i++)
                    if (points[i] < points[i + 1])
                        res = i + 1;
                    else
                        points[i + 1] = points[i];
                f = true;
                this.Close();
                return;
            }

            quest.Text = quests[q].question;
            panel.Children.Clear();
            for (int i = 0; i < quests[q].answers.Count; i++)
            {
                RadioButton rb = new RadioButton { IsChecked = i == 0 ? true : false, GroupName = "ans", Content = quests[q].answers[i].answer, Margin = new Thickness(5) };
                switch (quests[q].answers[i].category)
                {
                    case 0:
                        rb.Foreground = System.Windows.Media.Brushes.Red;
                        break;
                    case 1:
                        rb.Foreground = System.Windows.Media.Brushes.Blue;
                        break;
                    case 2:
                        rb.Foreground = System.Windows.Media.Brushes.Black;
                        break;
                    case 3:
                        rb.Foreground = System.Windows.Media.Brushes.Green;
                        break;
                }
                rb.Checked += RadioButton_Checked;
                panel.Children.Add(rb);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            rbForeground = ((RadioButton)sender).Foreground;
        }
    }
}
