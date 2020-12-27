using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerTool.Model
{
    class ReadTask
    {
        public TaskItem TaskObject { get; private set; }

        public ReadTask(string title, string body, DateTime date, int hour, int minute)
        {
            TaskObject = new TaskItem();
            TaskObject.Title = title;
            TaskObject.Body = body;
            TimeSpan timeSpan = new TimeSpan(hour, minute, 0);
            TaskObject.DateTimeInfo = date + timeSpan;
        }
    }
}
