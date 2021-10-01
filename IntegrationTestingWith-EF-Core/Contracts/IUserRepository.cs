using IntegrationTestingWith_EF_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingWith_EF_Core.Contracts
{
    public interface IUserRepository:IBaseRepository<User>
    {
        User GetUserByName(string name);
    }
}
