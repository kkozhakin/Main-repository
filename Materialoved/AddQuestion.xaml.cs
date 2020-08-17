using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace Materialoved
{
    /// <summary>
    /// Логика взаимодействия для AddQuestion.xaml
    /// </summary>
    public partial class AddQuestion : Window
    {
        int n;
        int g;
        bool f = true;

        public AddQuestion(int n, int g = -1)
        {
            InitializeComponent();
            this.n = n;
            this.g = g;
            this.Title = "Вопрос " + n;

            if (g != -1)
            {
                Add.Visibility = Visibility.Hidden;
                Change.Visibility = Visibility.Visible;
                answer_1.Text = MainWindow.games[g][n].answers[0];
                answer_2.Text = MainWindow.games[g][n].answers[1];
                answer_3.Text = MainWindow.games[g][n].answers[2];
                answer_4.Text = MainWindow.games[g][n].answers[3];
                question.Text = MainWindow.games[g][n].question;
                switch (MainWindow.games[g][n].correctAnswer)
                {
                    case 0:
                        correctAnswer_1.IsChecked = true;
                        break;
                    case 1:
                        correctAnswer_2.IsChecked = true;
                        break;
                    case 2:
                        correctAnswer_3.IsChecked = true;
                        break;
                    case 3:
                        correctAnswer_4.IsChecked = true;
                        break;
                }
            }
            else
            {
                Add.Visibility = Visibility.Visible;
                Change.Visibility = Visibility.Hidden;
                if (n == 1)
                    MainWindow.games.Add(new List<Question>());
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {          
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (correctAnswer_1.IsChecked == true)
                MainWindow.games[MainWindow.games.Count - 1].Add(new Question(question.Text, new string[4] { answer_1.Text, answer_2.Text, answer_3.Text, answer_4.Text }, 0));
            if (correctAnswer_2.IsChecked == true)
                MainWindow.games[MainWindow.games.Count - 1].Add(new Question(question.Text, new string[4] { answer_1.Text, answer_2.Text, answer_3.Text, answer_4.Text }, 1));
            if (correctAnswer_3.IsChecked == true)
                MainWindow.games[MainWindow.games.Count - 1].Add(new Question(question.Text, new string[4] { answer_1.Text, answer_2.Text, answer_3.Text, answer_4.Text }, 2));
            if (correctAnswer_4.IsChecked == true)
                MainWindow.games[MainWindow.games.Count - 1].Add(new Question(question.Text, new string[4] { answer_1.Text, answer_2.Text, answer_3.Text, answer_4.Text }, 3));
            if (n == 10)
                using (FileStream fs = new FileStream("Games.xml", FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializer = new XmlSerializer(MainWindow.games.GetType());
                    serializer.Serialize(fs, MainWindow.games);
                }
            else
                new AddQuestion(n + 1).ShowDialog();
            f = false;
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (f)
                MainWindow.games.RemoveAt(MainWindow.games.Count - 1);
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (correctAnswer_1.IsChecked == true)
                MainWindow.games[g][n] = new Question(question.Text, new string[4] { answer_1.Text, answer_2.Text, answer_3.Text, answer_4.Text }, 0);
            if (correctAnswer_2.IsChecked == true)
                MainWindow.games[g][n] = new Question(question.Text, new string[4] { answer_1.Text, answer_2.Text, answer_3.Text, answer_4.Text }, 1);
            if (correctAnswer_3.IsChecked == true)
                MainWindow.games[g][n] = new Question(question.Text, new string[4] { answer_1.Text, answer_2.Text, answer_3.Text, answer_4.Text }, 2);
            if (correctAnswer_4.IsChecked == true)
                MainWindow.games[g][n] = new Question(question.Text, new string[4] { answer_1.Text, answer_2.Text, answer_3.Text, answer_4.Text }, 3);

            using (FileStream fs = new FileStream("Games.xml", FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(MainWindow.games.GetType());
                serializer.Serialize(fs, MainWindow.games);
            }
            f = false;
            this.Close();
        }
    }
}
