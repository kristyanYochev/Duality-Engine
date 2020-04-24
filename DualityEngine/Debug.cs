using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

using DualityEngine.Exceptions;

namespace DualityEngine
{
    public sealed class Debug
    {
        private static readonly Lazy<Debug> lazyInstance = new Lazy<Debug>(() => new Debug());

        public static Debug Instance { get { return lazyInstance.Value; } }

        private readonly Queue<string> messages = new Queue<string>();
        private StreamWriter logFileWriter = null;
        private FileStream logFile = null;
        private readonly Thread loggingThread = null;
        private volatile bool logging = true;

        private Debug()
        {
            loggingThread = new Thread(new ThreadStart(ProcessQueue));
            loggingThread.IsBackground = true;
            loggingThread.Start();
            
        }

        public void SetUp(string filePath)
        {
            logFile = File.Open(filePath, FileMode.Create);
            logFileWriter = new StreamWriter(logFile);
        }

        public void TearDown()
        {
            logging = false;
        }

        public void Log(object log)
        {
            double elapsedTime = (DateTime.Now - Process.GetCurrentProcess().StartTime).TotalSeconds;
            string message = $"[{elapsedTime}] {log}";

            lock (messages)
            {
                messages.Enqueue(message);
            }
        }

        private void ProcessQueue()
        {
            while (logging)
            {
                Queue<string> messagesCopy;
                lock (messages)
                {
                    messagesCopy = new Queue<string>(messages);
                    messages.Clear();
                }

                foreach (string message in messagesCopy)
                {
                    WriteLog(message);
                }
            }

            logFileWriter.Flush();
            logFile.Close();
        }

        private void WriteLog(string message)
        {
            if (logFileWriter == null)
            {
                throw new LoggingNotSetUpException();
            }

            logFileWriter.WriteLine(message);
        }
    }
}
