using FluentAssertions;
using IntegrationTestingWith_EF_Core.Contracts;
using IntegrationTestingWith_EF_Core.Data;
using IntegrationTestingWith_EF_Core.Models;
using IntegrationTestingWith_EF_Core.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationTestingWith_EF_Core_Test
{
    [TestClass]
    public class UserRepositoryTest
    {
        // Given_whene_Then
        [TestMethod]
        public void AddEntity_WithGoodUser_Should_Save()
        {
            // Arrang

            var userToCreate = new User
            {
                Name = "Ahmed",
                Email = "Ahmed@live.com",
                BirthDate = new DateTime(1988, 5, 12)
            };
            var factory = new ApplicationDbContextTest();
            ApplicationDbContext context = factory.Create();

            var repo = new UserRepository(context);

            // Act

            repo.AddEntity(userToCreate);

            // Assert

            var userFromRepo = repo.GetUserByName("Ahmed");

            userFromRepo.Should().BeEquivalentTo(userToCreate);
        }

        [TestMethod]
        public void GetEntities_WithDatabase_Return_ListOfUsers()
        {
            // arrang

            var userToCreate = new User
            {
                Name = "Ahmed",
                Email = "Ahmed@live.com",
                BirthDate = new DateTime(1988, 5, 12)
            };
            var userToFind = new User
            {
                Id = 1,
                Name = "Ahmed",
                Email = "Ahmed@live.com",
                BirthDate = new DateTime(1988, 5, 12)
            };

            var factory = new ApplicationDbContextTest();
            var repo = new UserRepository(new ApplicationDbContext(factory._options));


            // Act
            using (var transaction = factory.Create().Database.BeginTransaction())
            {

                repo.AddEntity(userToCreate);

                var usersFromRepo = repo.GetEntities();

                var userFromList = usersFromRepo.FirstOrDefault(u => u.Name == userToFind.Name);

                // Assert

                usersFromRepo.Should().NotBeNullOrEmpty();

                userToFind.Should().BeEquivalentTo(userFromList);

                transaction.Commit();
            }
        }

        [TestMethod]
        public void GetEntities_WithMokqData_Return_ListOfUsers()
        {
            var users = new List<User>()
            {
                new User
                {
                    Id = 1,
                    Name = "Ahmed",
                    Email = "Ahmed@live.com",
                    BirthDate = new DateTime(1988, 5, 12)

                },
                new User
                {
                    Id = 2,
                    Name = "Mohamed",
                    Email = "Mohamed@live.com",
                    BirthDate = new DateTime(1978, 3, 22)
                }

            };

            Mock<IUserRepository> repo = new Mock<IUserRepository>();

            repo.Setup(u => u.GetEntities()).Returns(users);

            var usersMoq = new UserCotrollerTest(repo.Object);


            usersMoq.Should().NotBeNull();

            users.Should().HaveCountGreaterOrEqualTo(2);
        }
    }
}
