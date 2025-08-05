using EX2OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2OOP
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {

        }

        public override object Clone()
        {
            PracticalExam cloned = new PracticalExam(TimeOfExam, NumberOfQuestions);
            cloned.Questions = new Question[NumberOfQuestions];
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                if (Questions[i] != null)
                    cloned.Questions[i] = (Question)Questions[i].Clone();
            }
            return cloned;
        }

        public override void ShowExam()
        {
            DisplayExamHeader();
            Console.WriteLine("PRACTICAL EXAM");
            Console.WriteLine($"{'-' * 50}");

            int[] userAnswers = new int[NumberOfQuestions];
            int totalMarks = 0;
            int earnedMarks = 0;
            DateTime startTime = DateTime.Now;

            // Display and collect answers for all questions just like in FinalExam
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                if (Questions[i] is not null)
                {
                    totalMarks += Questions[i].Mark;
                    Questions[i].DisplayQuestion();

                    int maxAnswer = Questions[i].AnswerList.Length;
                    userAnswers[i] = GetValidUserInput(1, maxAnswer, "Your answer: ");

                    if (Questions[i].CheckAnswer(userAnswers[i]))
                    {
                        earnedMarks += Questions[i].Mark;
                    }
                }
            }

            DateTime endTime = DateTime.Now;
            TimeSpan timeTaken = endTime - startTime;

            // Show right answers after finishing (Practical Exam specific)
            Console.WriteLine($"\n{'-' * 50}");
            Console.WriteLine("PRACTICAL EXAM - RIGHT ANSWERS");
            Console.WriteLine($"{'-' * 50}");

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                if (Questions[i] is not null)
                {
                    Console.WriteLine($"Question {i + 1}: {Questions[i].Body}");
                    Console.WriteLine($"Right Answer: {Questions[i].RightAnswerId}");
                    Console.WriteLine($"Your Answer: {userAnswers[i]}");
                    Console.WriteLine($"Status: {(Questions[i].CheckAnswer(userAnswers[i]) ? "Correct" : "Wrong")}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine($"Total Grade: {earnedMarks}/{totalMarks}");
            double percentage = totalMarks > 0 ? (double)earnedMarks / totalMarks * 100 : 0;
            Console.WriteLine($"Percentage: {percentage:F1}%");
            Console.WriteLine($"Time Spent: {timeTaken.Minutes}:{timeTaken.Seconds:D2}");
        }
    }
}
