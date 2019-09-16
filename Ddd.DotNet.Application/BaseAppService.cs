using Ddd.DotNet.Application.Interface;
using Ddd.DotNet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddd.DotNet.Application
{
    public class BaseAppService<TEntity> : IDisposable, IBaseAppService<TEntity> where TEntity : class
    {
        private readonly IBaseService<TEntity> _baseService;

        public BaseAppService(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        public void Add(TEntity obj)
        {
            _baseService.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _baseService.GetAll();
        }

        public TEntity GetById(int Id)
        {
            return _baseService.GetById(Id);
        }

        public void Remove(TEntity obj)
        {
            _baseService.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _baseService.Update(obj);
        }

        public void Dispose()
        {
            _baseService.Dispose();
        }

    }
}
