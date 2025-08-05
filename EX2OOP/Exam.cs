using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2OOP
{
    public abstract class Exam
    {
        private int _timeOfExam;
        private int _numberOfQuestions;
        public Question[] Questions { get; set; }

        public int TimeOfExam
        {
            get { return _timeOfExam; }
            set
            {
                _timeOfExam = value < 30 || value > 180 ? throw new ArgumentException("time of Exam must be betwee 30:180 minutes") : value;
            }
        }

        public int NumberOfQuestions
        {
            get { return _numberOfQuestions; }
            set
            {
                _numberOfQuestions = value < 1 || value > 100 ? throw new ArgumentException("Number of Questions must be between 1:100") : value;
            }
        }

        public Exam(int timeOfExam, int numberOfQuestions)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestions = numberOfQuestions;
            Questions = new Question[numberOfQuestions];
        }

        public abstract object Clone();
        public abstract void ShowExam();

        protected void DisplayExamHeader()
        {
            Console.WriteLine($"\n{'-' * 50}");
            Console.WriteLine($"EXAM - Time Limit: {TimeOfExam} minutes");
            Console.WriteLine($"Number of Questions: {NumberOfQuestions}");
            Console.WriteLine($"{'-' * 50}");
        }

        // a method to get valid user input for a number within a specified range
        protected int GetValidUserInput(int minValue, int maxValue, string prompt)
        {
            Console.Write(prompt);
            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < minValue || userInput > maxValue)
            {
                Console.Write($"Please enter a number between {minValue} and {maxValue}: ");
            }
            return userInput;
        }
    }
}
