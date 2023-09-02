using Moq;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Logic.Services;
using studiesAPI.Tests.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudiesAPI.Logic.DTOs.ConcertDto;
using StudiesAPI.Domain.Entities;

namespace studiesAPI.Tests.Services
{
    public class ConcertServiceTest
    {
        [Fact(DisplayName = "Should create a concert with name, year and country")]
        public void ShouldCreateAConcertWithNameYearAndCountry()
        {
            var _repository = new Mock<IConcertRepository>();
            var _mapper = AutomapperTests.GenerateMapper();
            var _service = new ConcertService(_repository.Object, _mapper);

            var _concertToBeCreated = new ConcertRequestDto { Name = "Kool Metal", Year = new DateTime().Year, Country = "England" };
            var _serviceResponse = new ConcertResponseDto { HasError = false };

            var _testResult = _service.CreateConcertAsync(_concertToBeCreated).Result;

            _repository.Verify(x => x.CreateAsync(It.IsAny<Concert>()), times: Times.Once);
            Assert.Equal(_serviceResponse.HasError, _testResult.HasError);
        }

        [Fact(DisplayName = "Should return a concert by id")]
        public void ShouldReturnAConcertById()
        {
            var _repository = new Mock<IConcertRepository>();
            var _mapper = AutomapperTests.GenerateMapper();
            var _service = new ConcertService(_repository.Object, _mapper);

            var _concertToBeReturned = new ConcertResponseDto { HasError = false, Data = new ConcertDto { Name = "Kool Metal", Year = new DateTime().Year, Country = "England" } };
            int _concertIdToBeSearched = 1;

            _repository.Setup(x => x.GetAsync(It.IsAny<int>()).Result)
                       .Returns(new Concert { Name = "Kool Metal", Year = new DateTime().Year, Country = "England" });

            var _testResult = _service.GetConcertAsync(_concertIdToBeSearched).Result;

            ConcertResponseDto _expectedResponse = new() { HasError = false, Data = _testResult.Data };

            _repository.Verify(x => x.GetAsync(It.IsAny<int>()), times: Times.Once());
            Assert.Equivalent(_concertToBeReturned.Data, _expectedResponse.Data);
        }

        [Fact(DisplayName = "Should return a list of concerts")]
        public void ShouldReturnAListOfConcerts()
        {
            var _repository = new Mock<IConcertRepository>();
            var _mapper = AutomapperTests.GenerateMapper();
            var _service = new ConcertService(_repository.Object, _mapper);

            var _bandsList = new List<Concert>
            {
                new Concert
                {
                    Id = 1,
                    Year = 1970,
                    Name = "CAN",
                    Country = "Germany"
                },
                new Concert
                {
                    Id = 2,
                    Year = 1969,
                    Name = "Woodstock",
                    Country = "USA"
                },
                new Concert
                {
                    Id = 3,
                    Year = 2010,
                    Name = "Wacken",
                    Country = "Germany"
                },
                new Concert
                {
                    Id = 4,
                    Year = 2023,
                    Name = "Kool Metal",
                    Country = "Brazil"
                }
            };

            _repository.Setup(x => x.GetAllAsync().Result)
                       .Returns(_bandsList);

            var _testResult = _service.GetAllConcertsAsync().Result;

            ConcertResponseDto _expectedResult = new() { HasError = false, DataList = _testResult.DataList };

            _repository.Verify(x => x.GetAllAsync(), Times.Once());

            Assert.Equal(_expectedResult.DataList.Count, _bandsList.Count);
            Assert.Equivalent(_expectedResult.DataList, _bandsList);
    }
}
}

