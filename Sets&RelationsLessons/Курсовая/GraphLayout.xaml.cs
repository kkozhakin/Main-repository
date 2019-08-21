using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using MindFusion.Diagramming.Wpf;

namespace Sets_RelationsLessons
{
    /// <summary>
    /// Логика взаимодействия для GraphLayout.xaml
    /// </summary>
    public partial class GraphLayout : UserControl
    {
        Test test;
        int num;

        public GraphLayout(ref Test test, int num, string name, bool EdgeAuto)
        {
            InitializeComponent();
            this.test = test;
            this.num = num;
            diagram.DefaultShape = Shapes.Ellipse;
            try
            {
                if (name == "ans")
                    diagram.LoadFromXml(Directory.GetCurrentDirectory() + @"\Lessons\tmpGraph" + num);
                else if (name == "true")
                    diagram.LoadFromXml(Directory.GetCurrentDirectory() + @"\Lessons\" + test.tasks[num].answer);
                else if (test.tasks[num].graph_name != "")
                    diagram.LoadFromXml(test.tasks[num].graph_name);
                else
                    diagram.LoadFromString("<diagram></diagram>");
            }
            catch (FileLoadException exp)
            {
                MessageBox.Show(exp.Message);
                return;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

            if (name == "DrawingGraph")
            {
                int m = diagram.Links.Count;
                for (int i = 0; i < m; i++)
                {
                    diagram.Links.RemoveAt(0);
                }
            }
            if (name == "PictureGraph") diagram.EnableLanes = false;

            DiagramLinkCollection diag = new DiagramLinkCollection();
            int n = diagram.Links.Count;
            for (int i = 0; i < n; i++)
            {
                diag.Add(new DiagramLink(diagram.Links[0].Parent, diagram.Links[0].Origin, diagram.Links[0].Destination));
                diag[i].AutoRoute = EdgeAuto;
                diagram.Links.RemoveAt(0);
            }
            foreach (var item in diag)
            {
                diagram.Links.Add(item);
            }
        }
        /// <summary>
        /// Метод сохранения текущего ответа-графа во временный файл
        /// </summary>
        private void UserControl_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (test.tasks[num].choice_ans == 0 || test.tasks[num].choice_ans == 4) diagram.SaveToXml(Directory.GetCurrentDirectory() + @"\Lessons\tmpGraph" + num);
        }
        /// <summary>
        /// Запрет на создание и удаление вершин
        /// </summary>
        private void diagram_NodeChanging(object sender, NodeValidationEventArgs e)
        {
            e.Cancel = true;
        }
        /// <summary>
        /// Позволяет удалять только петли
        /// </summary>
        private void diagram_LinkDeleting(object sender, LinkValidationEventArgs e)
        {
            if (e.Origin != e.Destination) e.Cancel = true;
        }
    }
}