using System.Collections.Generic;

namespace SD.TaskTracker.Data.Interface.Query
{
    public interface IQueryBase<T>
    {
        List<T> Get();
    }
}
