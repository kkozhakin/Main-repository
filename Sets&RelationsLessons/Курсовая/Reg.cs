using MySql.Data.MySqlClient;
using System;
using System.Data.Common;
using System.Windows.Forms;

namespace Sets_RelationsLessons
{
    public partial class Reg : Form
    {
        Login _LogForm;
        MySqlConnection conn;

        public Reg(Login LogForm)
        {
            _LogForm = LogForm;
            InitializeComponent();
            conn = DBUtils.GetDBConnection();
        }
        /// <summary>
        /// Обработчик события нажатия кнопки "Отмена"
        /// </summary>
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Обработчик события нажатия кнопки "Зарегистрироваться"(Создать пользователя)
        /// </summary>
        private void Registration_Click(object sender, EventArgs e)
        {
            int c = 1;
            try
            {
                if (Login_value.Text.Length < 3) throw new Exception("Слишком короткий логин(должен содержать 3 или больше символов).");
                if (Login_value.Text.Length > 15) throw new Exception("Слишком длинный логин(должен содержать 15 или меньше символов).");
                if (Login_value.Text.IndexOf(' ') > -1) throw new Exception("Логин не должен содержать пробелы.");
                if (Password_value.Text.Length < 3) throw new Exception("Слишком короткий пароль(должен содержать 3 или больше символов).");
                if (Password_value.Text.Length > 20) throw new Exception("Слишком длинный пароль(должен содержать 20 или меньше символов).");
                if (Password_value.Text.IndexOf(' ') > -1) throw new Exception("Пароль не должен содержать пробелы.");
                if (Password_value.Text.GetHashCode() != Password_value2.Text.GetHashCode()) throw new Exception("Пароли не совпадают.");

                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("Select idUsers, Login, Password from users", conn))
                {
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                c++;
                                if (Login_value.Text == reader.GetString(reader.GetOrdinal("Login")))
                                    throw new Exception("Этот логин уже занят.");
                            }
                        }
                    }
                }

                using (MySqlCommand cmd = new MySqlCommand("Insert into users(idUsers, Login, Password)" + "values (@id, @login, @password)", conn))
                {
                    MySqlParameter idParam = new MySqlParameter("@id", MySqlDbType.Int32)
                    {
                        Value = c
                    };
                    cmd.Parameters.Add(idParam);

                    MySqlParameter loginParam = new MySqlParameter("@login", MySqlDbType.VarChar)
                    {
                        Value = Login_value.Text
                    };
                    cmd.Parameters.Add(loginParam);

                    MySqlParameter passwordParam = new MySqlParameter("@password", MySqlDbType.Int32)
                    {
                        Value = Password_value.Text.GetHashCode()
                    };
                    cmd.Parameters.Add(passwordParam);

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Регистрация прошла успешно!");

                _LogForm.Show();
                conn.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// Обработчик события закрытия формы
        /// </summary>
        private void Reg_FormClosing(object sender, FormClosingEventArgs e)
        {
            _LogForm.Show();
        }
    }
}
