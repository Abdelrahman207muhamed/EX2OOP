using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace EX2OOP
{
    public abstract class Question : ICloneable, IComparable<Question>
    {
        private string _header;
        private string _body;
        private int _mark;
        private Answer[] _answerList;
        private int _rightAnswerId;

        public string Header
        {
            get { return _header; }
            set
            {
                _header = !string.IsNullOrWhiteSpace(value) ? value.Trim() : throw new ArgumentException("Header can't be empty. Enter a valid Header for the question please");
            }
        }

        public string Body
        {
            get { return _body; }
            set
            {
                _body = !string.IsNullOrWhiteSpace(value) ? value.Trim() : throw new ArgumentException("Body can't be empty. Enter a valid Body for the question please");
            }

        }

        public int Mark
        {
            get { return _mark; }
            set
            {
                _mark = value > 0 ? value : throw new ArgumentException("Mark must be positive. Enter a valid int which is greater than 0");
            }
        }

        public Answer[] AnswerList
        {
            get { return _answerList; }
            set
            {
                _answerList = value == null || value.Length == 0 ? throw new ArgumentException("Answer list can't be empty. Enter a valid Answer List for the question please") : value;
            }
        }

        public int RightAnswerId
        {
            get { return _rightAnswerId; }
            set
            {
                _rightAnswerId = value > 0 && value <= AnswerList.Length ? value : throw new ArgumentException($"Right Answer Id must be between 1 and {AnswerList.Length}. Enter a valid int which is greater than 0 and less than or equal to {AnswerList.Length}");
            }
        }

        public Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;

        }

        public abstract object Clone();

        public virtual int CompareTo(Question other)
        {
            if (other == null) { return 1; }
            else return Mark.CompareTo(other.Mark);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Header: {Header}");
            sb.AppendLine($"Body: {Body}");
            sb.AppendLine($"Mark: {Mark}");
            sb.AppendLine("Answers:");
            foreach (var answer in AnswerList)
            {
                sb.AppendLine(answer.ToString());
            }
            sb.AppendLine($"Right Answer Id: {RightAnswerId}");
            return sb.ToString();
        }

        public abstract void DisplayQuestion();

        public virtual bool CheckAnswer(int userAnswer)
        {
            if (userAnswer <= 0 || userAnswer > AnswerList.Length)
                return false;
            return userAnswer == RightAnswerId;
        }
    }
}
