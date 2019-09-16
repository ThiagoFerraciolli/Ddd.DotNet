using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddd.DotNet.Application.Interface
{
    public interface IBaseAppService<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int Id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}
