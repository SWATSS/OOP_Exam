using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Class
{
    internal class MCQ : Question
    {
        public MCQ(string budy, int Mark) : base("Choose The Correct Answer", budy, Mark) { }
        public override void Display()
        {
            Console.WriteLine($"(MCQ Question: {Body} Mark: {Mark})");
            foreach (var ans in AnswerList)
            {
                Console.WriteLine(ans);
            }
        }
    }
}
