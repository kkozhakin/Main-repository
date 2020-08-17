using System;
using System.Xml.Serialization;

namespace PuzzleApp
{
    [Serializable]
    public class Answer
    {
        [XmlElement("Answer")]
        public string answer { get; set; }

        [XmlElement("Category")]
        public int category { get; set; }

        public Answer() { }

        public Answer(string answer, int category)
        {
            this.answer = answer;
            this.category = category;
        }
    }
}
