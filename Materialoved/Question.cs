using System;
using System.Xml.Serialization;

namespace Materialoved
{
    [Serializable]
    public class Question
    {
        [XmlElement("Question")]
        public string question { get; set; }

        [XmlArray("Answers")]
        [XmlArrayItem("Answers")]
        public string[] answers { get; set; }

        [XmlElement("CorrectAnswer")]
        public int correctAnswer { get; set; }

        public Question() { }

        public Question(string text, string[] answers, int n)
        {
            question = text;
            this.answers = answers;
            correctAnswer = n;
        }
    }
}
