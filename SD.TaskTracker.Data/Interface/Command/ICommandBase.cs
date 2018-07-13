namespace SD.TaskTracker.Data.Interface.Command
{
    public interface ICommandBase<T>
    {
        bool Add(T t);
    }
}
