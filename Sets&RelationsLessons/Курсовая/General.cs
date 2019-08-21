using System;
using System.IO;
using System.Windows.Forms;

namespace Sets_RelationsLessons
{
    public partial class General : Form
    {
        public General()
        {
            InitializeComponent();
            this.Text = "Добро пожаловать, " + Properties.Settings.Default.login;
            TextArea.ScriptErrorsSuppressed = true;
            for (int i = 1; i <= 10; i++)
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"\Lessons\lesson" + i + ".html"))
                    выборТемыToolStripMenuItem.DropDownItems[i - 1].Visible = true;
                else
                    выборТемыToolStripMenuItem.DropDownItems[i - 1].Visible = false;
            }
        }
        /// <summary>
        /// Обработчик события нажатия на пункт меню "Изменить персонльные данные"
        /// </summary>
        private void изменитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeInfo form = new ChangeInfo(this);
            form.Show();
        }
        /// <summary>
        /// Обработчик события завершения загрузки html-документа
        /// </summary>
        private void TextArea_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            foreach (HtmlElement he in TextArea.Document.GetElementsByTagName("input"))
            {
                switch (he.GetAttribute("name"))
                {
                    case "Next":
                        he.AttachEventHandler("onclick", Next_Click);
                        break;
                    case "Previous":
                        he.AttachEventHandler("onclick", Previous_Click);
                        break;
                    case "StartTest":
                        he.AttachEventHandler("onclick", StartTest_Click);
                        break;
                    case "ContinueTest":
                        he.AttachEventHandler("onclick", ContinueTest_Click);
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Обработчик события нажатия кнопки "Следующий урок"
        /// </summary>
        private void Next_Click(object sender, EventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Lessons\lesson" + (int.Parse(TextArea.DocumentTitle.Split()[1]) + 1) + ".html"))
                TextArea.Navigate(Directory.GetCurrentDirectory() + @"\Lessons\lesson" + (int.Parse(TextArea.DocumentTitle.Split()[1]) + 1) + ".html");
        }
        /// <summary>
        /// Обработчик события нажатия кнопки "Предыдущий урок"
        /// </summary>
        private void Previous_Click(object sender, EventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Lessons\lesson" + (int.Parse(TextArea.DocumentTitle.Split()[1]) - 1) + ".html"))
                TextArea.Navigate(Directory.GetCurrentDirectory() + @"\Lessons\lesson" + (int.Parse(TextArea.DocumentTitle.Split()[1]) - 1) + ".html");
        }
        /// <summary>
        /// Обработчик события нажатия кнопки "Начать тест"
        /// </summary>
        private void StartTest_Click(object sender, EventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Lessons\test" + int.Parse(TextArea.DocumentTitle.Split()[1]) + ".txt"))
            {
                this.Hide();
                TestForm form = new TestForm(Directory.GetCurrentDirectory() + @"\Lessons\test" + int.Parse(TextArea.DocumentTitle.Split()[1]) + ".txt");
                if (form.IsDisposed == false) form.Show();
            }            
        }
        /// <summary>
        /// Обработчик события нажатия кнопки "Продолжить тест"
        /// </summary>
        private void ContinueTest_Click(object sender, EventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Lessons\test" + int.Parse(TextArea.DocumentTitle.Split()[1]) + ".txt"))
            {
                this.Hide();
                TestForm form = new TestForm(Directory.GetCurrentDirectory() + @"\Lessons\test" + int.Parse(TextArea.DocumentTitle.Split()[1]) + ".txt", 1);
                if (form.IsDisposed == false) form.Show();
            }
        }
        /// <summary>
        /// Обработчик события нажатия на пункт меню "Сменить пользователя"
        /// </summary>
        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выйти?", "Смена пользователя", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                Login log = new Login();
                log.Show();
                this.Hide();
                Properties.Settings.Default.login = "";
                Properties.Settings.Default.Save();
            }
        }
        /// <summary>
        /// Обработчик события нажатия на пункт меню "Результаты тестов"
        /// </summary>
        private void результатыТестовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Results res = new Results();
            res.Show();
        }
        /// <summary>
        /// Обработчик события нажатия на пункт меню "Урок 1"
        /// </summary>
        private void урок1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.Navigate(Directory.GetCurrentDirectory() + @"\Lessons\lesson1.html");
        }
        /// <summary>
        /// Обработчик события нажатия на пункт меню "Урок 2"
        /// </summary>
        private void урок2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.Navigate(Directory.GetCurrentDirectory() + @"\Lessons\lesson2.html");
        }
        /// <summary>
        /// Обработчик события нажатия на пункт меню "Урок 3"
        /// </summary>
        private void урок3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.Navigate(Directory.GetCurrentDirectory() + @"\Lessons\lesson3.html");
        }
        /// <summary>
        /// Обработчик события нажатия на пункт меню "Урок 4"
        /// </summary>
        private void урок4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.Navigate(Directory.GetCurrentDirectory() + @"\Lessons\lesson4.html");
        }
        /// <summary>
        /// Обработчик события нажатия на пункт меню "Урок 5"
        /// </summary>
        private void урок5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.Navigate(Directory.GetCurrentDirectory() + @"\Lessons\lesson5.html");
        }
        /// <summary>
        /// Обработчик события нажатия на пункт меню "Урок 6"
        /// </summary>
        private void урок6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.Navigate(Directory.GetCurrentDirectory() + @"\Lessons\lesson6.html");
        }
        /// <summary>
        /// Обработчик события нажатия на пункт меню "Урок 7"
        /// </summary>
        private void урок7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.Navigate(Directory.GetCurrentDirectory() + @"\Lessons\lesson7.html");
        }
        /// <summary>
        /// Обработчик события нажатия на пункт меню "Урок 8"
        /// </summary>
        private void урок8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.Navigate(Directory.GetCurrentDirectory() + @"\Lessons\lesson8.html");
        }
        /// <summary>
        /// Обработчик события нажатия на пункт меню "Урок 9"
        /// </summary>
        private void урок9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.Navigate(Directory.GetCurrentDirectory() + @"\Lessons\lesson9.html");
        }
        /// <summary>
        /// Обработчик события нажатия на пункт меню "Урок 10"
        /// </summary>
        private void урок10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.Navigate(Directory.GetCurrentDirectory() + @"\Lessons\lesson10.html");
        }
        /// <summary>
        /// Обработчик события нажатия на пункт меню "Выход"
        /// </summary>
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Обработчик события закрытия формы
        /// </summary>
        private void General_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason.ToString() == "UserClosing")
            {
                DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    foreach (string name in Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Lessons\", "tmp*"))
                    {
                        File.Delete(name);
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
