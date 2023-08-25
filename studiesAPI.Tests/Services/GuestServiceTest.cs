using Moq;
using studiesAPI.Tests.Automapper;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Domain.Entities;
using StudiesAPI.Logic.DTOs;
using StudiesAPI.Logic.Services;
using System.Xml.Linq;

namespace StudiesAPI.Tests.Services
{
    public class GuestServiceTest
    {
        [Fact(DisplayName = "Should create a guest with name and document ID")]
        public void ShouldCreateAGuestWithNameAndDocumentID()
        {
            var _repository = new Mock<IGuestRepository>();
            var _mapper = AutomapperTests.GenerateMapper();
            var _service = new GuestService(_repository.Object, _mapper);
            
            var _guestToBeCreated = new GuestRequestDto { Name = "Chico Anysio", CPF = "11123498012" };
            var _responseService = new GuestResponseDto { HasError = false };

            var _testResult = _service.CreateGuestAsync(_guestToBeCreated);

            _repository.Verify(x => x.CreateAsync(It.IsAny<Guest>()), times: Times.Once());
            Assert.Equal(_responseService.HasError, _testResult.Result.HasError);
        }

        [Fact(DisplayName = "Should return a guest")]
        public void ShouldReturnAGuest()
        {
            var _repository = new Mock<IGuestRepository>();
            var _mapper = AutomapperTests.GenerateMapper();
            var _service = new GuestService(_repository.Object, _mapper);

            int _guestId = 1;
            var _responseService = new GuestResponseDto { HasError = false, Data = new GuestDto{ Id = 2, Name = "Chico Anysio", CPF = "11122233390" } };

            _repository.Setup(x => x.GetAsync(It.IsAny<int>()).Result)
                       .Returns(new Guest { Id = 2, Name = "Chico Anysio", CPF = "11122233390"});

            var _serviceResult = _service.GetGuestAsync(_guestId).Result;

            GuestResponseDto _testResult = new() { HasError = false, Data = _serviceResult.Data };
            
            Assert.Equivalent(_responseService.Data, _testResult.Data);
        }

        [Fact(DisplayName = "Should return guests list")]
        public void ShouldReturnGuestsList()
        {
            var _repository = new Mock<IGuestRepository>();
            var _mapper = AutomapperTests.GenerateMapper();
            var _service = new GuestService(_repository.Object, _mapper);

            var _responseService = new GuestResponseDto { HasError = false };


            List<Guest> _guestList = new() 
            { 
                new Guest 
                { 
                    Id = 1, 
                    CPF = "11122233390",
                    Name = "Charles du bronx"
                },
                new Guest
                {
                    Id = 2,
                    CPF = "11122233390",
                    Name = "Charles du bronx"
                },
                new Guest
                {
                    Id = 3,
                    CPF = "11122233390",
                    Name = "Charles du bronx"
                },
                new Guest
                {
                    Id = 4,
                    CPF = "11122233390",
                    Name = "Charles du bronxw"
                }
            };

            _repository.Setup(x => x.GetAllAsync().Result)
                       .Returns(_guestList);

            var _serviceResult = _service.GetAllGuestsAsync().Result;

            GuestResponseDto _testResult = new() { HasError = false, DataList = _serviceResult.DataList };

            _repository.Verify(x => x.GetAllAsync(), Times.Once());

            Assert.Equal(_guestList.Count, _testResult.DataList.Count);
            Assert.Equivalent(_guestList, _testResult.DataList);
        }
    }
}