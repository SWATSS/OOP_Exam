using OOP_Exam.Class;

namespace OOP_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subj = new Subject(1, "OOP");
            subj.CreateExam();
        }
    }
}
