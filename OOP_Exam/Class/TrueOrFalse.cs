using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Class
{
    internal class TrueOrFalse : Question
    {
        public TrueOrFalse(string body, int Mark) : base("True Or False", body, Mark)
        {
            AnswerList.Add(new Answer(1, "True"));
            AnswerList.Add(new Answer(2, "False"));
        }
        public override void Display()
        {
            Console.WriteLine($"{Header}: {Body}  (Mark: {Mark})");
            foreach (var ans in AnswerList)
                Console.WriteLine(ans);
        }
    }
}
