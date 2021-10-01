using IntegrationTestingWith_EF_Core.Contracts;
using IntegrationTestingWith_EF_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingWith_EF_Core_Test
{
    public class UserCotrollerTest
    {
        private readonly IUserRepository _userRepository;

        public UserCotrollerTest(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetEntities();
        }
    }
}
