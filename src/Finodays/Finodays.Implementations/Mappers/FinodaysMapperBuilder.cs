using AutoMapper;
using ClientBarometer.Common.Abstractions.Mappers;
using Models = Finodays.Domain.Models;
using Requests = Finodays.Contracts.Requests;
using Responses = Finodays.Contracts.Responses;

namespace Finodays.Implementations.Mappers
{
    public class FinodaysMapperBuilder : IMapperDsl
    {
        public static MapperConfiguration MapperConfiguration => new MapperConfiguration(c =>
        {
            c.CreateMap<Requests.CreateUserRequest, Models.User>();
            c.CreateMap<Models.User, Responses.User>();
            c.CreateMap<Models.Transaction, Responses.Transaction>();
        });

        public IMapper Please => MapperConfiguration.CreateMapper();
    }
}
