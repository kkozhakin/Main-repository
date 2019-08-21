namespace kdz
{
    partial class MainForm
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
            this.MainTable = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьВФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьТабльцуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Diet = new System.Windows.Forms.ComboBox();
            this.Calculate = new System.Windows.Forms.Button();
            this.MiddleValues = new System.Windows.Forms.DataGridView();
            this.Diet_Label = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MainTable)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiddleValues)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTable
            // 
            this.MainTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainTable.Location = new System.Drawing.Point(13, 58);
            this.MainTable.Name = "MainTable";
            this.MainTable.RowTemplate.Height = 24;
            this.MainTable.Size = new System.Drawing.Size(822, 317);
            this.MainTable.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(846, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьФайлToolStripMenuItem,
            this.сохранитьФайлToolStripMenuItem,
            this.добавитьВФайлToolStripMenuItem,
            this.очиститьТабльцуToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // загрузитьФайлToolStripMenuItem
            // 
            this.загрузитьФайлToolStripMenuItem.Name = "загрузитьФайлToolStripMenuItem";
            this.загрузитьФайлToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.загрузитьФайлToolStripMenuItem.Text = "Загрузить файл";
            // 
            // сохранитьФайлToolStripMenuItem
            // 
            this.сохранитьФайлToolStripMenuItem.Name = "сохранитьФайлToolStripMenuItem";
            this.сохранитьФайлToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.сохранитьФайлToolStripMenuItem.Text = "Сохранить файл";
            // 
            // добавитьВФайлToolStripMenuItem
            // 
            this.добавитьВФайлToolStripMenuItem.Name = "добавитьВФайлToolStripMenuItem";
            this.добавитьВФайлToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.добавитьВФайлToolStripMenuItem.Text = "Добавить в файл";
            // 
            // очиститьТабльцуToolStripMenuItem
            // 
            this.очиститьТабльцуToolStripMenuItem.Name = "очиститьТабльцуToolStripMenuItem";
            this.очиститьТабльцуToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.очиститьТабльцуToolStripMenuItem.Text = "Очистить таблицу";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // Diet
            // 
            this.Diet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Diet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Diet.FormattingEnabled = true;
            this.Diet.Items.AddRange(new object[] {
            "Все"});
            this.Diet.Location = new System.Drawing.Point(685, 31);
            this.Diet.Name = "Diet";
            this.Diet.Size = new System.Drawing.Size(149, 24);
            this.Diet.Sorted = true;
            this.Diet.TabIndex = 2;
            // 
            // Calculate
            // 
            this.Calculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Calculate.Location = new System.Drawing.Point(14, 381);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(145, 117);
            this.Calculate.TabIndex = 3;
            this.Calculate.Text = "Рассчитать";
            this.Calculate.UseVisualStyleBackColor = true;
            // 
            // MiddleValues
            // 
            this.MiddleValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MiddleValues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MiddleValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MiddleValues.Location = new System.Drawing.Point(165, 381);
            this.MiddleValues.Name = "MiddleValues";
            this.MiddleValues.ReadOnly = true;
            this.MiddleValues.RowTemplate.Height = 24;
            this.MiddleValues.Size = new System.Drawing.Size(670, 117);
            this.MiddleValues.TabIndex = 4;
            // 
            // Diet_Label
            // 
            this.Diet_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Diet_Label.AutoSize = true;
            this.Diet_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Diet_Label.Location = new System.Drawing.Point(537, 31);
            this.Diet_Label.Name = "Diet_Label";
            this.Diet_Label.Size = new System.Drawing.Size(132, 20);
            this.Diet_Label.TabIndex = 5;
            this.Diet_Label.Text = "Выбор диеты: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 510);
            this.Controls.Add(this.Diet_Label);
            this.Controls.Add(this.MiddleValues);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.Diet);
            this.Controls.Add(this.MainTable);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Цыплята";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainTable)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiddleValues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьФайлToolStripMenuItem;
        public System.Windows.Forms.DataGridView MainTable;
        private System.Windows.Forms.ToolStripMenuItem добавитьВФайлToolStripMenuItem;
        private System.Windows.Forms.ComboBox Diet;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.DataGridView MiddleValues;
        private System.Windows.Forms.Label Diet_Label;
        private System.Windows.Forms.ToolStripMenuItem очиститьТабльцуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

