using Ddd.DotNet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddd.DotNet.Domain.Services
{
    public class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void Add(TEntity obj)
        {
            _baseRepository.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public TEntity GetById(int Id)
        {
            return _baseRepository.GetById(Id);
        }

        public void Remove(TEntity obj)
        {
            _baseRepository.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _baseRepository.Update(obj);
        }

        public void Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}
