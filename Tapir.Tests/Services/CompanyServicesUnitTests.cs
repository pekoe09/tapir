using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using Tapir.Services;
using Tapir.Core;
using Tapir.Models;

namespace Tapir.UnitTests.Services
{
    public class CompanyServicesUnitTests
    {
        private readonly CompanyService companyService;
        private List<Company> companies;

        public CompanyServicesUnitTests()
        {
            companies = new List<Company>
            {
                new Company()
                {
                    ID =1,
                    FullName ="Company1 Ltd",
                    ShortName ="Ltd1",
                    BusinessId = "1111-1",
                    Sector = new BusinessSector()
                    {
                        ID = 1,
                        Code = "0001",
                        Name = "Agriculture"
                    },
                    InsuranceNumber = "1111",
                    BankAccount = "111-111"
                },
                new Company()
                {
                    ID =2,
                    FullName ="Company2 Ltd",
                    ShortName ="Ltd2",
                    BusinessId = "22222-2",
                    Sector = new BusinessSector()
                    {
                        ID = 2,
                        Code = "0002",
                        Name = "Mining"
                    },
                    InsuranceNumber = "2222",
                    BankAccount = "222-222"
                },
                new Company()
                {
                    ID =3,
                    FullName ="Company3 Ltd",
                    ShortName ="Ltd3",
                    BusinessId = "33333-3",
                    Sector = new BusinessSector()
                    {
                        ID = 3,
                        Code = "0003",
                        Name = "Oil refining"
                    },
                    InsuranceNumber = "3333",
                    BankAccount = "333-333"
                }
            };
            var mockRepository = new Mock<ICompaniesRepository>();
            mockRepository.Setup(x => x.GetAll()).Returns(companies);
            mockRepository.Setup(x => x.GetById(2)).Returns(companies[1]);
            mockRepository.Setup(x => x.Insert(It.IsAny<Company>())).Returns((Company c) => c);
            companyService = new CompanyService(mockRepository.Object);
        }

        [Fact]
        public void ReturnsAllCompanies()
        {
            var result = companyService.GetCompanies();

            Assert.IsType<List<CompanyDto>>(result);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void ReturnsCompanyByID()
        {
            var result = companyService.GetCompany(2);

            Assert.IsType<CompanyDto>(result);
            Assert.Equal(2, ((CompanyDto)result).Id);
        }

        [Fact]
        public void ReturnsNullWhenGettingByNonexistingId()
        {
            var result = companyService.GetCompany(500);

            Assert.Null(result);
        }

        [Fact]
        public void AddsCompany()
        {
            var mockRepository = new Mock<ICompaniesRepository>();
            mockRepository.Setup(x => x.Insert(It.IsAny<Company>()))
                .Returns((Company c) => new Company()
                {
                    ID = 4,
                    FullName = c.FullName,
                    ShortName = c.ShortName,
                    BusinessId = "44444-4",
                    Sector = new BusinessSector()
                    {
                        ID = 1,
                        Code = "0001",
                        Name = "Agriculture"
                    },
                    InsuranceNumber = "4444",
                    BankAccount = "444-444"
                });
            CompanyService service = new CompanyService(mockRepository.Object);

            CompanyDto dto = new CompanyDto()
            {
                FullName = "Company 4",
                ShortName = "Cny4",
                BusinessId = "44444-4",
                SectorId = 1,
                SectorCode = "0001",
                SectorName = "Agriculture",
                InsuranceNumber = "4444",
                BankAccount = "444-444"
            };
            var result = service.SaveCompany(dto);

            mockRepository.Verify(x => x.Insert(It.IsAny<Company>()), Times.Once);
            Assert.IsType<CompanyDto>(result);
            Assert.Equal(dto.FullName, result.FullName);
            Assert.Equal(dto.ShortName, result.ShortName);
            Assert.Equal(dto.BusinessId, result.BusinessId);
            Assert.Equal(dto.InsuranceNumber, result.InsuranceNumber);
            Assert.Equal(dto.BankAccount, result.BankAccount);
            Assert.NotNull(result.Id);
        }

        [Fact]
        public void AddingNullReturnsNull()
        {
            var mockRepository = new Mock<ICompaniesRepository>();
            CompanyService service = new CompanyService(mockRepository.Object);

            var result = service.SaveCompany(null);

            mockRepository.Verify(x => x.Insert(It.IsAny<Company>()), Times.Never);
            Assert.Null(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void AddingWithoutFullNameThrowsException(string fullName)
        {
            var mockRepository = new Mock<ICompaniesRepository>();
            CompanyService service = new CompanyService(mockRepository.Object);

            CompanyDto dto = new CompanyDto()
            {
                FullName = fullName,
                ShortName = "Cny4"
            };

            Assert.Throws<ArgumentException>(() => service.SaveCompany(dto));
            mockRepository.Verify(x => x.Insert(It.IsAny<Company>()), Times.Never);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void AddingWithoutShortNameThrowsException(string shortName)
        {
            var mockRepository = new Mock<ICompaniesRepository>();
            CompanyService service = new CompanyService(mockRepository.Object);

            CompanyDto dto = new CompanyDto()
            {
                FullName = "Company 4",
                ShortName = shortName
            };

            Assert.Throws<ArgumentException>(() => service.SaveCompany(dto));
            mockRepository.Verify(x => x.Insert(It.IsAny<Company>()), Times.Never);
        }

        [Fact]
        public void UpdatesCompany()
        {
            var mockRepository = new Mock<ICompaniesRepository>();
            mockRepository.Setup(x => x.Update(It.IsAny<Company>()))
                .Returns((Company c) => c);
            CompanyService service = new CompanyService(mockRepository.Object);

            CompanyDto dto = new CompanyDto()
            {
                Id = 2,
                FullName = "Company 2 new name",
                ShortName = "Cny2 new"
            };
            var result = service.SaveCompany(dto);

            mockRepository.Verify(x => x.Update(It.IsAny<Company>()), Times.Once);
            mockRepository.Verify(x => x.Insert(It.IsAny<Company>()), Times.Never);
            Assert.IsType<CompanyDto>(result);
            Assert.Equal(dto.FullName, result.FullName);
            Assert.Equal(dto.ShortName, result.ShortName);
            Assert.Equal(dto.Id, result.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void UpdatingWithoutFullNameThrowsException(string fullName)
        {
            var mockRepository = new Mock<ICompaniesRepository>();
            CompanyService service = new CompanyService(mockRepository.Object);

            CompanyDto dto = new CompanyDto()
            {
                Id = 2,
                FullName = fullName,
                ShortName = "Cny2"
            };

            Assert.Throws<ArgumentException>(() => service.SaveCompany(dto));
            mockRepository.Verify(x => x.Insert(It.IsAny<Company>()), Times.Never);
            mockRepository.Verify(x => x.Update(It.IsAny<Company>()), Times.Never);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void UpdatingWithoutShortNameThrowsException(string shortName)
        {
            var mockRepository = new Mock<ICompaniesRepository>();
            CompanyService service = new CompanyService(mockRepository.Object);

            CompanyDto dto = new CompanyDto()
            {
                FullName = "Company 4",
                ShortName = shortName
            };

            Assert.Throws<ArgumentException>(() => service.SaveCompany(dto));
            mockRepository.Verify(x => x.Update(It.IsAny<Company>()), Times.Never);
            mockRepository.Verify(x => x.Insert(It.IsAny<Company>()), Times.Never);
        }

        [Fact]
        public void UpdatingNonexistingCompanyReturnsNull()
        {
            var mockRepository = new Mock<ICompaniesRepository>();
            mockRepository.Setup(x => x.Update(It.IsAny<Company>())).Returns((Company)null);
            CompanyService service = new CompanyService(mockRepository.Object);
            CompanyDto dto = new CompanyDto()
            {
                Id = 4,
                FullName = "Company 4",
                ShortName = "Cny4"
            };

            var result = service.SaveCompany(dto);

            mockRepository.Verify(x => x.Update(It.IsAny<Company>()), Times.Once);
            Assert.Null(result);
        }

        [Fact]
        public void DeletesCompany()
        {
            var mockRepository = new Mock<ICompaniesRepository>();
            mockRepository.Setup(x => x.GetById(2)).Returns(companies[1]);
            mockRepository.Setup(x => x.Remove(2)).Returns(companies[1]);
            CompanyService service = new CompanyService(mockRepository.Object);

            var result = service.RemoveCompany(2);

            mockRepository.Verify(x => x.Remove(2), Times.Once);
            Assert.IsType<CompanyDto>(result);
            Assert.Equal(companies[1].FullName, result.FullName);
            Assert.Equal(companies[1].ShortName, result.ShortName);
            Assert.Equal(companies[1].ID, result.Id);
        }

        [Fact]
        public void ReturnsNullWhenDeletingNonexistingCompany()
        {
            var mockRepository = new Mock<ICompaniesRepository>();
            mockRepository.Setup(x => x.GetById(4)).Returns<Company>(null);
            mockRepository.Setup(x => x.Remove(4)).Returns<Company>(null);
            CompanyService service = new CompanyService(mockRepository.Object);

            var result = service.RemoveCompany(2);

            mockRepository.Verify(x => x.Remove(2), Times.Never);
            Assert.Null(result);
        }
    }
}
