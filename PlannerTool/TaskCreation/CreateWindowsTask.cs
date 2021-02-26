using System;
using System.Xml;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlannerTool.Models;
using PlannerTool;
using Newtonsoft.Json; 


namespace PlannerTool.TaskCreation
{
    class CreateWindowsTask : ICreateTask
    {
        public ITaskItem TaskObject { get; set; }
        private XmlDocument XmlDoc { get; set; }
        public CreateWindowsTask()
        {
            XmlDoc = new XmlDocument();
        }

        public void CreateTaskEntry()
        {
            string taskname = "UpdateMe";
            CreateXML(GetTaskJSON(), taskname);
            CreateBatch(xmlName: taskname);
        }

        private void CreateXML(string json, string xmlFileName = "Task")
        {
            XmlNode Declnode = XmlDoc.CreateXmlDeclaration("1.0", "UTF-16", string.Empty);

            XmlDoc.AppendChild(Declnode);

            XmlNode Listnode = XmlDoc.CreateElement("Task");
            XmlNode mainnode = XmlDoc.AppendChild(Listnode);

            XmlAttribute TaskAttribs = XmlDoc.CreateAttribute("version");
            TaskAttribs.Value = "1.3";
            Listnode.Attributes.Append(TaskAttribs);

            TaskAttribs = XmlDoc.CreateAttribute("xmlns");
            TaskAttribs.Value = "http://schemas.microsoft.com/windows/2004/02/mit/task";
            Listnode.Attributes.Append(TaskAttribs);


            XmlNode Triggers = XmlDoc.CreateElement("Triggers");
            XmlNode TimeTrigger = XmlDoc.CreateElement("TimeTrigger");

            string triggerTime = this.GetTriggerTime();
            SubNodeFor(ref TimeTrigger, "StartBoundary", triggerTime); // Timed trigger
            string endTime = this.GetEndTime();
            SubNodeFor(ref TimeTrigger, "EndBoundary", endTime);   // Set the end boundary 12hrs more
            SubNodeFor(ref TimeTrigger, "Enabled", "true");

            Triggers.AppendChild(TimeTrigger);
            Listnode.AppendChild(Triggers);

            XmlNode Settings = XmlDoc.CreateElement("Settings");

            SubNodeFor(ref Settings, "MultipleInstancesPolicy", "IgnoreNew");
            SubNodeFor(ref Settings, "DisallowStartIfOnBatteries", "true");
            SubNodeFor(ref Settings, "StopIfGoingOnBatteries", "true");
            SubNodeFor(ref Settings, "AllowHardTerminate", "true");
            SubNodeFor(ref Settings, "StartWhenAvailable", "true");
            SubNodeFor(ref Settings, "RunOnlyIfNetworkAvailable", "false");

            XmlNode idleSettings = XmlDoc.CreateElement("IdleSettings");

            SubNodeFor(ref idleSettings, "StopOnIdleEnd", "true");
            SubNodeFor(ref idleSettings, "RestartOnIdle", "false");

            Settings.AppendChild(idleSettings);

            SubNodeFor(ref Settings, "AllowStartOnDemand", "true");
            SubNodeFor(ref Settings, "Enabled", "true");
            SubNodeFor(ref Settings, "Hidden", "false");
            SubNodeFor(ref Settings, "RunOnlyIfIdle", "false");
            SubNodeFor(ref Settings, "DisallowStartOnRemoteAppSession", "false");
            SubNodeFor(ref Settings, "UseUnifiedSchedulingEngine", "false");
            SubNodeFor(ref Settings, "WakeToRun", "false");
            SubNodeFor(ref Settings, "ExecutionTimeLimit", "PT4H");
            SubNodeFor(ref Settings, "DeleteExpiredTaskAfter", "PT0S");
            SubNodeFor(ref Settings, "Priority", "7");

            Listnode.AppendChild(Settings);

            XmlNode actions = XmlDoc.CreateElement("Actions");

            XmlNode exec = XmlDoc.CreateElement("Exec");

            SubNodeFor(ref exec, "Command", Path.Combine(GlobalVariables.WorkingFolder, "Notifier.exe"));
            SubNodeFor(ref exec, "Arguments", json);
            actions.AppendChild(exec);
            Listnode.AppendChild(actions);

            XmlDoc.Save(Path.Combine(GlobalVariables.WorkingFolder, xmlFileName + ".xml")); // Name the file
        }

        private string GetTriggerTime()
        {
            return TaskObject.DateTimeInfo.ToString("yyyy-MM-dd") + "T" + TaskObject.DateTimeInfo.ToString("HH:mm:ss");
        }

        private string GetEndTime()
        {
            DateTime str;
            str = TaskObject.DateTimeInfo.AddMinutes(5);
            return str.ToString("yyyy-MM-dd") + "T" + str.ToString("HH:mm:ss");
        }

        private void SubNodeFor(ref XmlNode Parent, string childName, string value)
        {
            XmlNode childNode = XmlDoc.CreateElement(childName);
            childNode.AppendChild(XmlDoc.CreateTextNode(value));
            Parent.AppendChild(childNode);
        }

        private string GetTaskJSON()
        {
            if (!(TaskObject == null))
            {
                string jsonString = JsonConvert.SerializeObject(TaskObject).Replace("\"", "\\u022");
                return jsonString;
            }
            return null;
        }

        private void CreateBatch(string fileName = "TaskScript", string xmlName = "Task")
        {
            string taskName = xmlName + TaskObject.DateTimeInfo.ToString("ddmmyyyy");
            using (StreamWriter file = new StreamWriter(Path.Combine(GlobalVariables.WorkingFolder, fileName + ".bat")))
            {
                file.WriteLine("cd /d " + GlobalVariables.WorkingFolder);
                file.WriteLine("schtasks /create /XML " + xmlName + ".xml" + " /tn " + taskName);
            }
            Process.Start(Path.Combine(GlobalVariables.WorkingFolder, fileName + ".bat"));
        }

    }
}
