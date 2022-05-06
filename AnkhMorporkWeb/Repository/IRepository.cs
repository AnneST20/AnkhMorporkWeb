using System.Collections.Generic;

namespace AnkhMorporkWeb.Repository
{
    public interface IRepository <T>
    {
        IEnumerable<T> GetAll();
        void Update(T model);
    }
}
