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

        private string ExamFileName { get; set; }
        public Examination Examination { get; private set; }

        public Reading GetMockReading()
        {
            string[] eqfs = Directory.GetFiles(WorkingPath, "*.eqf", SearchOption.AllDirectories);
            if (eqfs.Count() == 0)
            {
                return null;
            }

            MockResult mockResult = Helper.LoadMockResultFromFile(MockResultFile);

            //最早做过未达标的
            DateTime earlierFailMockTime = DateTime.MaxValue;
            Reading earlierFailReading = null;

            //最早的已达标未满分的
            DateTime earlierPassMockTime = DateTime.MaxValue;
            Reading earlierPassReading = null;

            foreach (string eqf in eqfs)
            {
                ExamFileName = eqf;
                Examination = Helper.LoadExaminationFromFile(eqf);
                if (Examination == null || Examination.Readings == null || Examination.Readings.Count == 0)
                {
                    continue;
                }

                foreach (Reading reading in Examination.Readings)
                {
                    ReadingResult readingResult = findMockResult(mockResult, eqf, reading.Title);
                    if (readingResult == null)
                    {
                        //没做过，就做它吧
                        return reading;
                    }
                    else
                    {
                        if (readingResult.Score < Examination.ExamProperties.PassScore)
                        {
                            //缓存最早坐过不达标的
                            if (readingResult.EndTime < earlierFailMockTime)
                            {
                                earlierFailMockTime = readingResult.EndTime;
                                earlierFailReading = reading;
                            }
                        }
                        else
                        {
                            //缓存最早坐过达标的没有满分的
                            if ((readingResult.EndTime < earlierPassMockTime) && (readingResult.NumberOfCorrectAnswers < readingResult.NumberOfQuestions))
                            {
                                earlierPassMockTime = readingResult.EndTime;
                                earlierPassReading = reading;
                            }
                        }
                    }

                }
            }

            if (earlierFailReading != null)
            {
                return earlierFailReading;
            }

            if (earlierPassReading != null)
            {
                return earlierPassReading;
            }

            return null;
        }

        private ReadingResult findMockResult(MockResult mockResult, string examFileName, string readingTitle)
        {
            if (mockResult == null || mockResult.Practices == null)
            {
                return null;
            }

            Practice practice = mockResult.Practices.FirstOrDefault(s => s.FileName == examFileName);
            if (practice == null)
            {
                return null;
            }

            ReadingResult readingResult = practice.ReadingResults.FirstOrDefault(s => s.Title == readingTitle);
            if (readingResult == null)
            {
                return null;
            }

            return readingResult;
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
            Helper.SaveMockResultToFile(MockResultFile, mockResult);
        }
    }
}
