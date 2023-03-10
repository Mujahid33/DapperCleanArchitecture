using Application.Interfaces;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ITaskToDoRepository taskToDoRepository)
        {
            TasksToDo = taskToDoRepository;
        }

        public ITaskToDoRepository TasksToDo { get; }
    }
}
