using HW2.DAL.Abstract;
using HW2.DAL.Concrete;
using HW2.Models;
using Microsoft.EntityFrameworkCore;
using Moq;


namespace HW2_Tests
{
    public class RoleRepository_Tests
    {
        private Mock<StreamingDbContext> _mockContext;
        private Mock<DbSet<Role>> _mockRoleDbSet;
        private List<Role> _roles;
        private List<Credit> _credits;

        // Now that this is in 2 places we should move it to a common location, say MockDbHelpers.cs ?
        private static Mock<DbSet<T>> GetMockDbSet<T>(IQueryable<T> entities) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(entities.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());
            return mockSet;
        }

        [SetUp]
        public void Setup()
        {
            _roles = new List<Role>
            {
                new Role { Id = 1, RoleName = "ACTOR" },
                new Role { Id = 2, RoleName = "DIRECTOR" }
            };

            _credits = new List<Credit>
            {
                new Credit { Id = 1, ShowId = 1, RoleId = 1, PersonId = 1 },
                new Credit { Id = 2, ShowId = 1, RoleId = 2, PersonId = 2 },
                new Credit { Id = 3, ShowId = 2, RoleId = 1, PersonId = 3 },
                new Credit { Id = 4, ShowId = 2, RoleId = 2, PersonId = 4 },
                new Credit { Id = 5, ShowId = 3, RoleId = 1, PersonId = 5 },
                new Credit { Id = 6, ShowId = 3, RoleId = 2, PersonId = 6 },
                new Credit { Id = 7, ShowId = 4, RoleId = 1, PersonId = 7 },
                new Credit { Id = 8, ShowId = 4, RoleId = 2, PersonId = 2 },
                new Credit { Id = 9, ShowId = 5, RoleId = 1, PersonId = 9 },
                new Credit { Id = 10, ShowId = 5, RoleId = 2, PersonId = 10 },
                new Credit { Id = 11, ShowId = 6, RoleId = 1, PersonId = 11 },
                new Credit { Id = 12, ShowId = 6, RoleId = 2, PersonId = 2 },
            };

            // Set navigation properties for the "to-many" Credits property of Role
            _roles.ForEach(r => r.Credits = _credits.Where(c => c.RoleId == r.Id).ToList());

            _mockContext = new Mock<StreamingDbContext>();
            _mockRoleDbSet = GetMockDbSet(_roles.AsQueryable());
            _mockContext.Setup(ctx => ctx.Roles).Returns(_mockRoleDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Role>()).Returns(_mockRoleDbSet.Object);
        }

        [Test]
        public void DirectorWithTheMostShows_ReturnsCorrectDirectorId()
        {
            // Arrange
            IRoleRepository repo = new RoleRepository(_mockContext.Object);

            // Act
            var (directorId, showIds) = repo.DirectorWithTheMostShows();

            // Assert
            Assert.That(directorId, Is.EqualTo(2));
        }

        [Test]
        public void DirectorWithTheMostShows_ReturnsCorrectShowIds()
        {
            // Arrange
            IRoleRepository repo = new RoleRepository(_mockContext.Object);

            // Act
            var (directorId, showIds) = repo.DirectorWithTheMostShows();

            // Assert
            Assert.That(showIds, Is.EquivalentTo(new List<int> { 1, 4, 6 }));
        }


    }
}
