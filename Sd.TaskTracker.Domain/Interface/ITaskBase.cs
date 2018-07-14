using System.Collections.Generic;

namespace SD.TaskTracker.Domain.Interface
{
    public interface ITaskBase<T>
    {
        List<T> Get();
    }
}
