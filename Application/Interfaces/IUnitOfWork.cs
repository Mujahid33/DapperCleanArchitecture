namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        ITaskToDoRepository TasksToDo { get; }
    }
}
