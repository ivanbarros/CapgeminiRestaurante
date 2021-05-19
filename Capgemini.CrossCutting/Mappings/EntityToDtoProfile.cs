using AutoMapper;
using Capgemini.Domain.DTOs;
using Capgemini.Domain.Entities;

namespace Capgemini.CrossCutting.Mappings
{
    public class EntityToDtoProfile: Profile
    {
        public EntityToDtoProfile()
        {

            CreateMap<FoodDTO, FoodEntity>().ReverseMap();
        }
    }
}
