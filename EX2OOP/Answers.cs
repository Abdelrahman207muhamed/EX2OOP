using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2OOP
{
    public class Answer : ICloneable
    {
        private int _answerId;
        private string _answerText;

        public int AnswerId
        {
            get { return _answerId; }
            set
            {
                _answerId = value > 0 ? value : throw new ArgumentException("Answer Id must be positive. Enter a valid int which is greater than 0");
            }
        }

        public string AnswerText
        {
            get { return _answerText; }
            set
            {
                _answerText = !string.IsNullOrWhiteSpace(value) ? value.Trim() : throw new ArgumentException("Answer Text can't be empty. Enter a valid Answer Text please");
            }
        }

        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }

        public object Clone()
        {
            return new Answer(AnswerId, AnswerText);
        }

        public override string ToString()
        {
            return $"{AnswerId}. {AnswerText}";
        }
    }
}
