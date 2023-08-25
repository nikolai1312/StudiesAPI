using AutoMapper;
using StudiesAPI.Logic.MapperProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studiesAPI.Tests.Automapper
{
    public static class AutomapperTests
    {
        public static IMapper GenerateMapper()
        {
            var mapperConfigurationExpression = new MapperConfigurationExpression();
            mapperConfigurationExpression.AddProfile(new DefaultMapper());
            var mapperConfiguration = new MapperConfiguration(mapperConfigurationExpression);

            return new Mapper(mapperConfiguration);
        }
    }
}
