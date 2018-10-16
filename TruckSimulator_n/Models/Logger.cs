using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator_n
{
    class Logger: IDisposable
    {
        public Logger(string logFileName)
        {
            _logFileName = logFileName;
            _strm = new FileStream(_logFileName, FileMode.Append);
            _wrtr = new StreamWriter(_strm);
        }

        public void WriteDataToLog(string msg)
        {
            lock(_lockObj)
            {
                _wrtr.WriteLine(string.Format(msg, Environment.NewLine));
            }
        }

        public void Dispose()
        {
            _wrtr.Flush();    // Принудительный сброс буфера
            _strm.Flush();    // Принудительный сброс буфера
            _strm.Dispose();
        }

        public void Close()
        {
            _wrtr.Close();
        }

        StreamWriter _wrtr = null;
        FileStream _strm = null;

        private object _lockObj = new object();    // объект синхронизации, который связан с файлом _logFileName
        private string _logFileName = "log.txt";
    }
}
