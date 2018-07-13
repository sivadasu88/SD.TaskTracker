namespace SD.TaskTracker.Domain.Interface
{
    public interface ITaskBase<T>
    {
        bool Add(T t);
    }
}
