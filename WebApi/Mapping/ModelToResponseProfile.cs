using AutoMapper;
using WebApi.DTOs.Responses;
using WebApi.Models;

namespace WebApi.Mapping
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<Products[], ProductsDTO>(); 
            CreateMap<Products, ProductsDTO>();
            CreateMap<Movements, MovementsDTO>();
        }
    }
}
