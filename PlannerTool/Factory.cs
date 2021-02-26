using PlannerTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerTool
{
    public static class Factory
    {
        public static ITaskItem GetTaskItem(string title, string body, DateTime date, int hour, int minute)
        {
            var taskObject = new TaskItem();
            taskObject.Title = title;
            taskObject.Body = body;
            TimeSpan timeSpan = new TimeSpan(hour, minute, 0);
            taskObject.DateTimeInfo = date + timeSpan;
            return taskObject;
        }
    }
}
