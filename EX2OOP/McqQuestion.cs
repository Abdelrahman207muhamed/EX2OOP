using EX2OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace EX2OOP
{
    public class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, Answer[] answers) : base(header, body, mark)
        {
            if (answers == null || answers.Length < 2 || answers.Length > 4)
                throw new ArgumentException("MCQ must have 2:4 answer choices");

            AnswerList = new Answer[answers.Length];
            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i] == null)
                    throw new ArgumentException($"Answer at index {i} cannot be null");
                AnswerList[i] = (Answer)answers[i].Clone();
            }
        }

        public override object Clone()
        {
            Answer[] clonedAnswers = new Answer[AnswerList.Length];
            for (int i = 0; i < AnswerList.Length; i++)
            {
                clonedAnswers[i] = (Answer)AnswerList[i].Clone();
            }
            MCQQuestion cloned = new MCQQuestion(Header, Body, Mark, clonedAnswers);
            cloned.RightAnswerId = RightAnswerId;
            return cloned;
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"\n{Header}");
            Console.WriteLine($"{Body}");
            for (int i = 0; i < AnswerList.Length; i++)
            {
                Console.WriteLine($"{AnswerList[i].AnswerId}. {AnswerList[i].AnswerText}");
            }
        }
    }
}
