using MySql.Data.MySqlClient;
using System;
using System.Data.Common;
using System.IO;
using System.Windows.Forms;

namespace Sets_RelationsLessons
{
    public partial class Login : Form
    {
        MySqlConnection conn;

        public Login()
        {
            InitializeComponent();
            conn = DBUtils.GetDBConnection();
            if (Application.OpenForms.Count > 10)
            {
                Application.Restart();
            }
        }
        /// <summary>
        /// Обработчик события нажатия кнопки "Зарегистрироваться"(Перейти на форму регистрации)
        /// </summary>
        private void Registration_Click(object sender, EventArgs e)
        {
            Reg _RegForm = new Reg(this);
            _RegForm.Show();
            this.Hide();
        }
        /// <summary>
        /// Обработчик события нажатия кнопки "Вход"
        /// </summary>
        private void Start_Click(object sender, EventArgs e)
        {
            bool flag = false;
            try
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("Select idUsers, Login, Password from users", conn))
                {
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (Login_value.Text == reader.GetString(reader.GetOrdinal("Login")))
                                    if (Password_value.Text.GetHashCode().ToString() == reader.GetString(reader.GetOrdinal("Password")))
                                    {
                                        Properties.Settings.Default.login = Login_value.Text;
                                        Properties.Settings.Default.Save();
                                        General _GeneralForm = new General();
                                        _GeneralForm.Show();
                                        this.Hide();
                                        flag = true;
                                        break;
                                    }
                                    else
                                        throw new Exception("Неверный пароль.");
                            }
                            if (!flag) throw new Exception("Такой логин не существует.");
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
        /// Обработчик события закрытия формы
        /// </summary>
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(string name in Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Lessons\", "tmp*"))
            {
                File.Delete(name);
            }
        }
    }
}
