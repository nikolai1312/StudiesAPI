using Moq;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Logic.Services;
using studiesAPI.Tests.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        }
    }
}
