## C# Studies API

### :bulb: Intention :bulb:

This API was meant to be a POC for some libs that are used in C# API development, i've studied some of those libraries and applied them in here. Here's the list of the libs that i've used in this project:

- [Automapper](https://docs.automapper.org/en/stable/) \
- [Dapper](https://github.com/DapperLib/Dapper) \
- [XUnit](https://xunit.net/#documentation) \
- [Moq](https://github.com/moq/moq)

I'm algo using a clean architectural pattern, despite not using a ```.csproj``` for every layer of the API, the folder structure and the relationship between classes matches the concept. 

The currently folder structure is: 
```
./API
├── Controllers
│   
├── Data
│   ├── Interfaces
│   └── Repositories
├── Domain
│   └── Entities
├── Filters
├── Logic
│   ├── DTOs
│   │   ├── BandDtos
│   │   ├── ConcertDto
│   ├── Interfaces
│   ├── MapperProfiles
│   └── Services
```

### :heavy_exclamation_mark: Status  :heavy_exclamation_mark:

Although the project is not yet finished, i'm keeping my hands out of this code for awhile because it's time to focus on some other things like middlewares, pagination, sorting and making a deploy for this API, or even make a nice UI for this project. 

Anyway, i'm going to add a dockerfile and a docker compose for this poject because there's where i'm at right now. 

Feel free to contribute to this project or put some toughts about this code. 