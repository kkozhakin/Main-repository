using MySql.Data.MySqlClient;
using System;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sets_RelationsLessons
{
    public partial class Results : Form
    {
        MySqlConnection conn;

        public Results()
        {
            InitializeComponent();

            conn = DBUtils.GetDBConnection();
            ResultToTable();
        }
        /// <summary>
        /// Добавление столбца в таблицу результатов
        /// </summary>
        /// <param name="name">название столбца</param>
        private void AddColumn(string name)
        {
            var column = new DataGridViewColumn
            {
                HeaderText = name,
                ReadOnly = true,
                Frozen = false,
                CellTemplate = new DataGridViewTextBoxCell()
            };
            ResultTable.Columns.Add(column);
        }
        /// <summary>
        /// Внесение результатов в таблицу
        /// </summary>
        /// <param name="test">номер теста</param>
        private void ResultToTable(int test = -1)
        {
            ResultTable.Rows.Clear();
            ResultTable.Columns.Clear();
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

                using (MySqlCommand cmd = new MySqlCommand("Select idTests, Result, Users_idUsers, Date, Time from tests", conn))
                {
                    if (test == -1)
                    {
                        AddColumn("Тест");
                        AddColumn("Процент верных ответов (%)");
                        AddColumn("Оценка первой попытки");

                        ResultTable.AllowUserToAddRows = false;
                        string res;
                        for (int i = 0; i < 10; i++)
                        {
                            using (DbDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        if (id == reader.GetInt32(reader.GetOrdinal("Users_idUsers")) && i == reader.GetInt32(reader.GetOrdinal("idTests")))
                                        {
                                            res = reader.GetString(reader.GetOrdinal("Result"));
                                            ResultTable.Rows.Add("Тест " + i, String.Format("{0:0.00}", 1.0 * res.Count(f => f == 't') / res.Length * 100), String.Format("{0:0}", 1.0 * res.Count(f => f == 't') / res.Length * 10));
                                            if (double.Parse(ResultTable[2, ResultTable.Rows.Count - 1].Value.ToString()) >= 8) ResultTable[2, ResultTable.Rows.Count - 1].Style.BackColor = Color.Green;
                                            else if (double.Parse(ResultTable[2, ResultTable.Rows.Count - 1].Value.ToString()) >= 6) ResultTable[2, ResultTable.Rows.Count - 1].Style.BackColor = Color.GreenYellow;
                                            else if (double.Parse(ResultTable[2, ResultTable.Rows.Count - 1].Value.ToString()) >= 4) ResultTable[2, ResultTable.Rows.Count - 1].Style.BackColor = Color.Yellow;
                                            else if (double.Parse(ResultTable[2, ResultTable.Rows.Count - 1].Value.ToString()) >= 1) ResultTable[2, ResultTable.Rows.Count - 1].Style.BackColor = Color.Orange;
                                            else ResultTable[2, ResultTable.Rows.Count - 1].Style.BackColor = Color.Red;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        AddColumn("Тест " + (test + 1));

                        string res;
                        bool f = true;
                        using (DbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    if (id == reader.GetInt32(reader.GetOrdinal("Users_idUsers")) && test + 1 == reader.GetInt32(reader.GetOrdinal("idTests")))
                                    {
                                        res = reader.GetString(reader.GetOrdinal("Result"));
                                        if (f)
                                        {
                                            for (int j = 0; j < res.Length; j++)
                                            {
                                                AddColumn("Вопрос " + (j + 1));
                                            }
                                            f = false;
                                        }
                                        if (ResultTable.Rows.Count == 0)
                                        {
                                            AddColumn("Процент верных ответов (%)");
                                            AddColumn("Оценка");
                                            AddColumn("Время сдачи");
                                            AddColumn("Время выполнения");
                                        }
                                        ResultTable.Rows.Add();
                                        ResultTable[0, ResultTable.Rows.Count - 1].Value = "Попытка " + ResultTable.Rows.Count;
                                        for (int i = 0; i < res.Length; i++)
                                        {
                                            if (res[i] == 't')
                                            {
                                                ResultTable[i + 1, ResultTable.Rows.Count - 1].Value = "+";
                                                ResultTable[i + 1, ResultTable.Rows.Count - 1].Style.BackColor = Color.Green;
                                            }
                                            else
                                            {
                                                ResultTable[i + 1, ResultTable.Rows.Count - 1].Value = "-";
                                                ResultTable[i + 1, ResultTable.Rows.Count - 1].Style.BackColor = Color.Red;
                                            }
                                        }
                                        ResultTable[ResultTable.Columns.Count - 4, ResultTable.Rows.Count - 1].Value = String.Format("{0:0.00}", 1.0 * res.Count(t => t == 't') / res.Length * 100);
                                        ResultTable[ResultTable.Columns.Count - 3, ResultTable.Rows.Count - 1].Value = String.Format("{0:0}", 1.0 * res.Count(t => t == 't') / res.Length * 10);
                                        ResultTable[ResultTable.Columns.Count - 2, ResultTable.Rows.Count - 1].Value = reader.GetDateTime(reader.GetOrdinal("Date"));
                                        ResultTable[ResultTable.Columns.Count - 1, ResultTable.Rows.Count - 1].Value = reader.GetValue(reader.GetOrdinal("Time"));
                                    }
                                }
                            }
                        }
                        ResultTable.AllowUserToAddRows = false;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Соединение отсутствует. Попробуйте переподключиться к Интернету.");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /// <summary>
        /// Метод, для осуществления перехода от таблицы с результатами всех тестов к определённому с результатами попыток его решения
        /// </summary>
        private void ResultTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    if (ResultTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Split()[0] == "Тест")
                        ResultToTable(int.Parse(ResultTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Split()[1]) - 1);
                }
                catch
                {
                    ResultToTable();
                }
            }
        }
    }
}
