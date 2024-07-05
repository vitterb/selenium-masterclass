using MasterClassProject.Domain.Entities;

namespace MasterClass.NetAPITests
{
    public class DomainTests
    {
        [Fact]
        public void Company_IdProperty_SetAndGetCorrectly()
        {
            // Arrange
            long expectedId = 1;
            Company company = new Company();

            // Act
            company.Id = expectedId;
            long actualId = company.Id;

            // Assert
            Assert.Equal(expectedId, actualId);
        }

        [Fact]
        public void Company_NameProperty_SetAndGetCorrectly()
        {
            // Arrange
            string expectedName = "TestCompany";
            Company company = new Company();

            // Act
            company.Name = expectedName;
            string actualName = company.Name;

            // Assert
            Assert.Equal(expectedName, actualName);
        }

        [Fact]
        public void Company_UsersProperty_SetAndGetCorrectly()
        {
            // Arrange
            List<User> expectedUsers = new List<User>
            {
                new User { Id = 1, Name = "User1" },
                new User { Id = 2, Name = "User2" }
            };
            Company company = new Company();

            // Act
            company.Users = expectedUsers;
            List<User> actualUsers = company.Users;

            // Assert
            Assert.Equal(expectedUsers, actualUsers);
        }

        [Fact]
        public void TimeRegistration_IdProperty_SetAndGetCorrectly()
        {
            // Arrange
            long expectedId = 1;
            TimeRegistration timeRegistration = new TimeRegistration("Test Description", DateTime.UtcNow, DateTime.UtcNow);

            // Act
            timeRegistration.Id = expectedId;
            long actualId = timeRegistration.Id;

            // Assert
            Assert.Equal(expectedId, actualId);
        }

        [Fact]
        public void TimeRegistration_UserIdProperty_SetAndGetCorrectly()
        {
            // Arrange
            long expectedUserId = 2;
            TimeRegistration timeRegistration = new TimeRegistration("Test Description", DateTime.UtcNow, DateTime.UtcNow);

            // Act
            timeRegistration.UserId = expectedUserId;
            long actualUserId = timeRegistration.UserId;

            // Assert
            Assert.Equal(expectedUserId, actualUserId);
        }

        [Fact]
        public void TimeRegistration_DescriptionProperty_SetAndGetCorrectly()
        {
            // Arrange
            string expectedDescription = "Test Description";
            TimeRegistration timeRegistration = new TimeRegistration(expectedDescription, DateTime.UtcNow, DateTime.UtcNow);

            // Act
            string actualDescription = timeRegistration.Description;

            // Assert
            Assert.Equal(expectedDescription, actualDescription);
        }

        [Fact]
        public void TimeRegistration_StartProperty_SetAndGetCorrectly()
        {
            // Arrange
            DateTime expectedStart = DateTime.UtcNow;
            TimeRegistration timeRegistration = new TimeRegistration("Test Description", expectedStart, DateTime.UtcNow);

            // Act
            DateTime actualStart = timeRegistration.Start;

            // Assert
            Assert.Equal(expectedStart, actualStart);
        }

        [Fact]
        public void TimeRegistration_StopProperty_SetAndGetCorrectly()
        {
            // Arrange
            DateTime start = DateTime.UtcNow;
            DateTime expectedStop = start.AddHours(1);
            TimeRegistration timeRegistration = new TimeRegistration("Test Description", start, expectedStop);

            // Act
            DateTime actualStop = timeRegistration.Stop;

            // Assert
            Assert.Equal(expectedStop, actualStop);
        }

        [Fact]
        public void User_IdProperty_SetAndGetCorrectly()
        {
            // Arrange
            long expectedId = 1;
            User user = new User();

            // Act
            user.Id = expectedId;
            long actualId = user.Id;

            // Assert
            Assert.Equal(expectedId, actualId);
        }

        [Fact]
        public void User_CompanyIdProperty_SetAndGetCorrectly()
        {
            // Arrange
            long expectedCompanyId = 2;
            User user = new User();

            // Act
            user.CompanyId = expectedCompanyId;
            long actualCompanyId = user.CompanyId;

            // Assert
            Assert.Equal(expectedCompanyId, actualCompanyId);
        }

        [Fact]
        public void User_NameProperty_SetAndGetCorrectly()
        {
            // Arrange
            string expectedName = "TestUser";
            User user = new User();

            // Act
            user.Name = expectedName;
            string actualName = user.Name;

            // Assert
            Assert.Equal(expectedName, actualName);
        }

        [Fact]
        public void User_TimeRegistrationsProperty_SetAndGetCorrectly()
        {
            // Arrange
            List<TimeRegistration> expectedTimeRegistrations = new List<TimeRegistration>
                {
                    new TimeRegistration("Task 1", DateTime.UtcNow, DateTime.UtcNow),
                    new TimeRegistration("Task 2", DateTime.UtcNow, DateTime.UtcNow)
                };
            User user = new User();

            // Act
            user.TimeRegistrations = expectedTimeRegistrations;
            List<TimeRegistration> actualTimeRegistrations = user.TimeRegistrations;

            // Assert
            Assert.Equal(expectedTimeRegistrations, actualTimeRegistrations);
        }
    }
}