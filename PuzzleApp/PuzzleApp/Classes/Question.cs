using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PuzzleApp
{
    [Serializable]
    public class Question
    {
        [XmlElement("Question")]
        public string question { get; set; }

        [XmlArray("Answers")]
        public List<Answer> answers { get; set; }

        public Question() { }

        public Question(string text, List<Answer> answers)
        {
            question = text;
            this.answers = answers;
        }
    }
}
