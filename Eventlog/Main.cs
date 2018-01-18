using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace Eventlog
{
    class Test
    {
        static void Main()
        {
            string logType = "Microsoft-Windows-Sysmon/Operational";
            string query = "*[EventData/*]";
            EventLogReader elReader;

            EventLogQuery elQuery = new EventLogQuery(logType, PathType.LogName, query);
            try
            {
                // Query the log and create a stream of selected events
                elReader = new EventLogReader(elQuery);
            }
            catch (EventLogNotFoundException e)
            {
                Console.WriteLine("Failed to query the log!");
                Console.WriteLine(e);
                return;
            }

            int count = 0;
            for (EventRecord eventInstance = elReader.ReadEvent(); eventInstance != null; eventInstance = elReader.ReadEvent())
            {
                string kk = eventInstance.ToXml();
                string b = "d";
                count++;
            }
        }
    }
}
