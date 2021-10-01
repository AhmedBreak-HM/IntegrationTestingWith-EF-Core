using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingWith_EF_Core.Contracts
{
    public interface IBaseRepository<T> where T:class
    {
        List<T> GetEntities();
        T GetEntityById(int id );
        void AddEntity(T entity);
    }
}
