using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BerryBox.Utility
{
    public class EventLog
    {
        public static void WriteLog(string message, System.Diagnostics.EventLogEntryType type)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("event.log", true)) {
                    sw.WriteLine(string.Format("[{0}] [{1}] {2}", DateTime.Now, type.ToString(), message));
                    sw.Flush();
                    sw.Close();
                }
            }
            catch { }
        }
    }
}
