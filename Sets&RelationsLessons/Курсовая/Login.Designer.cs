namespace Sets_RelationsLessons
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Password_value = new System.Windows.Forms.TextBox();
            this.Password_label = new System.Windows.Forms.Label();
            this.Login_value = new System.Windows.Forms.TextBox();
            this.Login_label = new System.Windows.Forms.Label();
            this.Registration = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // Password_value
            // 
            this.Password_value.Location = new System.Drawing.Point(91, 120);
            this.Password_value.Name = "Password_value";
            this.Password_value.Size = new System.Drawing.Size(155, 26);
            this.Password_value.TabIndex = 11;
            this.toolTip.SetToolTip(this.Password_value, "Введите пароль");
            // 
            // Password_label
            // 
            this.Password_label.Font = new System.Drawing.Font("Tahoma", 14F);
            this.Password_label.Location = new System.Drawing.Point(10, 80);
            this.Password_label.Margin = new System.Windows.Forms.Padding(3);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(130, 34);
            this.Password_label.TabIndex = 10;
            this.Password_label.Text = "Пароль:";
            this.Password_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Login_value
            // 
            this.Login_value.Location = new System.Drawing.Point(91, 48);
            this.Login_value.Name = "Login_value";
            this.Login_value.Size = new System.Drawing.Size(155, 26);
            this.Login_value.TabIndex = 9;
            this.toolTip.SetToolTip(this.Login_value, "Введите логин");
            // 
            // Login_label
            // 
            this.Login_label.Font = new System.Drawing.Font("Tahoma", 14F);
            this.Login_label.Location = new System.Drawing.Point(12, 8);
            this.Login_label.Margin = new System.Windows.Forms.Padding(3);
            this.Login_label.Name = "Login_label";
            this.Login_label.Size = new System.Drawing.Size(130, 34);
            this.Login_label.TabIndex = 8;
            this.Login_label.Text = "Логин:";
            this.Login_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Registration
            // 
            this.Registration.Location = new System.Drawing.Point(171, 159);
            this.Registration.Name = "Registration";
            this.Registration.Size = new System.Drawing.Size(166, 56);
            this.Registration.TabIndex = 7;
            this.Registration.Text = "Зарегистрироваться";
            this.toolTip.SetToolTip(this.Registration, "Переход на форму регистрации");
            this.Registration.UseVisualStyleBackColor = true;
            this.Registration.Click += new System.EventHandler(this.Registration_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(10, 159);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(155, 56);
            this.Start.TabIndex = 6;
            this.Start.Text = "Вход";
            this.toolTip.SetToolTip(this.Start, "Вход в систему под текущим логином");
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 224);
            this.Controls.Add(this.Password_value);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Login_value);
            this.Controls.Add(this.Login_label);
            this.Controls.Add(this.Registration);
            this.Controls.Add(this.Start);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Password_value;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.TextBox Login_value;
        private System.Windows.Forms.Label Login_label;
        private System.Windows.Forms.Button Registration;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.ToolTip toolTip;
    }
}