using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Class
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int Time, int NQ) : base(Time, NQ)
        {
        }


        public override void ShowExam()
        {
            Console.Clear();
            Console.WriteLine("==> Practical Exam <==");

            int score = 0;
            var startTime = DateTime.Now;

            // لتخزين بيانات كل سؤال علشان نعرضها بعد الامتحان
            var results = new List<(string Body, string UserAnswer, string CorrectAnswer, int Mark, bool IsCorrect)>();

            for (int i = 0; i < Questions.Count; i++)
            {
                var q = Questions[i];
                Console.WriteLine($"\n{q.Header}\nQuestion {i + 1} : {q.Body}");

                foreach (var ans in q.AnswerList)
                {
                    Console.WriteLine($"{ans.AnswerId}. {ans.AnswerText}");
                }

                int userAnswerId;
                while (true)
                {
                    Console.Write("Your Answer: ");
                    if (int.TryParse(Console.ReadLine(), out userAnswerId) &&
                        (userAnswerId >= 1 && userAnswerId <= q.AnswerList.Count))
                        break;
                    else
                        Console.WriteLine("Invalid Option, Please try again.");
                }

                bool isCorrect = (userAnswerId == q.RightAnswerId);
                if (isCorrect)
                    score += q.Mark;

                var userAnswerText = q.AnswerList.First(a => a.AnswerId == userAnswerId).AnswerText;
                var correctAnswerText = q.AnswerList.First(a => a.AnswerId == q.RightAnswerId).AnswerText;

                results.Add((q.Body, userAnswerText, correctAnswerText, q.Mark, isCorrect));
            }

            var endTime = DateTime.Now;
            var totalTime = endTime - startTime;

            Console.Clear();
            Console.WriteLine("==> Exam Results <==\n");

            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine($"Question {i + 1} : {results[i].Body}");
                Console.WriteLine($"Your Answer => {results[i].UserAnswer}");
                Console.WriteLine($"Correct Answer => {results[i].CorrectAnswer}");
                Console.WriteLine();
            }

            Console.WriteLine($"Your Grade is {score} from {Questions.Sum(q => q.Mark)}");
            Console.WriteLine($"Time = {totalTime}");
            Console.WriteLine("Thank you");
        }

    }
}
