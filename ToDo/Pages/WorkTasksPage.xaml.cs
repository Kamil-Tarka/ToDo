using System.Windows.Controls;

using ToDoCore;

namespace ToDo
{
    /// <summary>
    /// Interaction logic for WorkTasksPage.xaml
    /// </summary>
    public partial class WorkTasksPage : Page
    {
        public WorkTasksPage()
        {
            InitializeComponent();
            DataContext = new WorkTaskPageViewModel();
        }
    }
}