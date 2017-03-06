using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dragonfly.Questions.Core;

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
            string[] eqfs = Directory.GetFiles(WorkingPath, "*.eqf", SearchOption.AllDirectories);
            if (eqfs.Count() == 0)
            {
                return null;
            }

            MockResult mockResult = Helper.LoadMockResultFromFile(MockResultFile);

            if (IsMockResultValid(mockResult))
            {
                //如果有记录，可以接续上一次
                Reading reading = PickReadingByLastMock(mockResult);
                if (reading != null)
                {
                    return reading;
                }
            }
            else
            {
                //没有做过题
                foreach (string eqf in eqfs)
                {
                    CurrentReadingIndex = 0;
                    ExamFileName = eqf;
                    Examination = Helper.LoadExaminationFromFile(ExamFileName);

                    if (Examination.Readings.Count <= CurrentReadingIndex)
                        continue;

                    return Examination.Readings[CurrentReadingIndex];
                }

                //没有Reading数大于0的题
                return null;
            }

            //找没做过的题
            //Todo

            //从做过的题中，找达到分数的。
            foreach (string eqf in eqfs)
            {
                ExamFileName = eqf;
                Practice practice = mockResult.Practices.FirstOrDefault(s => s.FileName == eqf);
                Examination = Helper.LoadExaminationFromFile(ExamFileName);

                if (practice != null)
                {
                    ReadingResult readingResult = practice.ReadingResults.FirstOrDefault(s => s.NumberOfCorrectAnswers < s.NumberOfQuestions);
                    if (readingResult != null)
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

        private bool IsMockResultValid(MockResult mockResult)
        {
            if (mockResult == null || mockResult.ResultProperties == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(mockResult.ResultProperties.LastFileName))
            {
                return false;
            }
 
            return true;
        }

        private Reading PickReadingByLastMock(MockResult mockResult)
        {

            if (mockResult.ResultProperties.LastFileFinishedAll)
            {
                return null;
            }

            ExamFileName = mockResult.ResultProperties.LastFileName;
            Examination = Helper.LoadExaminationFromFile(ExamFileName);

            CurrentReadingIndex = mockResult.ResultProperties.LasReadingIndex + 1;
            if (Examination.Readings.Count <= CurrentReadingIndex)
                return null;

            return Examination.Readings[CurrentReadingIndex];

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
