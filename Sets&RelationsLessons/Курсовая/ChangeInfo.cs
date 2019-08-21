using MySql.Data.MySqlClient;
using System;
using System.Data.Common;
using System.Windows.Forms;

namespace Sets_RelationsLessons
{
    public partial class ChangeInfo : Form
    {
        MySqlConnection conn;
        General _GenForm;

        public ChangeInfo(General GenForm)
        {
            _GenForm = GenForm;
            InitializeComponent();
            conn = DBUtils.GetDBConnection();
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку "Отмена"
        /// </summary>
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку "Изменить"
        /// </summary>
        private void Change_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                conn.Open();
                if (Login_value.Text.Length < 3) throw new Exception("Слишком короткий логин(должен содержать 3 или больше символов).");
                if (Login_value.Text.Length > 15) throw new Exception("Слишком длинный логин(должен содержать 15 или меньше символов).");
                if (Login_value.Text.IndexOf(' ') > -1) throw new Exception("Логин не должен содержать пробелы.");
                if (Password_value2.Text.Length < 3) throw new Exception("Слишком короткий пароль(должен содержать 3 или больше символов).");
                if (Password_value2.Text.Length > 20) throw new Exception("Слишком длинный пароль(должен содержать 20 или меньше символов).");
                if (Password_value2.Text.IndexOf(' ') > -1) throw new Exception("Пароль не должен содержать пробелы.");

                using (MySqlCommand cmd = new MySqlCommand("Select idUsers, Login, Password from users", conn))
                {
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (Properties.Settings.Default.login == reader.GetString(reader.GetOrdinal("Login")))
                                    if (Password_value.Text.GetHashCode().ToString() != reader.GetString(reader.GetOrdinal("Password")))
                                        throw new Exception("Неверный пароль.");
                                    else id = reader.GetInt32(reader.GetOrdinal("idUsers"));
                                if (Login_value.Text == reader.GetString(reader.GetOrdinal("Login")))
                                    throw new Exception("Этот логин уже занят.");
                            }
                        }
                    }
                }

                using (MySqlCommand cmd = new MySqlCommand("Update users set Login = @login, Password = @password where idUsers = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@login", Login_value.Text);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@password", Password_value2.Text.GetHashCode());

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Изменения успешно сохранены!");
                
                Properties.Settings.Default.login = Login_value.Text;
                Properties.Settings.Default.Save();
                _GenForm.Text = "Добро пожаловать, " + Login_value.Text;
                _GenForm.Show();
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
        private void ChangeInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _GenForm.Show();
        }
    }
}
