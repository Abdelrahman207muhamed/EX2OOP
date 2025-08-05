using EX2OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace EX2OOP
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int mark) : base(header, body, mark)
        {
            // initializing the AnswerList with two answers: True(1) and False(2)
            AnswerList = new Answer[2];
            AnswerList[0] = new Answer(1, "True");
            AnswerList[1] = new Answer(2, "False");
        }

        public override object Clone()
        {
            TrueFalseQuestion cloned = new TrueFalseQuestion(Header, Body, Mark);
            cloned.RightAnswerId = RightAnswerId;
            return cloned;
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"\n{Header}");
            Console.WriteLine($"{Body}");
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
        }
    }
}
