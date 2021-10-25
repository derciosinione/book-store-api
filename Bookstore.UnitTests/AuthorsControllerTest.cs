using System;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.Api.Controllers;
using Bookstore.Api.Dtos;
using Bookstore.Api.IRepository;
using Bookstore.Api.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Bookstore.UnitTests
{
    public class AuthorsControllerTest
    {
        private readonly Mock<IUnitOfWork> _repositoryStub;
        private readonly Mock<ILogger<AuthorsController>> _loggerStub;
        private readonly Mock<IMapper> _mapperStub;

        public AuthorsControllerTest()
        {
            _repositoryStub = new Mock<IUnitOfWork>();
            _loggerStub = new Mock<ILogger<AuthorsController>>();
            _mapperStub = new Mock<IMapper>();
        }
        
        [Fact]
        public async Task GetAuthorById_WithUnexistingAuthor_ReturnsNotFound()
        {
            // Arrange
            _repositoryStub.Setup(repo => repo.Authors.Get(a => a.Id==It.IsAny<int>(), null))
                .ReturnsAsync((Authors)null);

            var controller = new AuthorsController(_repositoryStub.Object, _loggerStub.Object, _mapperStub.Object);

            // Act
            var result = await controller.GetAuthorById(0);
            
            // Assert
            Assert.Null(result.Value);
        }
        
        
        [Fact]
        public async Task GetAuthors_WithExistingAuthor_ReturnsAuthors()
        {
            // Arrange
            var autors = CreateRandomItem();
            _repositoryStub.Setup(repo => repo.Authors.Get(a => a.Id==It.IsAny<int>(), null))
                .ReturnsAsync(autors);

            var controller = new AuthorsController(_repositoryStub.Object, _loggerStub.Object, _mapperStub.Object);
            
            // Act
            var result = await controller.GetAllAuthors(null);
            
            // Assert
            result.Should().BeEquivalentTo(
                autors, op => op.ComparingByMembers<AuthorReadDto>()
            );
        }

        private Authors CreateRandomItem()
        {
            return new Authors()
            {
                Id = 1,
                nome = "Dercio Derone",
            };
        }
    }
    
}
