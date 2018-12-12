using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace DemoTest.Helpers
{
    public static class Logger
    {
        private static Dictionary<string, bool> resultList = new Dictionary<string, bool>();

        public static void LogResult(string expected, string actual, string message)
        {
            var result = expected == actual;
            Console.WriteLine("Result: {0}, {1}, Expected: {2}, Actual: {3}", result, message, expected, actual);
            resultList.Add(message, result);
        }

        public static void LogResult(int expected, int actual, string message)
        {
            LogResult(expected.ToString(), actual.ToString(), message);
        }

        public static void LogResult(decimal expected, decimal actual, string message)
        {
            LogResult(expected.ToString(), actual.ToString(), message);
        }

        public static void LogResult(bool expected, bool actual, string message)
        {
            LogResult(expected.ToString(), actual.ToString(), message);
        }

        public static bool GetFinalTestResult()
        {
            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "BradyTestLog.txt");
            Console.WriteLine($"LogPath: {logPath}");
            
            using (StreamWriter file = new StreamWriter(logPath, append: true))
            {
                file.WriteLine($"### Test run at {DateTime.Now.ToString()}");

                foreach (var resultItem in resultList)
                {
                    file.WriteLine($"Result: {resultItem.Value}, {resultItem.Key}");
                }
            }

            return !resultList.Any(x => x.Value.Equals(false));
        }
    }
}
