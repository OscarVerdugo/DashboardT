using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Contracts
{
    public interface IBaseRespository<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> Get();
    }
}
