using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.CICDFlow.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Test.CICDFlow.Controllers.Tests
{
    public class HomeControllerTests
    {
        public HomeControllerTests()
        {
            var mockLogger = new Mock<ILogger<HomeController>>();
            homeController = new HomeController(mockLogger.Object);
        }

        private readonly HomeController homeController;


        [Fact]
        public void GetTest()
        {
            //ACT

            //ARRANGE
            var result=homeController.Get();

            //ASSERT
            var successResult=result.Should().BeOfType<OkObjectResult>();
            successResult.Subject.StatusCode.Should().Be(200);
            successResult.Subject.Value.Should().Be("testcicd");

        }
    }
}