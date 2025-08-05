using EX2OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2OOP
{
    public class Subject
    {
        private int _subjectId;
        private string _subjectName;
        public Exam ExamOfSubject { get; set; }

        public int SubjectId
        {
            get { return _subjectId; }
            set
            {
                _subjectId = value > 0 ? value : throw new ArgumentException("Subject Id must be positive. Enter a valid int which is greater than 0");
            }
        }

        public string SubjectName
        {
            get { return _subjectName; }
            set
            {
                _subjectName = !string.IsNullOrWhiteSpace(value) ? value.Trim() : throw new ArgumentException("Subject Name can't be empty. Enter a valid Subject Name please");
            }

        }

        public Subject(int subjectId, string subjectName)
        {
            this.SubjectId = subjectId;
            this.SubjectName = subjectName;
        }

        public void CreateExam()
        {


            // Ask for exam type
            Console.WriteLine("Choose exam type:");
            Console.WriteLine("1. Practical Exam");
            Console.WriteLine("2. Final Exam");
            int examType = Helper_methods.GetValidIntInput(1, 2, "Enter your choice (1-2): ");

            // Ask for exam time (30-180 minutes)
            int examTime = Helper_methods.GetValidIntInput(30, 180, "Enter exam time (30-180 minutes): ");

            // Ask for number of questions
            int numQuestions = Helper_methods.GetValidIntInput(1, "Enter number of questions: ");

            // Create exam based on type
            if (examType == 1)
            {
                ExamOfSubject = new PracticalExam(examTime, numQuestions);
            }
            else
            {
                ExamOfSubject = new FinalExam(examTime, numQuestions);
            }

            // Create questions
            for (int i = 0; i < numQuestions; i++)
            {
                Console.WriteLine($"\n--- Creating Question {i + 1} ---");
                CreateQuestion(i, examType);
            }

            Console.WriteLine("\nExam created successfully!");
            Console.WriteLine("Do you want to display and take the exam? (y/n): ");
            string response = Console.ReadLine();
            if (response != null && response.ToLower() == "y")
            {
                ExamOfSubject.ShowExam();
            }
        }

        private void CreateQuestion(int questionIndex, int examType)
        {
            Console.WriteLine($"\n--- Creating Question {questionIndex + 1} ---");

            string header = Helper_methods.GetValidStringInput("Enter question header: ");
            string body = Helper_methods.GetValidStringInput("Enter question body: ");
            int mark = Helper_methods.GetValidIntInput(1, "Enter question mark: ");

            // Ask for question type based on exam type
            if (examType == 1) // Practical Exam - only MCQ
            {
                CreateMCQQuestion(questionIndex, header, body, mark);
            }
            else // Final Exam - MCQ or True/False
            {
                Console.WriteLine("Choose question type:");
                Console.WriteLine("1. MCQ");
                Console.WriteLine("2. True or False");
                int questionType = Helper_methods.GetValidIntInput(1, 2, "Enter your choice (1-2): ");

                if (questionType == 1)
                {
                    CreateMCQQuestion(questionIndex, header, body, mark);
                }
                else
                {
                    CreateTrueFalseQuestion(questionIndex, header, body, mark);
                }
            }
        }

        private void CreateMCQQuestion(int questionIndex, string header, string body, int mark)
        {
            int numChoices = Helper_methods.GetValidIntInput(2, 4, "Enter number of choices (2-4): ");

            Answer[] answers = new Answer[numChoices];
            for (int i = 0; i < numChoices; i++)
            {
                string choiceText = Helper_methods.GetValidStringInput($"Enter choice {i + 1}: ");
                answers[i] = new Answer(i + 1, choiceText);
            }

            MCQQuestion question = new MCQQuestion(header, body, mark, answers);
            int rightAnswerId = Helper_methods.GetValidIntInput(1, numChoices, $"Enter the ID of the right answer (1-{numChoices}): ");
            question.RightAnswerId = rightAnswerId;

            ExamOfSubject.Questions[questionIndex] = question;
        }

        private void CreateTrueFalseQuestion(int questionIndex, string header, string body, int mark)
        {
            TrueFalseQuestion question = new TrueFalseQuestion(header, body, mark);
            int rightAnswerId = Helper_methods.GetValidIntInput(1, 2, "Enter the right answer (1 for True, 2 for False): ");
            question.RightAnswerId = rightAnswerId;

            ExamOfSubject.Questions[questionIndex] = question;
        }

        public override string ToString()
        {
            return $"Subject ID: {SubjectId}, Name: {SubjectName}, Exam Type: {ExamOfSubject?.GetType().Name ?? "None"}";
        }
    }
}
