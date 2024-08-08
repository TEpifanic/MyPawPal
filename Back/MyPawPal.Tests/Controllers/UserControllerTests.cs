using Microsoft.AspNetCore.Mvc;
using Moq;
using MyPawPal.API.Controllers;
using MyPawPal.Application.DTOs;
using MyPawPal.Application.Interfaces;
using MyPawPal.Domain.Entities;

namespace MyPawPal.Tests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _mockUserService = new Mock<IUserService>();
            _controller = new UserController(_mockUserService.Object);
        }

        [Fact]
        public async Task GetUser_ReturnsOkResult_WhenUserExists()
        {
            // Arrange
            string userId = "user1";
            var user = new UserInfo { UserId = userId, Email = "test@example.com", FirstName = "John", LastName = "Doe", Age = 30 };
            _mockUserService.Setup(service => service.GetUserAsync(userId)).ReturnsAsync(new ActionResult<UserInfo>(user));

            // Act
            var result = await _controller.GetUser(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUser = Assert.IsType<UserDto>(okResult.Value);
            Assert.Equal(userId, returnedUser.UserId);
        }

        [Fact]
        public async Task GetUser_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            string userId = "nonexistent";
            _mockUserService.Setup(service => service.GetUserAsync(userId)).ReturnsAsync(new ActionResult<UserInfo>(new NotFoundResult()));

            // Act
            var result = await _controller.GetUser(userId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetDogsForUser_ReturnsOkResult_WithListOfDogs()
        {
            // Arrange
            string userId = "1";
            var dogs = new List<DogInfo>
            {
                new DogInfo { DogId = 1, Name = "Rex", Age = 5, Race = "Labrador", UserId = userId },
                new DogInfo { DogId = 1, Name = "Max", Age = 3, Race = "Bulldog", UserId = userId }
            };
            _mockUserService.Setup(service => service.GetDogsForUserAsync(userId)).ReturnsAsync(dogs);

            // Act
            var result = await _controller.GetDogsForUser(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedDogs = Assert.IsType<List<DogDto>>(okResult.Value);
            Assert.Equal(2, returnedDogs.Count);
        }

        [Fact]
        public async Task CreateUser_ReturnsCreatedAtActionResult_WhenUserIsCreated()
        {
            // Arrange
            var userDto = new UserDto { Email = "new@example.com", FirstName = "Jane", LastName = "Doe", Age = 25 };
            var createdUser = new UserInfo { UserId = "newuser", Email = userDto.Email, FirstName = userDto.FirstName, LastName = userDto.LastName, Age = userDto.Age };
            _mockUserService.Setup(service => service.CreateUserAsync(It.IsAny<UserInfo>())).Callback<UserInfo>(u => u.UserId = createdUser.UserId);

            // Act
            var result = await _controller.CreateUser(userDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetUser", createdAtActionResult.ActionName);
            Assert.Equal(createdUser.UserId, createdAtActionResult.RouteValues["id"]);
            var returnedUser = Assert.IsType<UserDto>(createdAtActionResult.Value);
            Assert.Equal(userDto.Email, returnedUser.Email);
        }
    }
}