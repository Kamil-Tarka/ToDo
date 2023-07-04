using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ToDoCore
{
    public class WorkTaskPageViewModel : BaseViewModel
    {
        public ObservableCollection<WorkTaskViewModel> WorkTaskList { get; set; } = new ObservableCollection<WorkTaskViewModel>();
        public string NewWorkTaskTitle { get; set; }
        public string NewWorkTaskDescription { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICommand AddNewTaskCommand { get; set; }

        public ICommand RemoveNewTaskCommand { get; set; }

        public WorkTaskPageViewModel()
        {
            AddNewTaskCommand = new RelayCommand(AddNewTask);
            RemoveNewTaskCommand = new RelayCommand(DeleteSelectedTasks);
        }

        private void AddNewTask()
        {
            var newTask = new WorkTaskViewModel
            {
                Title = NewWorkTaskTitle,
                Description = NewWorkTaskDescription,
                CreatedDate = DateTime.Now,
            };

            WorkTaskList.Add(newTask);

            NewWorkTaskTitle = string.Empty;
            NewWorkTaskDescription = string.Empty;

            //OnPropertyChanged(nameof(NewWorkTaskTitle));
            //OnPropertyChanged(nameof(NewWorkTaskDescription));
        }

        private void DeleteSelectedTasks()
        {
            var selectedTasks = WorkTaskList.Where(t => t.IsSelected).ToList();
            foreach (var task in selectedTasks)
            {
                WorkTaskList.Remove(task);
            }
        }
    }
}