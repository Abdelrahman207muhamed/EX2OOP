using EX2OOP;

namespace C44_G00_EX02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Examination System!");
            Console.WriteLine(new string('-', 50));

            Console.Write("Enter Subject ID: ");
            int subjectId;
            while (!int.TryParse(Console.ReadLine(), out subjectId))
            {
                Console.Write("Please enter a valid subject ID: ");
            }

            Console.Write("Enter Subject Name: ");
            string subjectName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(subjectName))
            {
                Console.Write("Please enter a valid subject name: ");
                subjectName = Console.ReadLine();
            }

            Subject subject = new Subject(subjectId, subjectName);
            subject.CreateExam();

            Console.WriteLine("\nThank you for using the Examination System!");

        }
    }
}
