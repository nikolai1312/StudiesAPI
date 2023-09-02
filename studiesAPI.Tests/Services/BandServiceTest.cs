using Moq;
using studiesAPI.Tests.Automapper;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Domain.Entities;
using StudiesAPI.Logic.DTOs.BandDtos;
using StudiesAPI.Logic.Services;

namespace StudiesAPI.Tests.Services
{
    public class BandServiceTest
    {
        [Fact(DisplayName = "Should create a band with name and genre")]
        public void ShouldCreateABandWithNameAndGenre()
        {
            var _repository = new Mock<IBandRepository>();
            var _mapper = AutomapperTests.GenerateMapper();
            var _service = new BandService(_repository.Object, _mapper);
            
            var _bandToBeCreated = new BandRequestDto { Name = "Metallica", Genre = "Metal" };
            var _responseService = new BandResponseDto { HasError = false };

            var _testResult = _service.CreateBandAsync(_bandToBeCreated);

            _repository.Verify(x => x.CreateAsync(It.IsAny<Band>()), times: Times.Once());
            Assert.Equal(_responseService.HasError, _testResult.Result.HasError);
        }

        [Fact(DisplayName = "Should return a band")]
        public void ShouldReturnABand()
        {
            var _repository = new Mock<IBandRepository>();
            var _mapper = AutomapperTests.GenerateMapper();
            var _service = new BandService(_repository.Object, _mapper);

            int _bandId = 1;
            var _expectedResponse = new BandResponseDto { HasError = false, Data = new BandDto{ Id = 2, Name = "Slayer", Genre = "Metal" } };

            _repository.Setup(x => x.GetAsync(It.IsAny<int>()).Result)
                       .Returns(new Band { Id = 2, Name = "Slayer", Genre = "Metal" });

            var _serviceResult = _service.GetBandAsync(_bandId).Result;

            BandResponseDto _testResult = new() { HasError = false, Data = _serviceResult.Data };
            
            Assert.Equivalent(_expectedResponse.Data, _testResult.Data);
        }

        [Fact(DisplayName = "Should return a list of bands")]
        public void ShouldReturnAListOfBands()
        {
            var _repository = new Mock<IBandRepository>();
            var _mapper = AutomapperTests.GenerateMapper();
            var _service = new BandService(_repository.Object, _mapper);

            var _responseService = new BandResponseDto { HasError = false };


            List<Band> _bandList = new() 
            { 
                new Band 
                { 
                    Id = 1, 
                    Genre = "Metal",
                    Name = "Ozzy osbourne"
                },
                new Band
                {
                    Id = 2,
                    Genre = "Metal",
                    Name = "Exumer"
                },
                new Band
                {
                    Id = 3,
                    Genre = "Metal",
                    Name = "Venom"
                },
                new Band
                {
                    Id = 4,
                    Genre = "K-Pop",
                    Name = "Twice"
                }
            };

            _repository.Setup(x => x.GetAllAsync().Result)
                       .Returns(_bandList);

            var _serviceResult = _service.GetAllBandsAsync().Result;

            BandResponseDto _testResult = new() { HasError = false, DataList = _serviceResult.DataList };

            _repository.Verify(x => x.GetAllAsync(), Times.Once());

            Assert.Equal(_bandList.Count, _testResult.DataList.Count);
            Assert.Equivalent(_bandList, _testResult.DataList);
        }
    }
}