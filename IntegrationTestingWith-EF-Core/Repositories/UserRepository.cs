using IntegrationTestingWith_EF_Core.Contracts;
using IntegrationTestingWith_EF_Core.Data;
using IntegrationTestingWith_EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingWith_EF_Core.Repositories
{
    public class UserRepository:BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;


        public UserRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }


        public User GetUserByName(string name)
        {
            return _context.Users.FirstOrDefault(u => u.Name == name);
        }
    }
}
