using System;
using System.Collections.Generic;
using System.IO;
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
            string[] eqfs = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.eqf", SearchOption.AllDirectories);
            foreach (string eqf in eqfs)
            {
                exam = Helper.LoadExaminationFromFile(eqf);
                currentReadingIndex = 0;
                return exam.Readings[currentReadingIndex];
            }

            return null;
        }
    }
}
