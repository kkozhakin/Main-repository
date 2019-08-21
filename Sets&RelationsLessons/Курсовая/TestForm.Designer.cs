namespace Sets_RelationsLessons
{
    partial class TestForm
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
            this.oneGraph = new System.Windows.Forms.Integration.ElementHost();
            this.next = new System.Windows.Forms.Button();
            this.previous = new System.Windows.Forms.Button();
            this.Answer = new System.Windows.Forms.Button();
            this.Condition = new System.Windows.Forms.Label();
            this.ChooseOneAnsPanel = new System.Windows.Forms.CheckedListBox();
            this.SaveAns = new System.Windows.Forms.Button();
            this.ChooseSomeAnsPanel = new System.Windows.Forms.CheckedListBox();
            this.WriteAnsPanel = new System.Windows.Forms.TextBox();
            this.PictureGraph = new System.Windows.Forms.Integration.ElementHost();
            this.DrawingGraph = new System.Windows.Forms.Integration.ElementHost();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.Repeat = new System.Windows.Forms.Button();
            this.ShowAns = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.форматРёберToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прямыеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.автоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вернутьсяКТестуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // oneGraph
            // 
            this.oneGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oneGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.oneGraph.Font = new System.Drawing.Font("Tahoma", 9F);
            this.oneGraph.Location = new System.Drawing.Point(37, 39);
            this.oneGraph.Name = "oneGraph";
            this.oneGraph.Size = new System.Drawing.Size(504, 306);
            this.oneGraph.TabIndex = 0;
            this.oneGraph.Child = null;
            // 
            // next
            // 
            this.next.Dock = System.Windows.Forms.DockStyle.Right;
            this.next.Font = new System.Drawing.Font("Tahoma", 9F);
            this.next.Location = new System.Drawing.Point(547, 26);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(29, 568);
            this.next.TabIndex = 1;
            this.next.Text = ">";
            this.toolTip.SetToolTip(this.next, "Переход к следующему заданию");
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // previous
            // 
            this.previous.Dock = System.Windows.Forms.DockStyle.Left;
            this.previous.Enabled = false;
            this.previous.Font = new System.Drawing.Font("Tahoma", 9F);
            this.previous.Location = new System.Drawing.Point(0, 26);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(29, 568);
            this.previous.TabIndex = 2;
            this.previous.Text = "<";
            this.toolTip.SetToolTip(this.previous, "Переход к предыдущему заданию");
            this.previous.UseVisualStyleBackColor = true;
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // Answer
            // 
            this.Answer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Answer.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Answer.Location = new System.Drawing.Point(40, 540);
            this.Answer.Name = "Answer";
            this.Answer.Size = new System.Drawing.Size(237, 40);
            this.Answer.TabIndex = 3;
            this.Answer.Text = "Завершить тест";
            this.toolTip.SetToolTip(this.Answer, "Завершить тест с текущими ответами");
            this.Answer.UseVisualStyleBackColor = true;
            this.Answer.Click += new System.EventHandler(this.answer_Click);
            // 
            // Condition
            // 
            this.Condition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Condition.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Condition.Location = new System.Drawing.Point(35, 348);
            this.Condition.Name = "Condition";
            this.Condition.Size = new System.Drawing.Size(500, 48);
            this.Condition.TabIndex = 4;
            this.Condition.Text = "Условие";
            // 
            // ChooseOneAnsPanel
            // 
            this.ChooseOneAnsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChooseOneAnsPanel.CheckOnClick = true;
            this.ChooseOneAnsPanel.ColumnWidth = 300;
            this.ChooseOneAnsPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ChooseOneAnsPanel.FormattingEnabled = true;
            this.ChooseOneAnsPanel.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.ChooseOneAnsPanel.Location = new System.Drawing.Point(37, 417);
            this.ChooseOneAnsPanel.MultiColumn = true;
            this.ChooseOneAnsPanel.Name = "ChooseOneAnsPanel";
            this.ChooseOneAnsPanel.Size = new System.Drawing.Size(503, 109);
            this.ChooseOneAnsPanel.TabIndex = 5;
            this.ChooseOneAnsPanel.Visible = false;
            this.ChooseOneAnsPanel.SelectedIndexChanged += new System.EventHandler(this.ChooseOneAnsPanel_SelectedIndexChanged);
            // 
            // SaveAns
            // 
            this.SaveAns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveAns.Font = new System.Drawing.Font("Tahoma", 9F);
            this.SaveAns.Location = new System.Drawing.Point(303, 540);
            this.SaveAns.Name = "SaveAns";
            this.SaveAns.Size = new System.Drawing.Size(237, 40);
            this.SaveAns.TabIndex = 6;
            this.SaveAns.Text = "Сохранить результат";
            this.toolTip.SetToolTip(this.SaveAns, "Сохранить текущие ответы");
            this.SaveAns.UseVisualStyleBackColor = true;
            this.SaveAns.Click += new System.EventHandler(this.SaveAns_Click);
            // 
            // ChooseSomeAnsPanel
            // 
            this.ChooseSomeAnsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChooseSomeAnsPanel.CheckOnClick = true;
            this.ChooseSomeAnsPanel.ColumnWidth = 300;
            this.ChooseSomeAnsPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ChooseSomeAnsPanel.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.ChooseSomeAnsPanel.Location = new System.Drawing.Point(35, 417);
            this.ChooseSomeAnsPanel.MultiColumn = true;
            this.ChooseSomeAnsPanel.Name = "ChooseSomeAnsPanel";
            this.ChooseSomeAnsPanel.Size = new System.Drawing.Size(503, 109);
            this.ChooseSomeAnsPanel.TabIndex = 7;
            this.ChooseSomeAnsPanel.Visible = false;
            // 
            // WriteAnsPanel
            // 
            this.WriteAnsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WriteAnsPanel.Location = new System.Drawing.Point(37, 462);
            this.WriteAnsPanel.Name = "WriteAnsPanel";
            this.WriteAnsPanel.Size = new System.Drawing.Size(503, 26);
            this.WriteAnsPanel.TabIndex = 8;
            this.WriteAnsPanel.Visible = false;
            // 
            // PictureGraph
            // 
            this.PictureGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PictureGraph.Font = new System.Drawing.Font("Tahoma", 9F);
            this.PictureGraph.Location = new System.Drawing.Point(35, 39);
            this.PictureGraph.MinimumSize = new System.Drawing.Size(242, 306);
            this.PictureGraph.Name = "PictureGraph";
            this.PictureGraph.Size = new System.Drawing.Size(242, 306);
            this.PictureGraph.TabIndex = 10;
            this.PictureGraph.Visible = false;
            this.PictureGraph.Child = null;
            // 
            // DrawingGraph
            // 
            this.DrawingGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawingGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DrawingGraph.Font = new System.Drawing.Font("Tahoma", 9F);
            this.DrawingGraph.Location = new System.Drawing.Point(293, 39);
            this.DrawingGraph.MinimumSize = new System.Drawing.Size(242, 306);
            this.DrawingGraph.Name = "DrawingGraph";
            this.DrawingGraph.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DrawingGraph.Size = new System.Drawing.Size(245, 306);
            this.DrawingGraph.TabIndex = 11;
            this.DrawingGraph.Visible = false;
            this.DrawingGraph.Child = null;
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox.Location = new System.Drawing.Point(35, 39);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(505, 306);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 12;
            this.pictureBox.TabStop = false;
            this.pictureBox.Visible = false;
            // 
            // Repeat
            // 
            this.Repeat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Repeat.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Repeat.Location = new System.Drawing.Point(40, 540);
            this.Repeat.Name = "Repeat";
            this.Repeat.Size = new System.Drawing.Size(237, 40);
            this.Repeat.TabIndex = 14;
            this.Repeat.Text = "Повторить тест";
            this.toolTip.SetToolTip(this.Repeat, "Начать тест заного");
            this.Repeat.UseVisualStyleBackColor = true;
            this.Repeat.Visible = false;
            this.Repeat.Click += new System.EventHandler(this.Repeat_Click);
            // 
            // ShowAns
            // 
            this.ShowAns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowAns.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ShowAns.Location = new System.Drawing.Point(303, 540);
            this.ShowAns.Name = "ShowAns";
            this.ShowAns.Size = new System.Drawing.Size(237, 40);
            this.ShowAns.TabIndex = 15;
            this.ShowAns.Text = "Показать ответы";
            this.toolTip.SetToolTip(this.ShowAns, "Показать правильные ответы");
            this.ShowAns.UseVisualStyleBackColor = true;
            this.ShowAns.Visible = false;
            this.ShowAns.Click += new System.EventHandler(this.ShowAns_Click);
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Tahoma", 9F);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.помощьToolStripMenuItem,
            this.форматРёберToolStripMenuItem,
            this.вернутьсяКТестуToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(576, 26);
            this.menuStrip.TabIndex = 16;
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(77, 22);
            this.помощьToolStripMenuItem.Text = "Помощь";
            this.помощьToolStripMenuItem.ToolTipText = "Помощь по тесту";
            this.помощьToolStripMenuItem.Click += new System.EventHandler(this.помощьToolStripMenuItem_Click);
            // 
            // форматРёберToolStripMenuItem
            // 
            this.форматРёберToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прямыеToolStripMenuItem,
            this.автоToolStripMenuItem});
            this.форматРёберToolStripMenuItem.Name = "форматРёберToolStripMenuItem";
            this.форматРёберToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.форматРёберToolStripMenuItem.Text = "Формат рёбер";
            // 
            // прямыеToolStripMenuItem
            // 
            this.прямыеToolStripMenuItem.Name = "прямыеToolStripMenuItem";
            this.прямыеToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.прямыеToolStripMenuItem.Text = "Прямые";
            this.прямыеToolStripMenuItem.ToolTipText = "Ребра в виде прямых стрелок";
            this.прямыеToolStripMenuItem.Click += new System.EventHandler(this.прямыеToolStripMenuItem_Click);
            // 
            // автоToolStripMenuItem
            // 
            this.автоToolStripMenuItem.Name = "автоToolStripMenuItem";
            this.автоToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.автоToolStripMenuItem.Text = "Авто";
            this.автоToolStripMenuItem.ToolTipText = "Автовыстраивание рёбер";
            this.автоToolStripMenuItem.Click += new System.EventHandler(this.автоToolStripMenuItem_Click);
            // 
            // вернутьсяКТестуToolStripMenuItem
            // 
            this.вернутьсяКТестуToolStripMenuItem.Name = "вернутьсяКТестуToolStripMenuItem";
            this.вернутьсяКТестуToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.вернутьсяКТестуToolStripMenuItem.Text = "Вернуться к тесту";
            this.вернутьсяКТестуToolStripMenuItem.ToolTipText = "Возобновляет тест";
            this.вернутьсяКТестуToolStripMenuItem.Visible = false;
            this.вернутьсяКТестуToolStripMenuItem.Click += new System.EventHandler(this.вернутьсяКТестуToolStripMenuItem_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(29, 26);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(518, 568);
            this.webBrowser.TabIndex = 17;
            this.webBrowser.Visible = false;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 594);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.ShowAns);
            this.Controls.Add(this.Repeat);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.DrawingGraph);
            this.Controls.Add(this.PictureGraph);
            this.Controls.Add(this.WriteAnsPanel);
            this.Controls.Add(this.ChooseSomeAnsPanel);
            this.Controls.Add(this.SaveAns);
            this.Controls.Add(this.ChooseOneAnsPanel);
            this.Controls.Add(this.Condition);
            this.Controls.Add(this.Answer);
            this.Controls.Add(this.previous);
            this.Controls.Add(this.next);
            this.Controls.Add(this.oneGraph);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(575, 641);
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тест";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.TestForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost oneGraph;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button previous;
        private System.Windows.Forms.Button Answer;
        private System.Windows.Forms.Label Condition;
        private System.Windows.Forms.CheckedListBox ChooseOneAnsPanel;
        private System.Windows.Forms.Button SaveAns;
        private System.Windows.Forms.CheckedListBox ChooseSomeAnsPanel;
        private System.Windows.Forms.TextBox WriteAnsPanel;
        private System.Windows.Forms.Integration.ElementHost PictureGraph;
        private System.Windows.Forms.Integration.ElementHost DrawingGraph;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button Repeat;
        private System.Windows.Forms.Button ShowAns;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem форматРёберToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прямыеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem автоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вернутьсяКТестуToolStripMenuItem;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}