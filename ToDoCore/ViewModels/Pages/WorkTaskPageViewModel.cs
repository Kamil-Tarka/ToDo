using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDoCore.ViewModels.Controls;

namespace ToDoCore.ViewModels.Pages
{
    public class WorkTaskPageViewModel
    {
        public List<WorkTaskViewModel> WorkTaskList { get; set; }
        public string NewWorkTaskTitle { get; set; }
        public string NewWorkTaskDescription { get; set; }
        public DateTime CreatedDate { get; set; }

        private void AddNewTask()
        {
        }
    }
}