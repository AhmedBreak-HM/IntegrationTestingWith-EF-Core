using IntegrationTestingWith_EF_Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingWith_EF_Core.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public List<T> GetEntities()
        {
            return _context.Set<T>().ToList();
        }

        public T GetEntityById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

    }
}
