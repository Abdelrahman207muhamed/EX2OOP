using EX2OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2OOP
{
    public class FinalExam : Exam
    {
        public FinalExam(int timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {
        }

        public override object Clone()
        {
            FinalExam cloned = new FinalExam(TimeOfExam, NumberOfQuestions);
            cloned.Questions = new Question[NumberOfQuestions];
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                if (Questions[i] is not null)
                    cloned.Questions[i] = (Question)Questions[i].Clone();
            }
            return cloned;
        }

        public override void ShowExam()
        {
            DisplayExamHeader();
            Console.WriteLine("FINAL EXAM");
            Console.WriteLine($"{'-' * 50}");

            int[] userAnswers = new int[NumberOfQuestions];
            int totalMarks = 0;
            int earnedMarks = 0;
            DateTime startTime = DateTime.Now;

            // Display and collect answers for all questions
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

            // Show results
            Console.WriteLine($"\n{'-' * 50}");
            Console.WriteLine("FINAL EXAM RESULTS");
            Console.WriteLine($"{'-' * 50}");

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                if (Questions[i] is not null)
                {
                    Console.WriteLine($"\nQuestion {i + 1}: {Questions[i].Body}");

                    // Show all answers
                    for (int j = 0; j < Questions[i].AnswerList.Length; j++)
                    {
                        Console.WriteLine($"  {Questions[i].AnswerList[j]}");
                    }

                    Console.WriteLine($"Your Answer: {userAnswers[i]}");
                    Console.WriteLine($"Correct Answer: {Questions[i].RightAnswerId}");
                    Console.WriteLine($"Status: {(Questions[i].CheckAnswer(userAnswers[i]) ? "Correct" : "Wrong")}");
                }
            }

            Console.WriteLine($"\nTotal Grade: {earnedMarks}/{totalMarks}");
            Console.WriteLine($"Percentage: {(double)earnedMarks / totalMarks * 100:F1}%");
            Console.WriteLine($"Time Spent: {timeTaken.Minutes}:{timeTaken.Seconds:D2}");
        }
    }
}
