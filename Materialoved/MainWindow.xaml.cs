using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Xml.Serialization;

namespace Materialoved
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer player = new MediaPlayer();
        public static List<List<Question>> games = new List<List<Question>>();
        private int n = 0;
        private int g = 0;
        private Random rand = new Random();
        private bool f = false;
        private bool m = false;

        public static RoutedCommand Command_1 = new RoutedCommand();
        public static RoutedCommand Command_2 = new RoutedCommand();
        public static RoutedCommand Command_3 = new RoutedCommand();
        public static RoutedCommand Command_4 = new RoutedCommand();

        public MainWindow()
        { 
            InitializeComponent();
            if (File.Exists("Games.xml"))
            {
                using (FileStream fs = new FileStream("Games.xml", FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(games.GetType());
                    games = (List<List<Question>>)serializer.Deserialize(fs);
                }
            }

            if (games != null)
                for (int i = 0; i < games.Count; i++)
                    AddBtn(i);
        }

        private void CallAnswer_1() { answer_1_Click(this, new RoutedEventArgs()); }
        private void CallAnswer_2() { answer_2_Click(this, new RoutedEventArgs()); }
        private void CallAnswer_3() { answer_3_Click(this, new RoutedEventArgs()); }
        private void CallAnswer_4() { answer_4_Click(this, new RoutedEventArgs()); }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new AddQuestion(1).ShowDialog();
            Buttons.Height = 20;
            if (games != null)
                for (int i = 0; i < games.Count; i++)
                    AddBtn(i);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            Answer.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/base.png")));
            GameStart.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/base.png")));
            half.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/half.png")));
            mistake.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/mistake.png")));
            phone.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/phone.png")));            
            CallAsync();
        }

        private void answer_1_Click(object sender, RoutedEventArgs e)
        {
            if (!f)
            {
                f = true;
                answer_1.Background = Brushes.Yellow;
                CheckAnswerAsync(g, n, 0);
            }
        }

        private void answer_2_Click(object sender, RoutedEventArgs e)
        {
            if (!f)
            {
                f = true;
                answer_2.Background = Brushes.Yellow;
                CheckAnswerAsync(g, n, 1);
            }
        }

        private void answer_3_Click(object sender, RoutedEventArgs e)
        {
            if (!f)
            {
                f = true;
                answer_3.Background = Brushes.Yellow;
                CheckAnswerAsync(g, n, 2);
            }
        }

        private void answer_4_Click(object sender, RoutedEventArgs e)
        {
            if (!f)
            {
                f = true;
                answer_4.Background = Brushes.Yellow;
                CheckAnswerAsync(g, n, 3);
            }
        }

        private void half_Click(object sender, RoutedEventArgs e)
        {
            if (!f)
            {
                half.Visibility = Visibility.Hidden;
                int b = rand.Next(0, 4);
                while (b == games[g][n].correctAnswer) 
                    b = rand.Next(0, 4);
                switch (games[g][n].correctAnswer)
                {
                    case 0:
                        if (b != 1) answer_2.Visibility = Visibility.Hidden;
                        if (b != 2) answer_3.Visibility = Visibility.Hidden;
                        if (b != 3) answer_4.Visibility = Visibility.Hidden;
                        break;
                    case 1:
                        if (b != 0) answer_1.Visibility = Visibility.Hidden;
                        if (b != 2) answer_3.Visibility = Visibility.Hidden;
                        if (b != 3) answer_4.Visibility = Visibility.Hidden;
                        break;
                    case 2:
                        if (b != 1) answer_2.Visibility = Visibility.Hidden;
                        if (b != 0) answer_1.Visibility = Visibility.Hidden;
                        if (b != 3) answer_4.Visibility = Visibility.Hidden;
                        break;
                    case 3:
                        if (b != 1) answer_2.Visibility = Visibility.Hidden;
                        if (b != 2) answer_3.Visibility = Visibility.Hidden;
                        if (b != 0) answer_1.Visibility = Visibility.Hidden;
                        break;
                }
            }
        }

        private void phone_Click(object sender, RoutedEventArgs e)
        {
            if (!f)
            {
                phone.Visibility = Visibility.Hidden;
            }
        }

        private void mistake_Click(object sender, RoutedEventArgs e)
        {
            if (!f)
            {
                mistake.Visibility = Visibility.Hidden;
                m = true;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (games != null)
            {
                l_1.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/im.bmp")));
                l_2.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/im.bmp")));
                l_3.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/im.bmp")));
                l_4.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/im.bmp")));
                l_5.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/im.bmp")));
                l_6.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/im.bmp")));
                l_7.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/im.bmp")));
                l_8.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/im.bmp")));
                l_9.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/im.bmp")));
                l_10.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/im.bmp")));
                g = int.Parse((sender as Button).Name.Substring(2));
                player.Open(new Uri("Music/title.mp3", UriKind.Relative));
                player.Play();
                System.Threading.Thread.Sleep(9000);
                player.Stop();
                question.Text = games[g][0].question;
                answer_1.Content = new TextBlock() { Text = "a) " + games[g][0].answers[0], TextWrapping = TextWrapping.Wrap };
                answer_2.Content = new TextBlock() { Text = "b) " + games[g][0].answers[1], TextWrapping = TextWrapping.Wrap };
                answer_3.Content = new TextBlock() { Text = "c) " + games[g][0].answers[2], TextWrapping = TextWrapping.Wrap };
                answer_4.Content = new TextBlock() { Text = "d) " + games[g][0].answers[3], TextWrapping = TextWrapping.Wrap };
                GameStart.Visibility = Visibility.Hidden;
                Answer.Visibility = Visibility.Visible;
                half.Visibility = Visibility.Visible;
                mistake.Visibility = Visibility.Visible;
                phone.Visibility = Visibility.Visible;
            }
        }

        private async System.Threading.Tasks.Task<int> CheckAnswerAsync(int game, int quest, int answ)
        {
            player.Open(new Uri("Music/answer.mp3", UriKind.Relative));
            player.Play();
            await System.Threading.Tasks.Task.Delay(3500);
            player.Stop();
            if (!m)
            {
                switch (games[game][quest].correctAnswer)
                {
                    case 0:
                        answer_1.Background = Brushes.Green;
                        break;
                    case 1:
                        answer_2.Background = Brushes.Green;
                        break;
                    case 2:
                        answer_3.Background = Brushes.Green;
                        break;
                    case 3:
                        answer_4.Background = Brushes.Green;
                        break;
                }
                if (answ != games[game][quest].correctAnswer)
                {
                    switch (answ)
                    {
                        case 0:
                            answer_1.Background = Brushes.Red;
                            break;
                        case 1:
                            answer_2.Background = Brushes.Red;
                            break;
                        case 2:
                            answer_3.Background = Brushes.Red;
                            break;
                        case 3:
                            answer_4.Background = Brushes.Red;
                            break;
                    }
                    player.Open(new Uri("Music/lose.mp3", UriKind.Relative));
                }
                else
                    player.Open(new Uri("Music/win.mp3", UriKind.Relative));
            }
            else
            {
                m = false;
                if (games[game][quest].correctAnswer == answ)
                    switch (answ)
                    {
                        case 0:
                            answer_1.Background = Brushes.Green;
                            break;
                        case 1:
                            answer_2.Background = Brushes.Green;
                            break;
                        case 2:
                            answer_3.Background = Brushes.Green;
                            break;
                        case 3:
                            answer_4.Background = Brushes.Green;
                            break;
                    }
                else
                {
                    switch (answ)
                    {
                        case 0:
                            answer_1.Background = Brushes.Red;
                            break;
                        case 1:
                            answer_2.Background = Brushes.Red;
                            break;
                        case 2:
                            answer_3.Background = Brushes.Red;
                            break;
                        case 3:
                            answer_4.Background = Brushes.Red;
                            break;
                    }
                    f = false;
                    return 42;
                }
            }
            player.Play();
            await System.Threading.Tasks.Task.Delay(4000);
            player.Stop();
            answer_1.Background = new SolidColorBrush(Color.FromArgb(255, 221, 221, 221));
            answer_2.Background = new SolidColorBrush(Color.FromArgb(255, 221, 221, 221));
            answer_3.Background = new SolidColorBrush(Color.FromArgb(255, 221, 221, 221));
            answer_4.Background = new SolidColorBrush(Color.FromArgb(255, 221, 221, 221));
            answer_1.Visibility = Visibility.Visible;
            answer_2.Visibility = Visibility.Visible;
            answer_3.Visibility = Visibility.Visible;
            answer_4.Visibility = Visibility.Visible;
            f = false;

            if (answ != games[game][quest].correctAnswer)
            {
                image.Source = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/gameover.png"));
                image.Visibility = Visibility.Visible;
                await System.Threading.Tasks.Task.Delay(3000);
                n = 0;
                GameStart.Visibility = Visibility.Visible;
                Answer.Visibility = Visibility.Hidden;
                image.Visibility = Visibility.Hidden;
                return 42;
            }

            switch (quest)
            {
                case 0:
                    l_1.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/imcor.bmp")));
                    break;
                case 1:
                    l_2.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/imcor.bmp")));
                    break;
                case 2:
                    l_3.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/imcor.bmp")));
                    break;
                case 3:
                    l_4.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/imcor.bmp")));
                    break;
                case 4:
                    l_5.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/imcor.bmp")));
                    break;
                case 5:
                    l_6.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/imcor.bmp")));
                    break;
                case 6:
                    l_7.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/imcor.bmp")));
                    break;
                case 7:
                    l_8.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/imcor.bmp")));
                    break;
                case 8:
                    l_9.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/imcor.bmp")));
                    break;
                case 9:
                    l_10.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/imcor.bmp")));
                    break;
            }

            if (quest == 9)
            {
                image.Source = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/wingame.png"));
                image.Visibility = Visibility.Visible;
                await System.Threading.Tasks.Task.Delay(3000);
                win.Visibility = Visibility.Visible;
                win.Play();
                await System.Threading.Tasks.Task.Delay(5000);
                win.Visibility = Visibility.Hidden;
                n = 0;
                GameStart.Visibility = Visibility.Visible;
                Answer.Visibility = Visibility.Hidden;
                image.Visibility = Visibility.Hidden;
            }
            else
            {
                if (quest == 4)
                {
                    image.Source = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/halfgame.png"));
                    image.Visibility = Visibility.Visible;
                    await System.Threading.Tasks.Task.Delay(3000);
                    image.Visibility = Visibility.Hidden;
                }
                question.Text = games[game][quest + 1].question;
                answer_1.Content = new TextBlock() { Text = "a) " + games[g][quest + 1].answers[0], TextWrapping = TextWrapping.Wrap };
                answer_2.Content = new TextBlock() { Text = "b) " + games[g][quest + 1].answers[1], TextWrapping = TextWrapping.Wrap };
                answer_3.Content = new TextBlock() { Text = "c) " + games[g][quest + 1].answers[2], TextWrapping = TextWrapping.Wrap };
                answer_4.Content = new TextBlock() { Text = "d) " + games[g][quest + 1].answers[3], TextWrapping = TextWrapping.Wrap };
                n++;
            }
            return 42;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.PreviousSize.Width != 0)
            {
                answer_1.Width += (e.NewSize.Width - e.PreviousSize.Width) / 2;
                answer_2.Width += (e.NewSize.Width - e.PreviousSize.Width) / 2;
                answer_3.Width += (e.NewSize.Width - e.PreviousSize.Width)/ 2;
                answer_4.Width += (e.NewSize.Width - e.PreviousSize.Width) / 2;
                half.RenderTransform = new TranslateTransform(450 + (e.NewSize.Width - 1280) / 7, 80);
                phone.RenderTransform = new TranslateTransform(300 + (e.NewSize.Width - 1280) / 7, 80);
                mistake.RenderTransform = new TranslateTransform(150 + (e.NewSize.Width - 1280) / 7, 80);
                answer_2.RenderTransform = new TranslateTransform(-220 + (e.NewSize.Width - 1280) / 8, -180);
                answer_4.RenderTransform = new TranslateTransform(-220 + (e.NewSize.Width - 1280) / 8, -40);
                question.RenderTransform = new TranslateTransform(40 + (e.NewSize.Width - 1280) / 8, 180 + (e.NewSize.Height - 720) / 8);
                Buttons.Height = 20;
                Buttons.Children.Clear();
                if (games != null)
                    for (int i = 0; i < games.Count; i++)
                        AddBtn(i, (int)(e.NewSize.Width / 126));
            }
        }

        private void AddBtn(int i, int n = 10)
        {
            if (i % n == 0)
                Buttons.Height += 120;
            var btn = new Button
            {
                Name = "B_" + i,
                Content = i + 1,
                Width = 80,
                Height = 80,
                RenderTransformOrigin = new Point(0.5, 0.5),
                VerticalAlignment = VerticalAlignment.Top,
                FontSize = 20,
                BorderThickness = new Thickness(0),
                Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/StartButtons.png"))),
                HorizontalAlignment = HorizontalAlignment.Left,
                RenderTransform = new TranslateTransform
                {
                    X = 40 + (i % n) * 120,
                    Y = 40 + i / n * 120
                }                
            };
            btn.Click += new RoutedEventHandler(Start_Click);            
            Buttons.Children.Add(btn);
        }

        private async System.Threading.Tasks.Task CallAsync()
        {
            player.Open(new Uri("Music/title.mp3", UriKind.Relative));
            player.Play();
            await System.Threading.Tasks.Task.Delay(9000);
            GameStart.Visibility = Visibility.Visible;
            player.Stop();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            answer_1_Click(sender, e);
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            answer_2_Click(sender, e);
        }

        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            answer_3_Click(sender, e);
        }

        private void CommandBinding_Executed_3(object sender, ExecutedRoutedEventArgs e)
        {
            answer_4_Click(sender, e);
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            ChangeChoise f = new ChangeChoise();
            f.ShowDialog();
            if (f.game != -1 && f.question != -1)
                new AddQuestion(f.question, f.game).ShowDialog();
        }
    }
}
