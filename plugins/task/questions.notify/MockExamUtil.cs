using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragonfly.Questions.Notify
{
    internal class MockExamUtil
    {
        private Examination exam;
        private int currentReadingIndex;

        public Reading GetMockReading()
        {
            exam = Helper.LoadExaminationFromFile("../../../exam1.eqf");
            currentReadingIndex = 0;
            return exam.Readings[currentReadingIndex];
        }
    }
}
