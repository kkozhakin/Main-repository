/*
Кожакин Кирилл Геннадьевич, группа БПИ173.
Дисциплина "Программирование".
Контрольное домашнее задание. Модуль 3. 2017-2018.
Контрольное домашнее задание 2.
Вариант 5.
Предложенный в варианте csv-файл содержит «сырые» данные, которые не могут напрямую использоваться с ИСС. 
Создать класс Jarvis, который будет координировать работу всех остальных классов индивидуального задания. 
Правила управления классами следует описать в пояснительной записке.
Класс CSVProcessor отвечает за разбор csv-файла. Строки, содержащие пропущенные значения (NA) требуется отображать в интерфейсе,
но исключать при статистической обработке. Некорректные значения следует заменить маркером Error и также исключать при статистической обработке.
При сортировке пропущенные или ошибочные значения следует группировать вначале или в конце списка.
Список объектов может быть реализован в виде массива или какой-либо коллекции, например, списка. Количество создаваемых объектов заранее неизвестно.
Порядок следования объектов разных типов (если такие есть) при создании списка произвольный и определяется пользователем. 
Приложение обязательно должно корректно открывать и позволять модифицировать, созданные с его помощью файлы с данными. 
Исходные файлы с данными могут располагаться в любой папке компьютера.
Приложение должно корректно работать с файлами, в пути к которым содержатся символы национальных алфавитов, знаки препинания, # и проч.,
допустимые для путей к файлам в ОС Windows символы.
Приложение должно корректно обрабатывать попытки загрузить файлы с нарушенным форматом.
Исключения, возникающие в процессе работы приложения, следует обрабатывать, обеспечивая стабильную работу приложения.
Данные о каждом измерении (строка файла) размещаются в объектах класса Цыплёнок. 
Статистические характеристики для всех Цыплят вычисляет класс Курятник, находящийся с Цыплятами в отношении агрегации. 
Класс Курятник предоставляет методы получения групп Цыплят по типам диеты, а также для вычисления моды,
медианы и средних значений всех числовых величин, объектов из этих групп. В интерфейсе предусмотреть средства для вывода соответствующих значений.
*/
using System;
using System.Windows.Forms;

namespace kdz
{
    public partial class MainForm : Form
    {
        Jarvis jar;
        public MainForm()
        {
            InitializeComponent();

            jar = new Jarvis(MainTable, MiddleValues, openFileDialog1, saveFileDialog1, Diet);
            загрузитьФайлToolStripMenuItem.Click += jar.Load;
            сохранитьФайлToolStripMenuItem.Click += jar.Save;
            добавитьВФайлToolStripMenuItem.Click += jar.Add;
            MainTable.CellValueChanged += jar.CellChanged;
            Diet.SelectionChangeCommitted += jar.DietChanged;
            Calculate.Click += jar.Calculate;
            очиститьТабльцуToolStripMenuItem.Click += jar.Clear;
            MainTable.KeyDown += jar.DeleteRow;
            выходToolStripMenuItem.Click += jar.Exit;
            FormClosing += jar.Exit;
            MainTable.SortCompare += jar.SortTable; 

            toolTip.SetToolTip(Calculate, "Расчитать моды, медианы и средние значения по данным в таблице.");
            toolTip.SetToolTip(Diet, "Диеты.");
        }
        /// <summary>
        /// Загрузка форма и присваивание начальных значений таблицам и полю выбора диет.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            MainTable.ColumnCount = 5;
            MainTable.Columns[0].Name = "Id";
            MainTable.Columns[1].Name = "Weight";
            MainTable.Columns[2].Name = "Time";
            MainTable.Columns[3].Name = "Chick";
            MainTable.Columns[4].Name = "Diet";
            MiddleValues.ColumnCount = 5;
            MiddleValues.Columns[1].Name = "Weight";
            MiddleValues.Columns[2].Name = "Time";
            MiddleValues.Columns[3].Name = "Chick";
            MiddleValues.Columns[4].Name = "Diet";
            MiddleValues.RowCount = 3;
            MiddleValues.Rows[0].Cells[0].Value = "Мода";
            MiddleValues.Rows[1].Cells[0].Value = "Медиана";
            MiddleValues.Rows[2].Cells[0].Value = "Среднее значение";
            Diet.SelectedItem = Diet.Items[0];
        }
    }
}
