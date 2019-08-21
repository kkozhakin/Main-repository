namespace Sets_RelationsLessons
{
    partial class Reg
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Registration = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Login_label = new System.Windows.Forms.Label();
            this.Login_value = new System.Windows.Forms.TextBox();
            this.Password_value = new System.Windows.Forms.TextBox();
            this.Password_label = new System.Windows.Forms.Label();
            this.Password_value2 = new System.Windows.Forms.TextBox();
            this.Password_ladel2 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // Registration
            // 
            this.Registration.Location = new System.Drawing.Point(10, 238);
            this.Registration.Name = "Registration";
            this.Registration.Size = new System.Drawing.Size(161, 56);
            this.Registration.TabIndex = 0;
            this.Registration.Text = "Зарегистрироваться";
            this.toolTip.SetToolTip(this.Registration, "Вернуться на форму входа в систему с сохранением нового пользователя");
            this.Registration.UseVisualStyleBackColor = true;
            this.Registration.Click += new System.EventHandler(this.Registration_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(177, 238);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(155, 56);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Отмена";
            this.toolTip.SetToolTip(this.Cancel, "Вернуться на форму входа в систему без изменений");
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Login_label
            // 
            this.Login_label.Font = new System.Drawing.Font("Tahoma", 14F);
            this.Login_label.Location = new System.Drawing.Point(12, 12);
            this.Login_label.Margin = new System.Windows.Forms.Padding(3);
            this.Login_label.Name = "Login_label";
            this.Login_label.Size = new System.Drawing.Size(130, 34);
            this.Login_label.TabIndex = 2;
            this.Login_label.Text = "Логин:";
            this.Login_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Login_value
            // 
            this.Login_value.Location = new System.Drawing.Point(91, 52);
            this.Login_value.Name = "Login_value";
            this.Login_value.Size = new System.Drawing.Size(155, 26);
            this.Login_value.TabIndex = 3;
            this.toolTip.SetToolTip(this.Login_value, "Введите несуществующий логин");
            // 
            // Password_value
            // 
            this.Password_value.Location = new System.Drawing.Point(91, 124);
            this.Password_value.Name = "Password_value";
            this.Password_value.Size = new System.Drawing.Size(155, 26);
            this.Password_value.TabIndex = 5;
            this.toolTip.SetToolTip(this.Password_value, "Введите надёжный пароль");
            // 
            // Password_label
            // 
            this.Password_label.Font = new System.Drawing.Font("Tahoma", 14F);
            this.Password_label.Location = new System.Drawing.Point(10, 83);
            this.Password_label.Margin = new System.Windows.Forms.Padding(3);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(130, 34);
            this.Password_label.TabIndex = 4;
            this.Password_label.Text = "Пароль:";
            this.Password_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Password_value2
            // 
            this.Password_value2.Location = new System.Drawing.Point(91, 196);
            this.Password_value2.Name = "Password_value2";
            this.Password_value2.Size = new System.Drawing.Size(155, 26);
            this.Password_value2.TabIndex = 7;
            this.toolTip.SetToolTip(this.Password_value2, "Повторите введённый пароль");
            // 
            // Password_ladel2
            // 
            this.Password_ladel2.Font = new System.Drawing.Font("Tahoma", 14F);
            this.Password_ladel2.Location = new System.Drawing.Point(10, 155);
            this.Password_ladel2.Margin = new System.Windows.Forms.Padding(3);
            this.Password_ladel2.Name = "Password_ladel2";
            this.Password_ladel2.Size = new System.Drawing.Size(236, 34);
            this.Password_ladel2.TabIndex = 6;
            this.Password_ladel2.Text = "Повторите пароль:";
            this.Password_ladel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Reg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 305);
            this.Controls.Add(this.Password_value2);
            this.Controls.Add(this.Password_ladel2);
            this.Controls.Add(this.Password_value);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Login_value);
            this.Controls.Add(this.Login_label);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Registration);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Reg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Reg_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Registration;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label Login_label;
        private System.Windows.Forms.TextBox Login_value;
        private System.Windows.Forms.TextBox Password_value;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.TextBox Password_value2;
        private System.Windows.Forms.Label Password_ladel2;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

