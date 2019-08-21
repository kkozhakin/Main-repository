using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Sets_RelationsLessons
{
   
    public partial class TestForm : Form
    {
        Test test;
        string[] answers;
        string ans;
        bool EdgeAuto = true;
        MySqlConnection conn;
        DateTime time = new DateTime(0,0);

        public TestForm(string testname, int t = 0)
        {
            InitializeComponent();
            автоToolStripMenuItem.BackColor = Color.Aqua;
            conn = DBUtils.GetDBConnection();
            DrawingGraph.Location = new Point(this.Width / 2 + 1, 39);

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Test));
                using (FileStream fs = new FileStream(testname, FileMode.Open))
                {
                    test = (Test)serializer.Deserialize(fs);
                }
                for (int i = 0; i < test.tasks.Length; i++)
                {
                    if (File.Exists(Directory.GetCurrentDirectory() + @"\Lessons\" + test.tasks[i].graph_name)) test.tasks[i].graph_name = Directory.GetCurrentDirectory() + @"\Lessons\" + test.tasks[i].graph_name;
                    else
                    {
                        MessageBox.Show("Файл " + test.tasks[i].graph_name + " не найден!");
                        test.tasks[i].graph_name = "";
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
                return;
            }

            answers = new string[test.tasks.Length];
            if (t == 1) LoadAns();

            int id = 0;
            try
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("Select idUsers, Login from users", conn))
                {
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (Properties.Settings.Default.login == reader.GetString(reader.GetOrdinal("Login"))) id = reader.GetInt32(reader.GetOrdinal("idUsers"));
                            }
                        }
                    }
                }

                using (MySqlCommand cmd = new MySqlCommand("Delete from files where idTest = @test and Users_idUsers = @id", conn))
                {
                    cmd.Parameters.Add(new MySqlParameter { ParameterName = "@id", MySqlDbType = MySqlDbType.Int32, Value = id });
                    cmd.Parameters.Add(new MySqlParameter { ParameterName = "@test", MySqlDbType = MySqlDbType.Int32, Value = test.id });

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
           
            timer.Start();
            StartTask(0);
        }
        /// <summary>
        /// Метод инициализации задания
        /// </summary>
        /// <param name="num">номер задания</param>
        /// <param name="status">текущий статус</param>
        private void StartTask(int num, int status = 0)
        {
            if (num == 0) previous.Enabled = false;
            else previous.Enabled = true;
            if (num == test.tasks.Length - 1) next.Enabled = false;
            else next.Enabled = true;
            Condition.Text = test.tasks[num].condition;
            if (status == 0) this.Text = "Вопрос " + (num + 1) + " Время: " + time.ToLongTimeString();
            else this.Text = "Вопрос " + (num + 1);
            if (status == 1)
                if (ans != null && ans[num] == 't')
                {
                    this.Text += "  -  Верно";
                    this.BackColor = Color.Green;
                }
            else
                {
                    this.Text += "  -  Неверно";
                    this.BackColor = Color.Red;
                }

            try {
                switch (test.tasks[num].choice_ans)
                {
                    case 1:
                        oneGraph.Child = null;
                        if (test.tasks[num].graph_name != "") oneGraph.Child = new GraphLayout(ref test, num, "oneGraph", EdgeAuto);
                        pictureBox.Visible = false;
                        oneGraph.Visible = true;
                        PictureGraph.Visible = false;
                        DrawingGraph.Visible = false;
                        ChooseOneAnsPanel.Visible = true;
                        ChooseSomeAnsPanel.Visible = false;
                        WriteAnsPanel.Visible = false;
                        ChooseOneAnsPanel.Items.Clear();
                        foreach (string ans in test.tasks[num].choices)
                        {
                            ChooseOneAnsPanel.Items.Add(ans);
                        }
                        if (status == 1)
                        {
                            for (int i = 0; i < ChooseOneAnsPanel.Items.Count; i++)
                            {
                                if (ChooseOneAnsPanel.GetItemChecked(i)) ChooseOneAnsPanel.SetItemChecked(i, false);
                            }
                            for (int i = 0; i < test.tasks[num].answer.Length; i++)
                            {
                                ChooseOneAnsPanel.SetItemChecked(int.Parse(test.tasks[num].answer[i].ToString()) - 1, true);
                            }
                        } else if (answers[num] != null)
                        {
                            for (int i = 0; i < answers[num].Length; i++)
                            {
                                ChooseOneAnsPanel.SetItemChecked(int.Parse(answers[num][i].ToString()) - 1, true);
                            }
                        }
                        break;
                    case 2:
                        oneGraph.Child = null;
                        if (test.tasks[num].graph_name != "") oneGraph.Child = new GraphLayout(ref test, num, "oneGraph", EdgeAuto);
                        pictureBox.Visible = false;
                        oneGraph.Visible = true;
                        PictureGraph.Visible = false;
                        DrawingGraph.Visible = false;
                        ChooseOneAnsPanel.Visible = false;
                        ChooseSomeAnsPanel.Visible = true;
                        WriteAnsPanel.Visible = false;
                        ChooseSomeAnsPanel.Items.Clear();
                        foreach (string ans in test.tasks[num].choices)
                        {
                            ChooseSomeAnsPanel.Items.Add(ans);
                        }
                        if (status == 1)
                        {
                            for (int i = 0; i < ChooseSomeAnsPanel.Items.Count; i++)
                            {
                                if (ChooseSomeAnsPanel.GetItemChecked(i)) ChooseSomeAnsPanel.SetItemChecked(i, false);
                            }
                            for (int i = 0; i < test.tasks[num].answer.Length; i++)
                            {
                                ChooseSomeAnsPanel.SetItemChecked(int.Parse(test.tasks[num].answer[i].ToString()) - 1, true);
                            }
                        }
                        else if (answers[num] != null)
                        {
                            for (int i = 0; i < answers[num].Length; i++)
                            {
                                ChooseSomeAnsPanel.SetItemChecked(int.Parse(answers[num][i].ToString()) - 1, true);
                            }
                        }
                        break;
                    case 3:
                        oneGraph.Child = null;
                        if (test.tasks[num].graph_name != "") oneGraph.Child = new GraphLayout(ref test, num, "oneGraph", EdgeAuto);
                        pictureBox.Visible = false;
                        oneGraph.Visible = true;
                        PictureGraph.Visible = false;
                        DrawingGraph.Visible = false;
                        ChooseOneAnsPanel.Visible = false;
                        ChooseSomeAnsPanel.Visible = false;
                        WriteAnsPanel.Visible = true;
                        WriteAnsPanel.Clear();
                        WriteAnsPanel.Text = answers[num] ?? "";
                        if (status == 1) WriteAnsPanel.Text = test.tasks[num].answer;
                        break;
                    case 4:
                        DrawingGraph.Child = null;
                        if (test.tasks[num].graph_name != "")
                        {
                            if (status == 1)
                                DrawingGraph.Child = new GraphLayout(ref test, num, "true", EdgeAuto);
                            else if (answers[num] != null)
                                DrawingGraph.Child = new GraphLayout(ref test, num, "ans", EdgeAuto);
                            else
                                DrawingGraph.Child = new GraphLayout(ref test, num, "DrawingGraph", EdgeAuto);
                            PictureGraph.Child = new GraphLayout(ref test, num, "PictureGraph", EdgeAuto);
                        }
                        pictureBox.Visible = false;
                        oneGraph.Visible = false;
                        PictureGraph.Visible = true;
                        DrawingGraph.Visible = true;
                        ChooseOneAnsPanel.Visible = false;
                        ChooseSomeAnsPanel.Visible = false;
                        WriteAnsPanel.Visible = false;
                        break;
                    case 5:
                        if (test.tasks[num].graph_name != "") pictureBox.Image = Image.FromFile(test.tasks[num].graph_name);
                        pictureBox.Visible = true;
                        oneGraph.Visible = false;
                        PictureGraph.Visible = false;
                        DrawingGraph.Visible = false;
                        ChooseOneAnsPanel.Visible = true;
                        ChooseSomeAnsPanel.Visible = false;
                        WriteAnsPanel.Visible = false;
                        ChooseOneAnsPanel.Items.Clear();
                        foreach (string ans in test.tasks[num].choices)
                        {
                            ChooseOneAnsPanel.Items.Add(ans);
                        }
                        if (status == 1)
                        {
                            for (int i = 0; i < ChooseOneAnsPanel.Items.Count; i++)
                            {
                                if (ChooseOneAnsPanel.GetItemChecked(i)) ChooseOneAnsPanel.SetItemChecked(i, false);
                            }
                            for (int i = 0; i < test.tasks[num].answer.Length; i++)
                            {
                                ChooseOneAnsPanel.SetItemChecked(int.Parse(test.tasks[num].answer[i].ToString()) - 1, true);
                            }
                        } else if (answers[num] != null)
                        {
                            for (int i = 0; i < answers[num].Length; i++)
                            {
                                ChooseOneAnsPanel.SetItemChecked(int.Parse(answers[num][i].ToString()) - 1, true);
                            }
                        }
                        break;
                    case 6:
                        if (test.tasks[num].graph_name != "") pictureBox.Image = Image.FromFile(test.tasks[num].graph_name);
                        pictureBox.Visible = true;
                        oneGraph.Visible = false;
                        PictureGraph.Visible = false;
                        DrawingGraph.Visible = false;
                        ChooseOneAnsPanel.Visible = false;
                        ChooseSomeAnsPanel.Visible = true;
                        WriteAnsPanel.Visible = false;
                        ChooseSomeAnsPanel.Items.Clear();
                        foreach (string ans in test.tasks[num].choices)
                        {
                            ChooseSomeAnsPanel.Items.Add(ans);
                        }
                        if (status == 1)
                        {
                            for (int i = 0; i < ChooseSomeAnsPanel.Items.Count; i++)
                            {
                                if (ChooseSomeAnsPanel.GetItemChecked(i)) ChooseSomeAnsPanel.SetItemChecked(i, false);
                            }
                            for (int i = 0; i < test.tasks[num].answer.Length; i++)
                            {
                                ChooseSomeAnsPanel.SetItemChecked(int.Parse(test.tasks[num].answer[i].ToString()) - 1, true);
                            }
                        }
                        else if (answers[num] != null)
                        {
                            for (int i = 0; i < answers[num].Length; i++)
                            {
                                ChooseSomeAnsPanel.SetItemChecked(int.Parse(answers[num][i].ToString()) - 1, true);
                            }
                        }
                        break;
                    case 7:
                        if (test.tasks[num].graph_name != "") pictureBox.Image = Image.FromFile(test.tasks[num].graph_name);
                        pictureBox.Visible = true;
                        oneGraph.Visible = false;
                        PictureGraph.Visible = false;
                        DrawingGraph.Visible = false;
                        ChooseOneAnsPanel.Visible = false;
                        ChooseSomeAnsPanel.Visible = false;
                        WriteAnsPanel.Visible = true;
                        WriteAnsPanel.Clear();
                        WriteAnsPanel.Text = answers[num] ?? "";
                        if (status == 1) WriteAnsPanel.Text = test.tasks[num].answer;
                        break;
                    default:
                        if (test.tasks[num].graph_name != "")
                        {
                            if (status == 1)
                                oneGraph.Child = new GraphLayout(ref test, num, "true", EdgeAuto);
                            else if (answers[num] != null)
                                oneGraph.Child = new GraphLayout(ref test, num, "ans", EdgeAuto);
                            else
                                oneGraph.Child = new GraphLayout(ref test, num, "oneGraph", EdgeAuto);
                        }
                        pictureBox.Visible = false;
                        ChooseOneAnsPanel.Visible = false;
                        ChooseSomeAnsPanel.Visible = false;
                        WriteAnsPanel.Visible = false;
                        oneGraph.Visible = true;
                        PictureGraph.Visible = false;
                        DrawingGraph.Visible = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Обработчик события нажатия кнопки "Сохранить результат"
        /// </summary>
        private void SaveAns_Click(object sender, EventArgs e)
        {
            timer.Stop();
            SaveThisAnswer();
            int id = 0;
            try
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("Select idUsers, Login from users", conn))
                {
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (Properties.Settings.Default.login == reader.GetString(reader.GetOrdinal("Login"))) id = reader.GetInt32(reader.GetOrdinal("idUsers"));
                            }
                        }
                    }
                }

                for (int i = 0; i < answers.Length; i++)
                {
                    if (answers[i] != null)
                    {
                        using (MySqlCommand cmd = new MySqlCommand("Insert into files(idTest, idTask, File, Users_idUsers) " + " values(@idTest, @idTask, @file, @id)", conn))
                        {
                            cmd.Parameters.Add(new MySqlParameter("@idTest", SqlDbType.Int));
                            cmd.Parameters["@idTest"].Value = test.id;
                            cmd.Parameters.Add(new MySqlParameter("@idTask", SqlDbType.Int));
                            cmd.Parameters["@idTask"].Value = i;
                            cmd.Parameters.Add(new MySqlParameter("@file", MySqlDbType.LongText));
                            if (answers[i] == (@"Lessons\tmpGraph" + i))
                            {
                                FileInfo file = new FileInfo(Directory.GetCurrentDirectory() + @"\Lessons\tmpGraph" + i);
                                if (file.Length <= 1050000)
                                    using (StreamReader sr = new StreamReader(new FileStream(Directory.GetCurrentDirectory() + @"\Lessons\tmpGraph" + i, FileMode.Open, FileAccess.Read)))
                                    {
                                        cmd.Parameters["@file"].Value = sr.ReadToEnd();
                                    }
                                File.Delete(Directory.GetCurrentDirectory() + @"\Lessons\tmpGraph" + i);
                            }
                            else
                            {
                                cmd.Parameters["@file"].Value = answers[i];
                            }
                            cmd.Parameters.Add(new MySqlParameter("@id", SqlDbType.Int));
                            cmd.Parameters["@id"].Value = id;

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /// <summary>
        /// Загружает ответы пользователя из базы данных
        /// </summary>
        public void LoadAns()
        {
            int id = 0;
            try
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("Select idUsers, Login from users", conn))
                {
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (Properties.Settings.Default.login == reader.GetString(reader.GetOrdinal("Login"))) id = reader.GetInt32(reader.GetOrdinal("idUsers"));
                            }
                        }
                    }
                }

                using (MySqlCommand cmd = new MySqlCommand("Select idTest, idTask, File, Users_idUsers from files", conn))
                {
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (id == reader.GetInt32(reader.GetOrdinal("Users_idUsers")) && test.id == reader.GetInt32(reader.GetOrdinal("idTest")))
                                    if (test.tasks[reader.GetInt32(reader.GetOrdinal("idTask"))].choice_ans % 4 != 0) answers[reader.GetInt32(reader.GetOrdinal("idTask"))] = reader.GetString(reader.GetOrdinal("File"));
                                    else
                                    {
                                        answers[reader.GetInt32(reader.GetOrdinal("idTask"))] = @"Lessons\tmpGraph" + reader.GetInt32(reader.GetOrdinal("idTask"));
                                        using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + @"\Lessons\tmpGraph" + reader.GetInt32(reader.GetOrdinal("idTask")), FileMode.Create, FileAccess.Write))
                                        {
                                            using (StreamWriter sw = new StreamWriter(fs))
                                            {
                                                sw.WriteLine(reader.GetString(reader.GetOrdinal("File")));
                                            }
                                        }
                                    }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /// <summary>
        /// Обработчик события нажатия кнопки ">" (следующий вопрос)
        /// </summary>
        private void next_Click(object sender, EventArgs e)
        {
            if (ShowAns.Enabled == true)
            {
                if (ShowAns.Visible == false) SaveThisAnswer();
                StartTask(int.Parse(this.Text.Split()[1]));
            }
            else
                StartTask(int.Parse(this.Text.Split()[1]), 1);
        }
        /// <summary>
        /// Обработчик события нажатия кнопки "<" (предыдущий вопрос)
        /// </summary>
        private void previous_Click(object sender, EventArgs e)
        {
            if (ShowAns.Enabled == true)
            {
                if (ShowAns.Visible == false) SaveThisAnswer();
                StartTask(int.Parse(this.Text.Split()[1]) - 2);
            }
            else
                StartTask(int.Parse(this.Text.Split()[1]) - 2, 1);
        }
        /// <summary>
        /// Обработчик события нажатия кнопки "Ответить"
        /// </summary>
        private void answer_Click(object sender, EventArgs e)
        {
            timer.Stop();
            SaveThisAnswer();
            ans = "";
            Answer.Visible = false;
            SaveAns.Visible = false;
            Repeat.Visible = true;
            ShowAns.Visible = true;
            ChooseSomeAnsPanel.Enabled = false;
            ChooseOneAnsPanel.Enabled = false;
            WriteAnsPanel.Enabled = false;
            oneGraph.Enabled = false;
            DrawingGraph.Enabled = false;
            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i] == test.tasks[i].answer) ans += "t";
                else if (answers[i] == (@"Lessons\tmpGraph" + i))
                {
                    if (Compare(test.tasks[i].GetGraph(Directory.GetCurrentDirectory() + @"\Lessons\" + test.tasks[i].answer), test.tasks[i].GetGraph(Directory.GetCurrentDirectory() + @"\Lessons\tmpGraph" + i)))
                        ans += "t";
                    else ans += "f";
                }
                else ans += "f";
            }

            int id = 0;
            try
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("Select idUsers, Login from users", conn))
                {
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (Properties.Settings.Default.login == reader.GetString(reader.GetOrdinal("Login"))) id = reader.GetInt32(reader.GetOrdinal("idUsers"));
                            }
                        }
                    }
                }
                using (MySqlCommand cmd = new MySqlCommand("Insert into tests(idTests, Result, Users_idUsers, Date, Time) " + " values(@idTests, @result, @id, @date, @time)", conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@idTests", SqlDbType.Int));
                    cmd.Parameters["@idTests"].Value = test.id;
                    cmd.Parameters.Add(new MySqlParameter("@result", MySqlDbType.VarChar));
                    cmd.Parameters["@result"].Value = ans;
                    cmd.Parameters.Add(new MySqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Value = id;
                    cmd.Parameters.Add(new MySqlParameter("@date", MySqlDbType.DateTime));
                    cmd.Parameters["@date"].Value = DateTime.Now;
                    cmd.Parameters.Add(new MySqlParameter("@time", MySqlDbType.Time));
                    cmd.Parameters["@time"].Value = time.TimeOfDay;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Результат не сохранен!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /// <summary>
        /// Очистка выбранных пунктов при выборе нового
        /// </summary>
        private void ChooseOneAnsPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ChooseOneAnsPanel.Items.Count; i++)
                if (i != ChooseOneAnsPanel.SelectedIndex) ChooseOneAnsPanel.SetItemChecked(i, false);
        }
        /// <summary>
        /// Сравнение двух графов
        /// </summary>
        /// <param name="x">первый граф</param>
        /// <param name="y">второй граф</param>
        /// <returns>равны ли графы</returns>
        private bool Compare(Graph x, Graph y)
        {
            if (x.edges.Count != y.edges.Count) return false;
            else
            {
                bool f;
                int j;
                List<int> ed = new List<int> { };
                for (int i = 0; i < x.edges.Count; i++)
                {
                    f = false;
                    j = 0;
                    while (!f & j < y.edges.Count)
                    {
                        if (!ed.Contains(j) && x.edges[i].OId.Id == y.edges[j].OId.Id &&
                            x.edges[i].DId.Id == y.edges[j].DId.Id) f = true;
                        else j++;
                    }
                    if (j == y.edges.Count) return false;
                    ed.Add(j);
                }
                if (ed.Count == x.edges.Count) return true;
                else return false;
            }
        }
        /// <summary>
        /// Сохраняет ответ на текущий вопрос
        /// </summary>
        public void SaveThisAnswer()
        {
            int num = int.Parse(this.Text.Split()[1]) - 1;
            switch (test.tasks[num].choice_ans)
            {
                case 1:
                    string ans = "";
                    foreach (int i in ChooseOneAnsPanel.CheckedIndices) { ans += (i + 1); }
                    if (ChooseOneAnsPanel.CheckedItems != null) answers[num] = ans;
                    break;
                case 2:
                    ans = "";
                    foreach (int i in ChooseSomeAnsPanel.CheckedIndices) { ans += (i + 1); }
                    if (ChooseSomeAnsPanel.CheckedItems != null) answers[num] = ans;
                    break;
                case 3:
                    if (WriteAnsPanel.Text != null) answers[num] = WriteAnsPanel.Text;
                    break;
                case 4:
                    DrawingGraph.Enabled = false;
                    DrawingGraph.Enabled = true;
                    answers[num] = @"Lessons\tmpGraph" + num;
                    break;
                case 5:
                    ans = "";
                    foreach (int i in ChooseOneAnsPanel.CheckedIndices) { ans += (i + 1); }
                    if (ChooseOneAnsPanel.CheckedItems != null) answers[num] = ans;
                    break;
                case 6:
                    ans = "";
                    foreach (int i in ChooseSomeAnsPanel.CheckedIndices) { ans += (i + 1); }
                    if (ChooseSomeAnsPanel.CheckedItems != null) answers[num] = ans;
                    break;
                case 7:
                    if (WriteAnsPanel.Text != null) answers[num] = WriteAnsPanel.Text;
                    break;
                default:

                    oneGraph.Enabled = false;
                    oneGraph.Enabled = true;
                    answers[num] = @"Lessons\tmpGraph" + num;
                    break;
            }
        }
        /// <summary>
        /// Обработчик события нажатия кнопки "Повторить тест"
        /// </summary>
        private void Repeat_Click(object sender, EventArgs e)
        {
            this.BackColor = DefaultBackColor;
            ChooseSomeAnsPanel.Enabled = true;
            ChooseOneAnsPanel.Enabled = true;
            WriteAnsPanel.Enabled = true;
            oneGraph.Enabled = true;
            DrawingGraph.Enabled = true;
            Repeat.Visible = false;
            ShowAns.Visible = false;
            answers = new string[test.tasks.Length];
            Answer.Visible = true;
            SaveAns.Visible = true;
            time = new DateTime(0, 0);
            timer.Start();
            StartTask(0);           
        }
        /// <summary>
        /// Обработчик события нажатия кнопки "Показать ответы"
        /// </summary>
        private void ShowAns_Click(object sender, EventArgs e)
        {
            ShowAns.Enabled = false;
            StartTask(0, 1);
        }
        /// <summary>
        /// Обработчик события закрытия формы
        /// </summary>
        private void TestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason.ToString() == "UserClosing")
            {
                DialogResult dialogResult = MessageBox.Show("Все несохраненные ответы не будут учтены! Вы точно хотите прервать тест?", "Выход", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    Application.Restart();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        /// <summary>
        /// Обработчик события изменения размера формы
        /// </summary>
        private void TestForm_SizeChanged(object sender, EventArgs e)
        {
            DrawingGraph.Location = new Point(this.Width / 2 + 1, 39);
            DrawingGraph.Size = new Size(5 * this.Width / 14, this.Height / 2 - 20);
            PictureGraph.Size = new Size(5 * this.Width / 14, this.Height / 2 - 20);
        }
        /// <summary>
        /// Такт таймера
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            time = time.AddSeconds(1);
            this.Text = this.Text.Substring(0, this.Text.Length - 7) + time.ToLongTimeString();
        }
        /// <summary>
        /// Открывает окно помощи по тесту
        /// </summary>
        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Stop();
            webBrowser.Navigate(Directory.GetCurrentDirectory() + @"\Lessons\help.html");
            webBrowser.Visible = true;
            вернутьсяКТестуToolStripMenuItem.Visible = true;
            помощьToolStripMenuItem.Visible = false;
            форматРёберToolStripMenuItem.Visible = false;
            next.Visible = false;
            previous.Visible = false;
        }
        /// <summary>
        /// Возобновляет тест
        /// </summary
        private void вернутьсяКТестуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser.Visible = false;
            вернутьсяКТестуToolStripMenuItem.Visible = false;
            помощьToolStripMenuItem.Visible = true;
            форматРёберToolStripMenuItem.Visible = true;
            next.Visible = true;
            previous.Visible = true;
            timer.Start();
        }
        /// <summary>
        /// Делает ребра графа прямыми
        /// </summary>
        private void прямыеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EdgeAuto = false;
            автоToolStripMenuItem.BackColor = прямыеToolStripMenuItem.BackColor;
            прямыеToolStripMenuItem.BackColor = Color.Aqua;
        }
        /// <summary>
        /// Делает ребра графа автовыстраиваемыми
        /// </summary>
        private void автоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EdgeAuto = true;
            прямыеToolStripMenuItem.BackColor = автоToolStripMenuItem.BackColor;
            автоToolStripMenuItem.BackColor = Color.Aqua;
        }
    }
}
