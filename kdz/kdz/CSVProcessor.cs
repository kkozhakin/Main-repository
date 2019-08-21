using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace kdz
{   /// <summary>
    /// Класс, обрабатывающий csv файлы.
    /// </summary>
    class CSVProcessor : IDisposable
    {
        /// <summary>
        /// Лист цыплят.
        /// </summary>
        public List<Chick> data = new List<Chick> { };
        /// <summary>
        /// Метод загрузки csv файла. 
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <param name="coop">Курятник</param>
        /// <param name="Diet">Диета</param>
        public void Open(string filename, ChickenCoop coop, ComboBox Diet)
        {
            try
            {
                StreamReader fs = new StreamReader(filename);
                string s = "";
                string[] v;
                int i;
                s = fs.ReadLine();
                try
                {
                    while (s != null)
                    {
                        s = fs.ReadLine();
                        if (s != null)
                        {
                            s = s.Replace("\"", "");
                            v = s.Split(',');
                            data.Add(new Chick(v[0] == "" ? "NA" : v[0], v[1] == "" ? "NA" : v[1],
                                v[2] == "" ? "NA" : v[2], v[3] == "" ? "NA" : v[3], v[4] == "" ? "NA" : v[4], coop));
                            if (int.TryParse(v[4], out i) && !Diet.Items.Contains(v[4])) Diet.Items.Add(v[4]);
                        }
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Файл имеет неверный формат");
                    data.Clear();
                }
                fs.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            } 
        }
        /// <summary>
        /// Метод сохранения данных в csv файл.
        /// </summary>
        /// <param name="filename">Имя файла</param>
        public void Save(string filename)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filename, false, Encoding.Unicode);

                sw.Write("Id,Weigh,Time,Chick,Diet");
                sw.WriteLine();
                for (int i = 0; i < data.Count; i++)
                {
                    sw.Write(data[i].ToString());
                    sw.Write("\r\n");
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Метод добавления данных к csv файлн.
        /// </summary>
        /// <param name="filename">Имя файла</param>
        public void Add(string filename)
        {
            try
            {
                StreamWriter sw = new StreamWriter(new FileStream(filename, FileMode.Append, FileAccess.Write), Encoding.Unicode);
                for (int i = 0; i < data.Count; i++)
                {
                    sw.Write(data[i].ToString());
                    sw.Write("\r\n");
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Метод очистки данных.
        /// </summary>
        public void Dispose()
        {
            data.Clear();
        }
    }
}
