using AspNetCoreFroTest.Web.Bll;
using AspNetCoreFroTest.Web.Controllers;
using AspNetCoreFroTest.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace AspNetCoreFroTest.UnitTest
{
    public class LoginController_Test
    {
        [Fact]
        public void Index_Test_Success()
        {
            // Arrange
            var mockBiz = new Mock<ILoginBiz>();
            mockBiz.Setup(m => m.Login("sky","123")).Returns(true);
            var controller = new LoginController(mockBiz.Object);

            // Act
            var result = controller.Index(new Customer() { Name = "sky", PW = "123" });

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            //Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Success", redirectToActionResult.ActionName);
            mockBiz.Verify();
        }

        [Fact]
        public void Index_Test_False()
        {
            // Arrange
            var mockBiz = new Mock<ILoginBiz>();
            mockBiz.Setup(m => m.Login("sky", "1234")).Returns(true);
            var controller = new LoginController(mockBiz.Object);

            // Act
            var result = controller.Index(new Customer() { Name = "sky", PW = "123" });

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            //Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Fail", redirectToActionResult.ActionName);
            mockBiz.Verify();
        }
    }
}
