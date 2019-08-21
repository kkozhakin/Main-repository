namespace kdz
{
    class Chick
    {
        public string id, weigh, time, chick, diet;
        ChickenCoop coop;
        /// <summary>
        /// Конструктор цыплёнка.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="weigh">вес</param>
        /// <param name="time">время</param>
        /// <param name="chick">вид</param>
        /// <param name="diet">диета</param>
        /// <param name="coop">курятник</param>
        public Chick(string id, string weigh, string time, string chick, string diet, ChickenCoop coop)
        {
            int i;
            if (!int.TryParse(id, out i) & id != "NA") this.id = "Error"; else this.id = id;
            if (!int.TryParse(weigh, out i) & weigh != "NA") this.weigh = "Error"; else this.weigh = weigh;
            if (!int.TryParse(time, out i) & time != "NA") this.time = "Error"; else this.time = time;
            if (!int.TryParse(chick, out i) & chick != "NA") this.chick = "Error"; else this.chick = chick;
            if (!int.TryParse(diet, out i) & diet != "NA") this.diet = "Error"; else this.diet = diet;
            this.coop = coop;
        }
        /// <summary>
        /// Измене данных экземпляры.
        /// </summary>
        /// <param name="s">значение параметра</param>
        /// <param name="name">имя параметра</param>
        public void ChickChange(string s, int name)
        {
            int i;
            switch (name)
            {
                case 0:
                    if (!int.TryParse(s, out i) & s != "NA") id = "Error"; else id = s;
                    break;
                case 1:
                    if (!int.TryParse(s, out i) & s != "NA") weigh = "Error"; else weigh = s;
                    break;
                case 2:
                    if (!int.TryParse(s, out i) & s != "NA") time = "Error"; else time = s;
                    break;
                case 3:
                    if (!int.TryParse(s, out i) & s != "NA") chick = "Error"; else chick = s;
                    break;
                case 4:
                    if (!int.TryParse(s, out i) & s != "NA") diet = "Error"; else diet = s;
                    break;
            }
        }
        /// <summary>
        /// Преобразовывает данные для записи в таблицу.
        /// </summary>
        /// <returns>Массив параметров</returns>
        public string[] ToStringMas()
        {
            string[] s = new string[5] { id == "NA" ? "" : id, weigh == "NA" ? "" : weigh,
                time == "NA" ? "" : time, chick == "NA" ? "" : chick, diet == "NA" ? "" : diet };
            return s;
        }
        /// <summary>
        /// Преобразовывает данные для записи в файл.
        /// </summary>
        /// <returns>Строку параметров.</returns>
        public override string ToString()
        {
            return id + "," + weigh + "," + time + "," + chick + "," + diet;
        }
    }
}
