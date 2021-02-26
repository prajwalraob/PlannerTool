using PlannerTool.Models;

namespace PlannerTool.TaskCreation
{
    interface ICreateTask
    {
        ITaskItem TaskObject { get; set; }
        void CreateTaskEntry();
    }
}