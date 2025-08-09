using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Class
{
    internal abstract class Exam
    {
        public int ExamTime { get; set; }
        public int NumberOFQuestion { get; set; }
        public List<Question> Questions { get; set; }

        public Exam(int Time, int NQ)
        {
            ExamTime = Time;
            NumberOFQuestion = NQ;
            Questions = new List<Question>();
        }


        public abstract void ShowExam();

    }
}
