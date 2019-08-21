namespace Sets_RelationsLessons
{
    partial class Results
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ResultTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ResultTable)).BeginInit();
            this.SuspendLayout();
            // 
            // ResultTable
            // 
            this.ResultTable.AllowUserToAddRows = false;
            this.ResultTable.AllowUserToDeleteRows = false;
            this.ResultTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ResultTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.ResultTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultTable.Location = new System.Drawing.Point(0, 0);
            this.ResultTable.Name = "ResultTable";
            this.ResultTable.ReadOnly = true;
            this.ResultTable.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ResultTable.RowTemplate.Height = 24;
            this.ResultTable.RowTemplate.ReadOnly = true;
            this.ResultTable.Size = new System.Drawing.Size(800, 506);
            this.ResultTable.TabIndex = 1;
            this.ResultTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultTable_CellDoubleClick);
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 506);
            this.Controls.Add(this.ResultTable);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "Results";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Результаты";
            ((System.ComponentModel.ISupportInitialize)(this.ResultTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView ResultTable;
    }
}