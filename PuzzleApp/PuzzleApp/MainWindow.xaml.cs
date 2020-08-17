using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace PuzzleApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Question> quests = new List<Question>();
        private System.Windows.Media.MediaPlayer player = new System.Windows.Media.MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists("Questions.xml"))
            {
                using (FileStream fs = new FileStream("Questions.xml", FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(quests.GetType());
                    quests = (List<Question>)serializer.Deserialize(fs);
                }
            }

            if (quests.Count == 0)
                Start.IsEnabled = false;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AnswerWindow win = new AnswerWindow(ref quests);
            win.ShowDialog();
            if (win.f)
            {
                Start.Visibility = Visibility.Hidden;
                addQuest.Visibility = Visibility.Hidden;
                title.Visibility = Visibility.Hidden;
                switch (win.getResult)
                {
                    case 0:
                        resText.Text = "Ваше будущее - ученый. Область деятельности: Наука. Фундаментальное материаловедение.";
                        resText.Foreground = System.Windows.Media.Brushes.Red;
                        player.Open(new Uri("Music/0.mp3", UriKind.Relative));
                        player.Position = TimeSpan.FromSeconds(0);
                        break;
                    case 1:
                        resText.Text = "Ваше будущее - работа в крупных фирмах: Инновации. Прикладное материаловедение.";
                        resText.Foreground = System.Windows.Media.Brushes.Blue;
                        player.Open(new Uri("Music/1.mp3", UriKind.Relative));
                        player.Position = TimeSpan.FromSeconds(0);
                        break;
                    case 2:
                        resText.Text = "Ваше будущее - эффективный менеджер. Работа везде, но выбор не за вами. Учитесь!";
                        resText.Foreground = System.Windows.Media.Brushes.Black;
                        player.Open(new Uri("Music/2.mp3", UriKind.Relative));
                        player.Position = TimeSpan.FromSeconds(35);
                        break;
                    case 3:
                        resText.Text = "Мы вас тоже ждем. В университете есть Клуб Веселых и находчивых, спортивные секции, хоровой кружок, танцевальная студия и т.д. и т.п.";
                        resText.Foreground = System.Windows.Media.Brushes.Green;
                        player.Open(new Uri("Music/3.mp3", UriKind.Relative));
                        player.Position = TimeSpan.FromSeconds(0);
                        break;
                }
            }
            this.Show();
            player.Play();
        }

        private void addQuest_Click(object sender, RoutedEventArgs e)
        {
            AddQuestionWindow window = new AddQuestionWindow();
            window.ShowDialog();
            if (window.f)
            {
                quests.Add(new Question(window.quest.Text, window.getAnswers));
                using (FileStream fs = new FileStream("Questions.xml", FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializer = new XmlSerializer(quests.GetType());
                    serializer.Serialize(fs, quests);
                }
                Start.IsEnabled = true;
            }
        }
    }
}
