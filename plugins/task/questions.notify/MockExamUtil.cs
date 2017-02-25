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

        public string ExamFileName { get; private set; }
        public Examination Examination { get; private set; }
        public int CurrentReadingIndex { get; private set; }

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
                ExamFileName = eqfs.ElementAt(0);
                Examination = Helper.LoadExaminationFromFile(ExamFileName);

                CurrentReadingIndex = 0;
                if (Examination.Readings.Count <= CurrentReadingIndex)
                    return null;

                return Examination.Readings[CurrentReadingIndex];
            }
            else
            {
                if (!mockResult.ResultProperties.LastFileFinishedAll &&
                    !string.IsNullOrEmpty(mockResult.ResultProperties.LastFileName))
                {
                    ExamFileName = mockResult.ResultProperties.LastFileName;
                    Examination = Helper.LoadExaminationFromFile(ExamFileName);

                    CurrentReadingIndex = mockResult.ResultProperties.LasReadingIndex + 1;
                    if (Examination.Readings.Count <= CurrentReadingIndex)
                        return null;

                    return Examination.Readings[CurrentReadingIndex];
                }
            }

            foreach (string eqf in eqfs)
            {
                Practice practice = mockResult.Practices.FirstOrDefault(s => s.FileName == eqf);
                ExamFileName = eqf;
                Examination = Helper.LoadExaminationFromFile(ExamFileName);

                if (practice != null)
                {
                    ReadingResult readingResult = practice.ReadingResults.FirstOrDefault(s => s.NumberOfCorrectAnswers < s.NumberOfQuestions);
                    if(readingResult != null)
                    {
                        Reading reading = Examination.Readings.FirstOrDefault(s => s.Title == readingResult.Title);
                        if (reading != null)
                        {
                            return reading;
                        }
                    }
                    continue;
                }
                CurrentReadingIndex = 0;
                if (Examination.Readings.Count <= CurrentReadingIndex)
                    return null;

                return Examination.Readings[CurrentReadingIndex];
            }

            return null;
        }

        public void SaveMockResult(ReadingResult readingResult)
        {
            if (readingResult.NumberOfCorrectAnswers == 0)
            {
                return;
            }
            MockResult mockResult = Helper.LoadMockResultFromFile(MockResultFile);
            if (mockResult == null)
            {
                mockResult = new MockResult();
            }
            mockResult.SaveReadingResults(ExamFileName, readingResult);

            mockResult.ResultProperties.LasReadingIndex = CurrentReadingIndex;
            mockResult.ResultProperties.LastFileName = ExamFileName;
            mockResult.ResultProperties.LastFileFinishedAll = (CurrentReadingIndex >= Examination.Readings.Count - 1);

            Helper.SaveMockResultToFile(MockResultFile, mockResult);
        }
    }
}
