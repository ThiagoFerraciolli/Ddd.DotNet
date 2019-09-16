using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddd.DotNet.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int Id);

        IEnumerable<TEntity> GetAll();

        void Remove(TEntity obj);

        void Update(TEntity obj);

        void Dispose();
    }
}
