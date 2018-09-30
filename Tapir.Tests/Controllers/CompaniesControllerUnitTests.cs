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
            new CompanyDto()
            {
                Id = 1,
                FullName = "Company1 Ltd",
                ShortName = "Ltd1",
                BusinessId = "1111-1",
                SectorId = 1,
                SectorCode = "0001",
                SectorName = "Agriculture",
                InsuranceNumber = "1111",
                BankAccount = "111-111"
            },
            new CompanyDto()
            {
                Id = 2,
                FullName = "Company2 Ltd",
                ShortName = "Ltd2",
                BusinessId = "22222-2",
                SectorId = 2,
                SectorCode = "0002",
                SectorName = "Mining",
                InsuranceNumber = "2222",
                BankAccount = "222-222"
            },
            new CompanyDto()
            {
                Id = 3,
                FullName = "Company3 Ltd",
                ShortName = "Ltd3",
                BusinessId = "33333-3",
                SectorId = 3,
                SectorCode = "0003",
                SectorName = "Oil refining",
                InsuranceNumber = "3333",
                BankAccount = "333-333"
            }
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
                Assert.NotNull(companies.Find(o => o.Id == c.Id));
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
            Assert.Equal(2, result.Value.Id);
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

            CompanyDto testCo = new CompanyDto() { Id = 2, FullName = "TestComp4", ShortName = "Test4" };
            var result = controller.Update(2, testCo);

            mockService.Verify(x => x.SaveCompany(It.IsAny<CompanyDto>()), Times.Once);
            Assert.IsType<OkObjectResult>(result.Result);
            OkObjectResult bottomResult = (OkObjectResult)result.Result;
            Assert.IsType<CompanyDto>(bottomResult.Value);
            Assert.Equal(2, ((CompanyDto)bottomResult.Value).Id);
        }

        [Fact]
        public void UpdatingInvalidCompanyReturnsBadRequest()
        {
            var mockService = new Mock<ICompanyService>();
            var controller = new CompaniesController(mockService.Object);
            controller.ModelState.AddModelError("FullName", "Fullname not set");

            CompanyDto testCo = new CompanyDto() { Id = 2, FullName = "TestComp4", ShortName = "Test4" };
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

            CompanyDto testCo = new CompanyDto() { Id = 4, FullName = "TestComp4", ShortName = "Test4" };
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
            Assert.IsType<OkObjectResult>(result.Result);
            OkObjectResult bottomResult = (OkObjectResult)result.Result;
            Assert.IsType<CompanyDto>(bottomResult.Value);
            Assert.Equal(2, ((CompanyDto)bottomResult.Value).Id);
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
