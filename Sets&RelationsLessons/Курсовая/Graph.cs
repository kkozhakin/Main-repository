using System.Collections.Generic;
using System.Xml.Serialization;

namespace Sets_RelationsLessons
{
    /// <summary>
    /// Класс графа
    /// </summary>
    [XmlRoot("Diagram")]
    public class Graph
    { 
        [XmlArray("Nodes")]
        [XmlArrayItem("Node")]
        public List<Vertice> vertices;
        [XmlArray("Links")]
        [XmlArrayItem("Link")]
        public List<Edge> edges;
    }  
    /// <summary>
    /// Класс вершины
    /// </summary>
    public class Vertice
    {
        [XmlAttribute("Id")]
        public string Id;
    }
    /// <summary>
    /// Класс ребра
    /// </summary>
    public class Edge
    {
        [XmlElement("Origin")]
        public Origin OId;
        [XmlElement("Destination")]
        public Destination DId;
    }
    /// <summary>
    /// Класс вершины, из которой выходит ребро
    /// </summary>
    public class Origin : Vertice
    {
        [XmlAttribute("Id")]
        public new string Id;
    }
    /// <summary>
    /// Класс вершины, в которую входит ребро
    /// </summary>
    public class Destination : Vertice
    {
        [XmlAttribute("Id")]
        public new string Id;
    }
}
