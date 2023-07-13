using System.Windows;

using ToDoCore.Helpers;

using ToDoDatabase;

namespace ToDo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var dbContext = new ToDoDbContext();

            dbContext.Database.EnsureCreated();

            DataBaseLocator.DbContext = dbContext;
        }
    }
}