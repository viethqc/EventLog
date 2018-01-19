using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using System.Xml;

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
            XmlDocument doc = new XmlDocument();
            XmlNodeList nodeList = null;
            XmlNode nodeEventData = null;
            XmlNode nodeData = null;
            XmlNodeList nodeListData = null;
            string sAttributeName = "";
            string sInnerText = "";

            string text = "";
            for (EventRecord eventInstance = elReader.ReadEvent(); eventInstance != null; eventInstance = elReader.ReadEvent())
            {
                text = eventInstance.ToXml();
                doc.LoadXml(text);
                nodeList = doc.GetElementsByTagName("EventData");
                if (nodeList.Count != 1)
                {
                    continue;
                }
                nodeEventData = nodeList.Item(0);
                nodeListData = nodeEventData.ChildNodes;
                for (int i = 0; i < nodeListData.Count; i++)
                {
                    nodeData = nodeListData.Item(i);
                    sAttributeName = nodeData.Attributes["Name"].Value;
                    sInnerText = nodeData.InnerText;
                    int a = 9;
                    a++;
                }

                string b = "d";
                count++;
            }

            return;
        }
    }
}
