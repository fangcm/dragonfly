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
        private string fileName;
        private Examination exam;
        private int currentReadingIndex;

        public static string WorkingPath
        {
            get
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string path = Path.Combine(appDataPath, "dragonfly");
                if (!Directory.Exists(path))
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                    }
                    catch
                    {
                        return appDataPath;
                    }
                }
                return path;
            }
        }

        public static string MockResultFile
        {
            get { return Path.Combine(WorkingPath, "mock_result.xml"); }
        }

        public Reading GetMockReading()
        {
            string[] eqfs1 = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.eqf", SearchOption.AllDirectories);
            string[] eqfs2 = Directory.GetFiles(WorkingPath, "*.eqf", SearchOption.AllDirectories);
            IEnumerable<string> eqfs = eqfs1.Concat(eqfs2);

            MockResult mockResult = Helper.LoadMockResultFromFile(MockResultFile);
            if (mockResult == null || mockResult.ResultProperties == null)
            {
                if (eqfs.Count() == 0)
                {
                    return null;
                }
                fileName = eqfs.ElementAt(0);
                exam = Helper.LoadExaminationFromFile(fileName);
                currentReadingIndex = 0;
                return exam.Readings[currentReadingIndex];
            }
            else
            {
                if (!mockResult.ResultProperties.LastFileFinishedAll &&
                    !string.IsNullOrEmpty(mockResult.ResultProperties.LastFileName))
                {
                    fileName = mockResult.ResultProperties.LastFileName;
                    exam = Helper.LoadExaminationFromFile(fileName);
                    currentReadingIndex = mockResult.ResultProperties.LasReadingIndex + 1;
                    return exam.Readings[currentReadingIndex];
                }
            }

            foreach (string eqf in eqfs)
            {
                Practice practice = mockResult.Practices.FirstOrDefault(s => s.FileName == eqf);
                if (practice != null)
                {
                    continue;
                }
                fileName = eqf;
                exam = Helper.LoadExaminationFromFile(fileName);
                currentReadingIndex = 0;
                return exam.Readings[currentReadingIndex];
            }

            return null;
        }

        public void SaveMockResult(ReadingResult readingResult)
        {
            MockResult mockResult = Helper.LoadMockResultFromFile(MockResultFile);
            if (mockResult == null)
            {
                mockResult = new MockResult();
            }
            mockResult.SaveReadingResults(fileName, readingResult);

            mockResult.ResultProperties.LasReadingIndex = currentReadingIndex;
            mockResult.ResultProperties.LastFileName = fileName;
            mockResult.ResultProperties.LastFileFinishedAll = (currentReadingIndex >= exam.Readings.Count - 1);

            Helper.SaveMockResultToFile(MockResultFile, mockResult);
        }
    }
}
