using ToDoDatabase;

namespace ToDoCore.Helpers
{
    public class DataBaseLocator
    {
        public static ToDoDbContext DbContext { get; set; }
    }
}