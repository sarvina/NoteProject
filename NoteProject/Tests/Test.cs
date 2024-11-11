using System;
using Xunit;
using NoteProject.Service.Interfaces;

namespace NoteProject.Tests
{
    public class UserServiceTests
    {
        private readonly IUserService _userService;

        public UserServiceTests()
        {
            _userService = new UserService();
        }

        [Fact]
        public void ValidateUser_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            string username = "sarvina";
            string password = "1234";

            // Act
            bool result = _userService.ValidateUser(username, password);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidateUser_InvalidPassword_ReturnsFalse()
        {
            // Arrange
            string username = "sarvina";
            string password = "wrongpassword";

            // Act
            bool result = _userService.ValidateUser(username, password);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateUser_InvalidUsername_ReturnsFalse()
        {
            // Arrange
            string username = "wronguser";
            string password = "1234";

            // Act
            bool result = _userService.ValidateUser(username, password);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(null, "1234")]
        [InlineData("sarvina", null)]
        [InlineData(null, null)]
        public void ValidateUser_NullUsernameOrPassword_ReturnsFalse(string username, string password)
        {
            // Act
            bool result = _userService.ValidateUser(username, password);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("", "1234")]
        [InlineData("sarvina", "")]
        [InlineData("", "")]
        public void ValidateUser_EmptyUsernameOrPassword_ReturnsFalse(string username, string password)
        {
            // Act
            bool result = _userService.ValidateUser(username, password);

            // Assert
            Assert.False(result);
        }
    }
}
