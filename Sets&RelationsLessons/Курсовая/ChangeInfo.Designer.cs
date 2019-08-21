namespace Sets_RelationsLessons
{
    partial class ChangeInfo
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
            this.Password_value2 = new System.Windows.Forms.TextBox();
            this.Password_ladel2 = new System.Windows.Forms.Label();
            this.Password_value = new System.Windows.Forms.TextBox();
            this.Password_label = new System.Windows.Forms.Label();
            this.Login_value = new System.Windows.Forms.TextBox();
            this.Login_label = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.Change = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // Password_value2
            // 
            this.Password_value2.Location = new System.Drawing.Point(98, 198);
            this.Password_value2.Name = "Password_value2";
            this.Password_value2.Size = new System.Drawing.Size(155, 26);
            this.Password_value2.TabIndex = 15;
            this.toolTip.SetToolTip(this.Password_value2, "Введите новый пароль");
            // 
            // Password_ladel2
            // 
            this.Password_ladel2.Font = new System.Drawing.Font("Tahoma", 14F);
            this.Password_ladel2.Location = new System.Drawing.Point(12, 158);
            this.Password_ladel2.Margin = new System.Windows.Forms.Padding(3);
            this.Password_ladel2.Name = "Password_ladel2";
            this.Password_ladel2.Size = new System.Drawing.Size(236, 34);
            this.Password_ladel2.TabIndex = 14;
            this.Password_ladel2.Text = "Новый пароль:";
            this.Password_ladel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Password_value
            // 
            this.Password_value.Location = new System.Drawing.Point(98, 126);
            this.Password_value.Name = "Password_value";
            this.Password_value.Size = new System.Drawing.Size(155, 26);
            this.Password_value.TabIndex = 13;
            this.toolTip.SetToolTip(this.Password_value, "Введите пароль");
            // 
            // Password_label
            // 
            this.Password_label.Font = new System.Drawing.Font("Tahoma", 14F);
            this.Password_label.Location = new System.Drawing.Point(12, 86);
            this.Password_label.Margin = new System.Windows.Forms.Padding(3);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(254, 34);
            this.Password_label.TabIndex = 12;
            this.Password_label.Text = "Старый пароль:";
            this.Password_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Login_value
            // 
            this.Login_value.Location = new System.Drawing.Point(98, 54);
            this.Login_value.Name = "Login_value";
            this.Login_value.Size = new System.Drawing.Size(155, 26);
            this.Login_value.TabIndex = 11;
            this.toolTip.SetToolTip(this.Login_value, "Введите новый логин");
            // 
            // Login_label
            // 
            this.Login_label.Font = new System.Drawing.Font("Tahoma", 14F);
            this.Login_label.Location = new System.Drawing.Point(12, 14);
            this.Login_label.Margin = new System.Windows.Forms.Padding(3);
            this.Login_label.Name = "Login_label";
            this.Login_label.Size = new System.Drawing.Size(178, 34);
            this.Login_label.TabIndex = 10;
            this.Login_label.Text = "Новый логин:";
            this.Login_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(178, 241);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(155, 56);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "Отмена";
            this.toolTip.SetToolTip(this.Cancel, "Вернуться на главную форму без изменений");
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Change
            // 
            this.Change.Location = new System.Drawing.Point(17, 241);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(155, 56);
            this.Change.TabIndex = 8;
            this.Change.Text = "Изменить";
            this.toolTip.SetToolTip(this.Change, "Вернуться на главную форму и сохранить изменения");
            this.Change.UseVisualStyleBackColor = true;
            this.Change.Click += new System.EventHandler(this.Change_Click);
            // 
            // ChangeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 305);
            this.Controls.Add(this.Password_value2);
            this.Controls.Add(this.Password_ladel2);
            this.Controls.Add(this.Password_value);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Login_value);
            this.Controls.Add(this.Login_label);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Change);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ChangeInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменить данные";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangeInfo_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Password_value2;
        private System.Windows.Forms.Label Password_ladel2;
        private System.Windows.Forms.TextBox Password_value;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.TextBox Login_value;
        private System.Windows.Forms.Label Login_label;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Change;
        private System.Windows.Forms.ToolTip toolTip;
    }
}