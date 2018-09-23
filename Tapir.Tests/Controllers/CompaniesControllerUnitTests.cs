using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using Tapir.Controllers;
using Tapir.Core;

namespace Tapir.Tests.UnitTests.Controllers
{
    public class CompaniesControllerUnitTests
    {
        List<CompanyDto> companies = new List<CompanyDto>
        {
            new CompanyDto() { ID = 1, FullName = "Company1 Ltd", ShortName = "Ltd1"},
            new CompanyDto() { ID = 2, FullName = "Company2 Ltd", ShortName = "Ltd2"},
            new CompanyDto() { ID = 3, FullName = "Company3 Ltd", ShortName = "Ltd3"}
        };

        [Fact]
        public void GetAllReturnsAllCompanies()
        {
            var mockService = new Mock<ICompanyService>();
            mockService.Setup(s => s.GetCompanies()).Returns(companies);
            var controller = new CompaniesController(mockService.Object);

            var result = controller.GetAll();

            mockService.Verify(x => x.GetCompanies(), Times.Once);
            Assert.IsType<List<CompanyDto>>(result.Value);
            List<CompanyDto> resultList = result.Value;
            Assert.Equal(companies.Count, resultList.Count);
            foreach (CompanyDto c in resultList)
            {
                Assert.NotNull(companies.Find(o => o.ID == c.ID));
            }
        }

        [Fact]
        public void GetByIdReturnsCompany()
        {
            var mockService = new Mock<ICompanyService>();
            mockService.Setup(s => s.GetCompany(2)).Returns(companies[1]);
            var controller = new CompaniesController(mockService.Object);

            var result = controller.GetById(2);

            mockService.Verify(x => x.GetCompany(2), Times.Once);
            Assert.IsType<CompanyDto>(result.Value);
            Assert.Equal(2, result.Value.ID);
        }

        [Fact]
        public void GetByIdReturnsNotFoundOnNonexistingId()
        {
            var mockService = new Mock<ICompanyService>();
            mockService.Setup(s => s.GetCompany(4)).Returns<CompanyDto>(null);
            var controller = new CompaniesController(mockService.Object);

            var result = controller.GetById(4);

            mockService.Verify(x => x.GetCompany(4), Times.Once);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreatesCompany()
        {
            var mockService = new Mock<ICompanyService>();
            mockService.Setup(s => s.SaveCompany(It.IsAny<CompanyDto>())).Returns((CompanyDto c) => c);
            var controller = new CompaniesController(mockService.Object);            

            CompanyDto testCo = new CompanyDto() { FullName = "TestComp4", ShortName = "Test4" };
            var result = controller.Create(testCo);

            mockService.Verify(x => x.SaveCompany(It.IsAny<CompanyDto>()), Times.Once);
            Assert.IsType<CreatedAtRouteResult>(result.Result);
            CreatedAtRouteResult bottomResult = (CreatedAtRouteResult)result.Result;
            Assert.IsType<CompanyDto>(bottomResult.Value);
            Assert.Equal(testCo.FullName, ((CompanyDto)bottomResult.Value).FullName);
        }

        [Fact]
        public void CreatingInvalidCompanyReturnsBadRequest()
        {
            var mockService = new Mock<ICompanyService>();
            var controller = new CompaniesController(mockService.Object);
            controller.ModelState.AddModelError("FullName", "Fullname not set");

            CompanyDto testCo = new CompanyDto() { FullName = "TestComp4", ShortName = "Test4" };
            var result = controller.Create(testCo);

            mockService.Verify(x => x.SaveCompany(It.IsAny<CompanyDto>()), Times.Never);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void UpdatesCompany()
        {
            var mockService = new Mock<ICompanyService>();
            mockService.Setup(s => s.SaveCompany(It.IsAny<CompanyDto>())).Returns((CompanyDto c) => c);
            var controller = new CompaniesController(mockService.Object);

            CompanyDto testCo = new CompanyDto() { ID = 2, FullName = "TestComp4", ShortName = "Test4" };
            var result = controller.Update(2, testCo);

            mockService.Verify(x => x.SaveCompany(It.IsAny<CompanyDto>()), Times.Once);
            Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public void UpdatingInvalidCompanyReturnsBadRequest()
        {
            var mockService = new Mock<ICompanyService>();
            var controller = new CompaniesController(mockService.Object);
            controller.ModelState.AddModelError("FullName", "Fullname not set");

            CompanyDto testCo = new CompanyDto() { ID = 2, FullName = "TestComp4", ShortName = "Test4" };
            var result = controller.Create(testCo);

            mockService.Verify(x => x.SaveCompany(It.IsAny<CompanyDto>()), Times.Never);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void UpdatedCompanyWithInvalidIDReturnsNotFound()
        {
            var mockService = new Mock<ICompanyService>();
            mockService.Setup(s => s.SaveCompany(It.IsAny<CompanyDto>())).Returns((CompanyDto)null);
            var controller = new CompaniesController(mockService.Object);

            CompanyDto testCo = new CompanyDto() { ID = 4, FullName = "TestComp4", ShortName = "Test4" };
            var result = controller.Update(4, testCo);

            mockService.Verify(x => x.SaveCompany(It.IsAny<CompanyDto>()), Times.Once);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void DeletesCompany()
        {
            var mockService = new Mock<ICompanyService>();
            mockService.Setup(s => s.RemoveCompany(2)).Returns(companies[1]);
            var controller = new CompaniesController(mockService.Object);

            var result = controller.Delete(2);

            mockService.Verify(x => x.RemoveCompany(2), Times.Once);
            Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public void DeletingNonexistingCompanyRetursNotFound()
        {
            var mockService = new Mock<ICompanyService>();
            mockService.Setup(s => s.RemoveCompany(4)).Returns((CompanyDto)null);
            var controller = new CompaniesController(mockService.Object);

            var result = controller.Delete(4);

            mockService.Verify(x => x.RemoveCompany(4), Times.Once);
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
