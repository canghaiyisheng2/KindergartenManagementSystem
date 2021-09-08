using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindergartenManagementSystem.ViewModels
{
    public class HomeIndexList
    {
        public List<process> processes { get; set; }

        public HomeIndexList(List<process> processes)
        {
            this.processes = processes;
        }
    }
}
