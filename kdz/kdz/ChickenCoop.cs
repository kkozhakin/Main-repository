using System.Collections.Generic;
using System.Windows.Forms;

namespace kdz
{
    class ChickenCoop
    {
        List<Chick> data, dataw, datat, datac, datad;
        /// <summary>
        /// Сортировка данных по всем параметрам кроме id.
        /// </summary>
        private void Sort()
        {
            dataw = data.GetRange(0, data.Count);
            datat = data.GetRange(0, data.Count);
            datac = data.GetRange(0, data.Count);
            datad = data.GetRange(0, data.Count);
            dataw.Sort(delegate (Chick x, Chick y)
            {
                if (x.weigh == "NA" || x.weigh == "Error") return 1;
                else if (y.weigh == "NA" || y.weigh == "Error") return -1;
                else if (int.Parse(y.weigh) < int.Parse(x.weigh)) return 1;
                else if (int.Parse(y.weigh) > int.Parse(x.weigh)) return -1;
                return 0;
            });
            datat.Sort(delegate (Chick x, Chick y)
            {
                if (x.time == "NA" || x.time == "Error") return 1;
                else if (y.time == "NA" || y.time == "Error") return -1;
                else if (int.Parse(y.time) < int.Parse(x.time)) return 1;
                else if (int.Parse(y.time) > int.Parse(x.time)) return -1;
                return 0;
            });
            datac.Sort(delegate (Chick x, Chick y)
            {
                if (x.chick == "NA" || x.chick == "Error") return 1;
                else if (y.chick == "NA" || y.chick == "Error") return -1;
                else if (int.Parse(y.chick) < int.Parse(x.chick)) return 1;
                else if (int.Parse(y.chick) > int.Parse(x.chick)) return -1;
                return 0;
            });
            datad.Sort(delegate (Chick x, Chick y)
            {
                if (x.diet == "NA" || x.diet == "Error") return 1;
                else if (y.diet == "NA" || y.diet == "Error") return -1;
                else if (int.Parse(y.diet) < int.Parse(x.diet)) return 1;
                else if (int.Parse(y.diet) > int.Parse(x.diet)) return -1;
                return 0;
            });
        }
        /// <summary>
        /// Функция получения данных.
        /// </summary>
        /// <param name="data"></param>
        public void Send(List<Chick> data)
        {
            this.data = data;
            Sort();
        }
        /// <summary>
        /// Вычисление моды.
        /// </summary>
        /// <param name="Diet">диета</param>
        /// <returns>Массив мод по параметрам</returns>
        public string[] Moda(ComboBox Diet)
        {
            string[] moda = new string[5] {"Мода", "NA", "NA", "NA", "NA" };
            int[] col, col_max = new int[4] { 0, 0, 0, 0 };
            if (Diet.Text == "Все")
                for (int i = 0; i < data.Count; i++)
                {
                    col = new int[4] { 0, 0, 0, 0 };
                    for (int j = i; j < data.Count; j++)
                    {
                        if (dataw[i].weigh != "Error" && dataw[i].weigh != "NA" && dataw[i].weigh == dataw[j].weigh) col[0]++;
                        if (datat[i].time != "Error" && datat[i].time != "NA" && datat[i].time == datat[j].time) col[1]++;
                        if (datac[i].chick != "Error" && datac[i].chick != "NA" && datac[i].chick == datac[j].chick) col[2]++;
                        if (datad[i].diet != "Error" && datad[i].diet != "NA" && datad[i].diet == datad[j].diet) col[3]++;
                    }
                    if (col[0] > col_max[0])
                    {
                        col_max[0] = col[0];
                        moda[1] = dataw[i].weigh;
                    }
                    if (col[1] > col_max[1])
                    {
                        col_max[1] = col[1];
                        moda[2] = datat[i].time;
                    }
                    if (col[2] > col_max[2])
                    {
                        col_max[2] = col[2];
                        moda[3] = datac[i].chick;
                    }
                    if (col[3] > col_max[3])
                    {
                        col_max[3] = col[3];
                        moda[4] = datad[i].diet;
                    }
                }
            else
            {
                for (int i = 0; i < data.Count; i++)
                {
                    col = new int[3] { 1, 1, 1 };
                    for (int j = i; j < data.Count; j++)
                    {
                        if (dataw[i].weigh != "Error" && dataw[i].weigh != "NA" && dataw[i].weigh == dataw[j].weigh && dataw[i].diet == Diet.Text && dataw[j].diet == Diet.Text) col[0]++;
                        if (datat[i].time != "Error" && datat[i].time != "NA" && datat[i].time == datat[j].time && datat[i].diet == Diet.Text && datat[j].diet == Diet.Text) col[1]++;
                        if (datac[i].chick != "Error" && datac[i].chick != "NA" && datac[i].chick == datac[j].chick && datac[i].diet == Diet.Text && datac[j].diet == Diet.Text) col[2]++;
                    }
                    if (col[0] > col_max[0])
                    {
                        col_max[0] = col[0];
                        moda[1] = dataw[i].weigh;
                    }
                    if (col[1] > col_max[1])
                    {
                        col_max[1] = col[1];
                        moda[2] = datat[i].time;
                    }
                    if (col[2] > col_max[2])
                    {
                        col_max[2] = col[2];
                        moda[3] = datac[i].chick;
                    }
                }
                moda[4] = Diet.Text;
            }
            return moda;
        }
        /// <summary>
        /// Вычисление медианы.
        /// </summary>
        /// <param name="Diet">диета</param>
        /// <returns>Массив медиан по параметрам</returns>
        public string[] Mediana(ComboBox Diet)
        {
            string[] mediana = new string[5] { "Медиана", "0", "0", "0", "0" };
            List<Chick> d = new List<Chick> { };
            if (Diet.Text == "Все")
            {
                for (int i = 0; i < data.Count; i++)
                    if (dataw[i].weigh != "Error" && dataw[i].weigh != "NA") d.Add(dataw[i]);
                mediana[1] = d.Count > 0 ? MedVal(1, d.Count, d) : "NA";
                d = new List<Chick> { };
                for (int i = 0; i < data.Count; i++)
                    if (datat[i].time != "Error" && datat[i].time != "NA") d.Add(datat[i]);
                mediana[2] = d.Count > 0 ? MedVal(2, d.Count, d) : "NA";
                d = new List<Chick> { };
                for (int i = 0; i < data.Count; i++)
                    if (datac[i].chick != "Error" && datac[i].chick != "NA") d.Add(datac[i]);
                mediana[3] = d.Count > 0 ? MedVal(3, d.Count, d) : "NA";
                d = new List<Chick> { };
                for (int i = 0; i < data.Count; i++)
                    if (datad[i].diet != "Error" && datad[i].diet != "NA") d.Add(datad[i]);
                mediana[4] = d.Count > 0 ? MedVal(4, d.Count, d) : "NA";
            }
            else
            {
                for (int i = 0; i < data.Count; i++)
                    if (dataw[i].weigh != "Error" && dataw[i].weigh != "NA" && dataw[i].diet == Diet.Text) d.Add(dataw[i]);
                mediana[1] = d.Count > 0 ? MedVal(1, d.Count, d) : "NA";
                d = new List<Chick> { };
                for (int i = 0; i < data.Count; i++)
                    if (datat[i].time != "Error" && datat[i].time != "NA" && datat[i].diet == Diet.Text) d.Add(datat[i]);
                mediana[2] = d.Count > 0 ? MedVal(2, d.Count, d) : "NA";
                d = new List<Chick> { };
                for (int i = 0; i < data.Count; i++)
                    if (datac[i].chick != "Error" && datac[i].chick != "NA" && datac[i].diet == Diet.Text) d.Add(datac[i]);
                mediana[3] = d.Count > 0 ? MedVal(3, d.Count, d) : "NA";
                mediana[4] = Diet.Text;
            }
            return mediana;
        }
        /// <summary>
        /// Вычисление Среднего значения.
        /// </summary>
        /// <param name="Diet">диета</param>
        /// <returns>Массив средних значений по параметрам</returns>
        public string[] Middle(ComboBox Diet)
        {
            string[] middle = new string[5] { "Среднее значение", "0", "0", "0", "0" };
            int[] col = new int[4] { 0, 0, 0, 0 };
            if (Diet.Text == "Все")
            {
                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i].weigh != "Error" && data[i].weigh != "NA")
                        middle[1] = ((double.Parse(middle[1]) * col[0] + double.Parse(data[i].weigh)) / ++col[0]).ToString();
                    if (data[i].time != "Error" && data[i].time != "NA")
                        middle[2] = ((double.Parse(middle[2]) * col[1] + double.Parse(data[i].time)) / ++col[1]).ToString();
                    if (data[i].chick != "Error" && data[i].chick != "NA")
                        middle[3] = ((double.Parse(middle[3]) * col[2] + double.Parse(data[i].chick)) / ++col[2]).ToString();
                    if (data[i].diet != "Error" && data[i].diet != "NA")
                        middle[4] = ((double.Parse(middle[4]) * col[3] + double.Parse(data[i].diet)) / ++col[3]).ToString();
                }
                middle[1] = col[0] > 0 ? middle[1]:"NA";
                middle[2] = col[1] > 0 ? middle[2]:"NA";
                middle[3] = col[2] > 0 ? middle[3]:"NA";
                middle[4] = col[3] > 0 ? middle[4]:"NA";
            }
            else
            {
                for (int i = 0; i < data.Count; i++)
                    if (data[i].diet == Diet.Text)
                    {
                        if (data[i].weigh != "Error" && data[i].weigh != "NA")
                            middle[1] = ((double.Parse(middle[1]) * col[0] + double.Parse(data[i].weigh)) / ++col[0]).ToString();
                        if (data[i].time != "Error" && data[i].time != "NA")
                            middle[2] = ((double.Parse(middle[2]) * col[1] + double.Parse(data[i].time)) / ++col[1]).ToString();
                        if (data[i].chick != "Error" && data[i].chick != "NA")
                            middle[3] = ((double.Parse(middle[3]) * col[2] + double.Parse(data[i].chick)) / ++col[2]).ToString();
                    }
                middle[1] = col[0] > 0 ? middle[1] : "NA";
                middle[2] = col[1] > 0 ? middle[2] : "NA";
                middle[3] = col[2] > 0 ? middle[3] : "NA";
                middle[4] = Diet.Text;
            }
            return middle;
        }
        /// <summary>
        /// Вспомогательный метод для вычисления медианы.
        /// </summary>
        /// <param name="i">имя параметра</param>
        /// <param name="count">количество элементов</param>
        /// <param name="d">лист элементов</param>
        /// <returns>медиана</returns>
        private string MedVal(int i, int count, List<Chick> d)
        {
            switch (i)
            {
                case 1:
                    return ((int.Parse(d[count / 2].weigh) + int.Parse(d[(count - 1) / 2].weigh)) / 2.0).ToString();
                case 2:
                    return ((int.Parse(d[count / 2].time) + int.Parse(d[(count - 1) / 2].time)) / 2.0).ToString();
                case 3:
                    return ((int.Parse(d[count / 2].chick) + int.Parse(d[(count - 1) / 2].chick)) / 2.0).ToString();
                case 4:
                    return ((int.Parse(d[count / 2].diet) + int.Parse(d[(count - 1) / 2].diet)) / 2.0).ToString();
                default:
                    return "";
            }
        }
    }
}
