using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PuzzleApp
{
    /// <summary>
    /// Логика взаимодействия для AddQuestionWindow.xaml
    /// </summary>
    public partial class AddQuestionWindow : Window
    {
        List<Answer> answers = new List<Answer>();
        public bool f = false;

        public AddQuestionWindow()
        {
            InitializeComponent();
        }

        private void addQuest_Click(object sender, RoutedEventArgs e)
        {
            f = true;
            this.Close();
        }

        private void addAns_Click(object sender, RoutedEventArgs e)
        {
            AddAnswerWindow ans = new AddAnswerWindow();
            ans.ShowDialog();
            if (ans.f)
            {
                answers.Add(new Answer(ans.ans.Text, ans.getCat));
                Label l = new Label { Content = ans.ans.Text };
                switch (ans.getCat)
                {
                    case 0:
                        l.Foreground = System.Windows.Media.Brushes.Red;
                        break;
                    case 1:
                        l.Foreground = System.Windows.Media.Brushes.Blue;
                        break;
                    case 2:
                        l.Foreground = System.Windows.Media.Brushes.Black;
                        break;
                    case 3:
                        l.Foreground = System.Windows.Media.Brushes.Green;
                        break;
                }
                panel.Children.Add(l);
            }
        }

        public List<Answer> getAnswers { get { return answers; } }
    }
}
