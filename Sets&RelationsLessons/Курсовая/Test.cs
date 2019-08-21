using System.IO;
using System.Xml.Serialization;

namespace Sets_RelationsLessons
{
    /// <summary>
    /// Класс теста
    /// </summary>
    [XmlRoot("Test")]
    public class Test
    {
        [XmlArray("Tasks")]
        [XmlArrayItem("Task")]
        public Task[] tasks;
        [XmlElement("Id")]
        public int id;
    }
    /// <summary>
    /// Класс задания(вопроса)
    /// </summary>
    public class Task
    {
        [XmlElement("Graph")]
        public string graph_name;
        [XmlElement("Condition")]
        public string condition;
        [XmlElement("Choice")]
        public int choice_ans;
        [XmlArray("Answers")]
        [XmlArrayItem("Ans")]
        public string[] choices;
        [XmlElement("Answer")]
        public string answer;
        /// <summary>
        /// Получение графа из xml файла
        /// </summary>
        /// <param name="graph_name">название файла</param>
        /// <returns>граф</returns>
        public Graph GetGraph(string graph_name)
        {
            if (File.Exists(graph_name))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Graph));
                FileStream fs = new FileStream(graph_name, FileMode.Open);
                Graph graph = (Graph)serializer.Deserialize(fs);
                fs.Close();
                return graph;
            }
            else return new Graph();
        }
    }
}
