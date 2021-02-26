using Autofac;
using PlannerTool.Models;
using PlannerTool.TaskCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerTool
{
    public static class AutofacConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<TaskItem>().As<ITaskItem>();
            builder.RegisterType<CreateWindowsTask>().As<ICreateTask>();

            GlobalVariables.Container = builder.Build();
        }
    }
}
