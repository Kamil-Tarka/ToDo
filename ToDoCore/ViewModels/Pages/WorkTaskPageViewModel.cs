using System.Collections.ObjectModel;
using System.Windows.Input;

using ToDoCore.Helpers;

using ToDoDatabase.Entities;

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

            foreach (var task in DataBaseLocator.DbContext.WorkTasks.ToList())
            {
                WorkTaskList.Add(new WorkTaskViewModel
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    CreatedDate = task.CreatedDate
                });
            }
        }

        private void AddNewTask()
        {
            var newTask = new WorkTaskViewModel
            {
                Title = NewWorkTaskTitle,
                Description = NewWorkTaskDescription,
                CreatedDate = DateTime.Now
            };

            WorkTaskList.Add(newTask);

            DataBaseLocator.DbContext.WorkTasks.Add(new WorkTask
            {
                Title = newTask.Title,
                Description = newTask.Description,
                CreatedDate = newTask.CreatedDate
            });

            DataBaseLocator.DbContext.SaveChanges();

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

                var workTaskToDelete = DataBaseLocator.DbContext.WorkTasks
                    .FirstOrDefault(w => w.Id == task.Id);
                if (workTaskToDelete != null)
                {
                    DataBaseLocator.DbContext.WorkTasks.Remove(workTaskToDelete);
                }
            }
            DataBaseLocator.DbContext.SaveChanges();
        }
    }
}