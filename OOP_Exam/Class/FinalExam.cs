using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Class
{
    internal class FinalExam : Exam
    {
        public FinalExam(int Time, int NQ) : base(Time, NQ) { }

        public override void ShowExam()
        {
            Console.Clear();
            Console.WriteLine("==> Final Exam <==");

            int score = 0;
            var startTime = DateTime.Now;

            var results = new List<(string Body, string UserAnswer, string CorrectAnswer, int Mark, bool IsCorrect)>();

            for (int i = 0; i < Questions.Count; i++)
            {
                var q = Questions[i];
                Console.WriteLine($"\n{q.Header}     Mark: {q.Mark}");
                Console.WriteLine();
                foreach (var ans in q.AnswerList)
                {
                    Console.WriteLine($"{ans.AnswerId}. {ans.AnswerText}");
                }

                int userAnswerId;
                while (true)
                {
                    Console.Write("Your Answer: ");
                    if (int.TryParse(Console.ReadLine(), out userAnswerId) &&
                        (userAnswerId <= q.AnswerList.Count && userAnswerId > 0))
                        break;
                    else
                        Console.WriteLine("Invalid Option");
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
