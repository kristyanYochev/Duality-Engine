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
        private StreamWriter logFile = null;

        private Debug()
        {
            Thread loggingThread = new Thread(new ThreadStart(ProcessQueue));
            loggingThread.IsBackground = true;
            loggingThread.Start();
        }

        public void SetUp(string filePath)
        {
            logFile = new StreamWriter(File.Open(filePath, FileMode.Create));
        }

        public void Log(object log)
        {
            double elapsedTime = (DateTime.Now - Process.GetCurrentProcess().StartTime).TotalSeconds;
            string message = $"[{elapsedTime}] {log.ToString()}";

            lock(messages)
            {
                messages.Enqueue(message);
            }
        }

        private void ProcessQueue()
        {
            while (true)
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
        }

        private void WriteLog(string message)
        {
            if (logFile == null)
            {
                throw new LoggingNotSetUpException();
            }

            logFile.WriteLine(message);
        }
    }
}
