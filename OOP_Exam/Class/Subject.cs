using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Class
{
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam SubjectExam { get; set; }
        public Subject(int id, string name)
        {
            SubjectId = id;
            SubjectName = name;
        }
        public void CreateExam()
        {
            int choice, time, numQ;
            while (true)
            {
                Console.WriteLine("Please Enter The Type of Exam (1 For Practical, 2 for Final)");
                if (int.TryParse(Console.ReadLine(), out choice) && (choice == 1 || choice == 2))
                    break;
                Console.WriteLine("Invalid choice.\nPlease enter 1 for Practical or 2 for Final.");
            }

            while (true)
            {
                Console.WriteLine("Please Enter The Time of Exam From ( 30 min to 180 min ):");
                if (int.TryParse(Console.ReadLine(), out time) && (time >= 30 && time <= 180))
                    break;
                Console.WriteLine("Invalid choice.\nTime Must Be From ( 30 min to 180 min )");
            }
            while (true)
            {
                Console.WriteLine("Please Enter Number of Questions:");
                if (int.TryParse(Console.ReadLine(), out numQ) && (numQ > 0))
                    break;
                Console.WriteLine("Invalid choice.");
            }
            if (choice == 1)
                SubjectExam = new PracticalExam(time, numQ);
            else if (choice == 2)
                SubjectExam = new FinalExam(time, numQ);

            Console.Clear();

            for (int i = 0; i < numQ; i++)
            {
                int qType;
                while (true)
                {
                    Console.WriteLine("Please Enter The Type of Question (1 for T/F, 2 for MCQ): ");
                    if (int.TryParse(Console.ReadLine(), out qType) && (qType == 1 || qType == 2))
                        break;
                    Console.WriteLine("Invalid choice.\n");
                }

                Console.Clear();
                if (qType == 1) Console.WriteLine("True | False Question");
                else if (qType == 2) Console.WriteLine("MCQ Question");
                Console.Write("Enter Question Body: ");
                string body = Console.ReadLine();

                Console.Write("Enter Mark: ");
                int mark = int.Parse(Console.ReadLine());

                Question q;
                if (qType == 1)
                {
                    q = new TrueOrFalse(body, mark);
                }
                else
                {
                    q = new MCQ(body, mark);
                    int cNum;
                    while (true)
                    {
                        Console.WriteLine("Enter number of choices: ");
                        if (int.TryParse(Console.ReadLine(), out cNum) && (cNum > 1))
                            break;
                        Console.WriteLine("Invalid choice. Must be two or more");
                    }

                    for (int c = 1; c <= cNum; c++)
                    {
                        Console.Write($"Choice {c}: ");
                        string cText = Console.ReadLine();
                        q.AnswerList.Add(new Answer(c, cText));
                    }
                }


                int userAnswerId, RightAnswer;
                while (true)
                {
                    Console.Write("Enter Correct Answer Id: ");
                    if (int.TryParse(Console.ReadLine(), out RightAnswer) && (RightAnswer <= q.AnswerList.Count && RightAnswer > 0))
                        break;
                    else Console.WriteLine("invalid Option");
                }
                q.RightAnswerId = RightAnswer;

                SubjectExam.Questions.Add(q);
                Console.Clear();
            }

            Console.Write("Do you want to start the exam now? (Y/N): ");
            string startChoice = Console.ReadLine().Trim().ToUpper();

            if (startChoice == "Y")
            {
                Console.Clear();
                SubjectExam.ShowExam();
            }
            else
            {
                Console.WriteLine("Fine, You Can Start it Later. :)");
            }
        }
    }
}
