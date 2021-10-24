using System;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.Api.Controllers;
using Bookstore.Api.Dtos;
using Bookstore.Api.IRepository;
using Bookstore.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Bookstore.UnitTests
{
    public class AuthorsControllerTest
    {
        private readonly Mock<IUnitOfWork> repositoryStub = new();
        private readonly Mock<ILogger<AuthorsController>> loggerStub = new Mock<ILogger<AuthorsController>>();
        private readonly Mock<IMapper> mapperStub = new();
        private readonly Random random = new();
        
        [Fact]
        public async Task GetAuthorById_WithUnexistingAuthor_ReturnsNotFound()
        {
            // Arrange
            repositoryStub.Setup(repo => repo.Authors.Get(a => a.Id==It.IsAny<int>(), null))
                .ReturnsAsync((Authors)null);

            var controller = new AuthorsController(repositoryStub.Object, loggerStub.Object, mapperStub.Object);
            
            // Act
            var result = await controller.GetAuthorById(0);
            
            // Assert
            Assert.Null(result.Value);
        }
        
        
        [Fact]
        public async Task GetAuthorById_WithExistingAuthor_ReturnsAuthor()
        {
            
            // Arrange
            var authorDto = CreateRandomItem();
            var author = mapperStub.Object.Map<Authors>(authorDto);

            repositoryStub.Setup(repo => repo.Authors.Get(a => a.Id==It.IsAny<int>(), null))
                .ReturnsAsync(author);

            var controller = new AuthorsController(repositoryStub.Object, loggerStub.Object, mapperStub.Object);
            
            // Act
            var result = await controller.GetAuthorById(1);

            // Assert
            Assert.IsType<AuthorReadDto>(result.Value);
            var dtoResult = (result as ActionResult<AuthorReadDto>).Value;
            Assert.Equal(author.Id, dtoResult.Id);
        }
        

        private AuthorReadDto CreateRandomItem()
        {
            return new AuthorReadDto()
            {
                Id = 1,
                nome = "Dercio Derone",
                Books = null
            };
        }
    }
    
}
