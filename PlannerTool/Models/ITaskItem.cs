using System;

namespace PlannerTool.Models
{
    public interface ITaskItem
    {
        string Body { get; set; }
        DateTime DateTimeInfo { get; set; }
        string Title { get; set; }
    }
}