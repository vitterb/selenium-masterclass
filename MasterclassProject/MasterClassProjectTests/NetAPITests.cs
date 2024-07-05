using MasterClassProject.Controllers;
using MasterClassProject.Domain.Entities;
using MasterClassProject.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace MasterClass.NetAPITests
{
    public class ApplicationTests
    {
        [Fact]
        public async Task GetAll_ReturnsOkWithListOfEntities()
        {
            // Arrange
            var entities = new List<Company>
            {
                new Company { Id = 1, Name = "Entity1" },
                new Company { Id = 2, Name = "Entity2" },
            };

            var serviceMock = new Mock<IGenericService<Company>>();
            serviceMock.Setup(x => x.GetAll()).ReturnsAsync(entities);

            var controller = new GenericController<Company>(serviceMock.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<List<Company>>(okResult.Value);
            Assert.Equal(entities, model);
        }

        [Fact]
        public async Task GetById_ReturnsOkWithEntity()
        {
            // Arrange
            var entityId = 1L;
            var entity = new Company { Id = entityId, Name = "Entity1" };

            var serviceMock = new Mock<IGenericService<Company>>();
            serviceMock.Setup(x => x.GetById(entityId)).ReturnsAsync(entity);

            var controller = new GenericController<Company>(serviceMock.Object);

            // Act
            var result = await controller.GetById(entityId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Company>(okResult.Value);
            Assert.Equal(entity, model);
        }

        [Fact]
        public async Task Add_ReturnsOkWithAddedEntity()
        {
            // Arrange
            var entityToAdd = new Company { Id = 1, Name = "Entity1" };

            var serviceMock = new Mock<IGenericService<Company>>();
            serviceMock.Setup(x => x.Add(entityToAdd)).ReturnsAsync(entityToAdd);

            var controller = new GenericController<Company>(serviceMock.Object);

            // Act
            var result = await controller.Add(entityToAdd);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Company>(okResult.Value);
            Assert.Equal(entityToAdd, model);
        }

        [Fact]
        public async Task Update_ReturnsOkWithUpdatedEntity()
        {
            // Arrange
            var entityId = 1L;
            var updatedEntity = new Company { Id = entityId, Name = "UpdatedEntity" };

            var serviceMock = new Mock<IGenericService<Company>>();
            serviceMock.Setup(x => x.Update(updatedEntity)).ReturnsAsync(updatedEntity);

            var controller = new GenericController<Company>(serviceMock.Object);

            // Act
            var result = await controller.Update(updatedEntity);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Company>(okResult.Value);
            Assert.Equal(updatedEntity, model);
        }

        [Fact]
        public async Task Delete_ReturnsNoContent()
        {
            // Arrange
            var entityId = 1L;

            var serviceMock = new Mock<IGenericService<Company>>();
            serviceMock.Setup(x => x.Delete(entityId)).Returns(Task.CompletedTask);

            var controller = new GenericController<Company>(serviceMock.Object);

            // Act
            var result = await controller.Delete(entityId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}