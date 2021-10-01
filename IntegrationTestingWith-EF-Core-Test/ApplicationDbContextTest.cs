using IntegrationTestingWith_EF_Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingWith_EF_Core_Test
{
    public class ApplicationDbContextTest
    {
        public readonly DbContextOptions<ApplicationDbContext> _options;
        public ApplicationDbContextTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "Test")
               .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
               .Options;
            _options = options;
        }

        public ApplicationDbContext Create()
        {
            return new ApplicationDbContext(_options);
        }

    }
}
