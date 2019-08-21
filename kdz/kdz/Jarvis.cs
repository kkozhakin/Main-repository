using System;
using System.Windows.Forms;

namespace kdz
{
    /// <summary>
    /// Класс управления.
    /// </summary>
    class Jarvis
    {
        DataGridView MainTable, MiddleValues;
        OpenFileDialog openFileDialog1;
        SaveFileDialog saveFileDialog1;
        CSVProcessor csv;
        ChickenCoop coop = new ChickenCoop();
        ComboBox Diet;
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="MainTable">таблица данных</param>
        /// <param name="MiddleValues">таблица результатов</param>
        /// <param name="o">диалог загрузки файла</param>
        /// <param name="s">диалог сохранения файла</param>
        /// <param name="Diet">диета</param>
        public Jarvis(DataGridView MainTable, DataGridView MiddleValues, OpenFileDialog o, SaveFileDialog s, ComboBox Diet)
        {
            this.MainTable = MainTable;
            this.MiddleValues = MiddleValues;
            openFileDialog1 = o;
            saveFileDialog1 = s;
            this.Diet = Diet;
            csv = new CSVProcessor();
        }
        /// <summary>
        /// Перезапись таблицы данных.
        /// </summary>
        /// <param name="q">диета</param>
        private void RewriteTable(int q = -1)
        {
            MainTable.Rows.Clear();
            for (int i = 0; i < csv.data.Count; i++)
            {
                if (q < 0) MainTable.Rows.Add(csv.data[i].ToStringMas());
                else if (q.ToString() == csv.data[i].diet) MainTable.Rows.Add(csv.data[i].ToStringMas());
            }
        }
        /// <summary>
        /// Событие загрузки файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV Files (*.csv)|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;

            csv = new CSVProcessor();
            coop = new ChickenCoop();
            csv.Open(filename, coop, Diet);
            RewriteTable();
        }
        /// <summary>
        /// Событие сохранения файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Save(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "CSV Files (*.csv)|*.csv";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            csv.Save(filename);
        }
        /// <summary>
        /// Событие добавления данных к файлу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Add(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "CSV Files (*.csv)|*.csv";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            csv.Add(filename);
        }
        /// <summary>
        /// Событие удаления строки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DeleteRow(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                for (int i = 0; i < MainTable.SelectedRows.Count; i++)
                    csv.data.RemoveAt(MainTable.SelectedRows[i].Index);
        }
        /// <summary>
        /// Событие изменения клетки таблицы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CellChanged(object sender, DataGridViewCellEventArgs e)
        {
            int y = e.RowIndex;
            int x = e.ColumnIndex;
            int i;
            object o = MainTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (o != null && !int.TryParse(o.ToString(), out i) && i >= 0)
            {
                MainTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Error";
                o = "Error";
            }
            else if (o == null) o = "NA";
            string s = o.ToString();
            if (y > csv.data.Count - 1)
                switch (x)
                {
                    case 0:
                        csv.data.Add(new Chick(s, "NA", "NA", "NA", "NA", coop));
                        break;
                    case 1:
                        csv.data.Add(new Chick("NA", s, "NA", "NA", "NA", coop));
                        break;
                    case 2:
                        csv.data.Add(new Chick("NA", "NA", s, "NA", "NA", coop));
                        break;
                    case 3:
                        csv.data.Add(new Chick("NA", "NA", "NA", s, "NA", coop));
                        break;
                    case 4:
                        csv.data.Add(new Chick("NA", "NA", "NA", "NA", s, coop));
                        break;
                }
            else csv.data[y].ChickChange(s, x);
            if (x == 4 && s != "Error" && !Diet.Items.Contains(s)) Diet.Items.Add(s);
        }
        /// <summary>
        /// Событие изменения диеты.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DietChanged(object sender, EventArgs e)
        {
            if (Diet.SelectedItem.ToString() == "Все") RewriteTable();
            else RewriteTable(int.Parse(Diet.SelectedItem.ToString()));
        }
        /// <summary>
        /// Событие расчёта мод, медиан и средних значений.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Calculate(object sender, EventArgs e)
        {
            coop.Send(csv.data);
            MiddleValues.Rows.Clear();
            MiddleValues.Rows.Add(coop.Moda(Diet));
            MiddleValues.Rows.Add(coop.Mediana(Diet));
            MiddleValues.Rows.Add(coop.Middle(Diet));
        }
        /// <summary>
        /// Событие очищения таблицы и удаления данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Clear(object sender, EventArgs e)
        {
            MainTable.Rows.Clear();
            MiddleValues.Rows.Clear();
            MiddleValues.RowCount = 3;
            MiddleValues.Rows[0].Cells[0].Value = "Мода";
            MiddleValues.Rows[1].Cells[0].Value = "Медиана";
            MiddleValues.Rows[2].Cells[0].Value = "Среднее значение";
            Diet.Items.Clear();
            Diet.Items.Add("Все");
            Diet.SelectedItem = Diet.Items[0];
            csv.Dispose();
        }
        /// <summary>
        /// Событие выхода по нажатию "X".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Exit(object sender, FormClosingEventArgs e)
        {
            DialogResult ans = MessageBox.Show("Вы хотите сохранить данные перед выходом из приложения?", "Выход.", MessageBoxButtons.YesNoCancel);
            if (ans == DialogResult.Cancel)
                return;
            else if (DialogResult.No == ans)
                Application.ExitThread();
            else
            {
                saveFileDialog1.Filter = "CSV Files (*.csv)|*.csv";
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;
                csv.Save(filename);
                Application.ExitThread();
            }
        }
        /// <summary>
        /// Событие выхода по нажатию пункта меню "Выход".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Exit(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Вы хотите сохранить данные перед выходом из приложения?", "Выход.", MessageBoxButtons.YesNoCancel);
            if (ans == DialogResult.Cancel)
                return;
            else if (DialogResult.No == ans)
                Application.ExitThread();
            else
            {
                saveFileDialog1.Filter = "CSV Files (*.csv)|*.csv";
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;
                csv.Save(filename);
                Application.ExitThread();
            }
        }
        /// <summary>
        /// Событие сортировки таблицы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SortTable(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.CellValue1 == null || e.CellValue1.ToString() == "" || e.CellValue1.ToString() == "Error") e.SortResult = 1;
            else if (e.CellValue2 == null || e.CellValue2.ToString() == "" || e.CellValue2.ToString() == "Error") e.SortResult = -1;
            else if (int.Parse(e.CellValue2.ToString()) < int.Parse(e.CellValue1.ToString())) e.SortResult = 1;
            else if (int.Parse(e.CellValue2.ToString()) > int.Parse(e.CellValue1.ToString())) e.SortResult = -1;
            else e.SortResult = 0;
            e.Handled = true;
        }
    }
}
