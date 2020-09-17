using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileLogger
{
    public class Logger
        {
            public static string baseFolderName = @"E:\EbeRealData\";
            public static int logLevel = 1;
            
            public void PrintHello()
            {
                Console.WriteLine("hi");
            }
            
            public static void WriteList<T>(string fileName, List<T> list)
            {
                StringBuilder builder = new StringBuilder();
                var now = DateTime.Now;
                foreach(Object item in list)
                {
                    builder.Append(item+Environment.NewLine);
                }
                Directory.CreateDirectory(baseFolderName+now.ToString("yyyyMMdd"));
                string curFile = baseFolderName+now.ToString("yyyyMMdd")+@"\"+fileName;
                StreamWriter sw = File.Exists(curFile) ?  File.AppendText(curFile) : File.CreateText(curFile);
                sw.Write(builder.ToString());
                sw.Close();
            }
    
            public static void Debug(string message)
            {
                if (logLevel <= 1)
                    log(message);
            }
    
            private static async void log(string message)
            {
                var now = DateTime.Now;
                var nowStr = now.ToString("yyyyMMdd");
                Directory.CreateDirectory(baseFolderName+nowStr);
                var curFile = baseFolderName+nowStr+@"\"+nowStr+".txt";
                using (StreamWriter sw = File.Exists(curFile) ? File.AppendText(curFile) : File.CreateText(curFile))
                {
                    await sw.WriteAsync(message+Environment.NewLine);
                }
            }
        }
}