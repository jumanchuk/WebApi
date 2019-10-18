using AutoMapper;
using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;  
using System.Threading.Tasks;
using Banco.WebApi.DTOs.Requests;

namespace WebApi.Mapping
{
    public class RequestToModelProfile : Profile
    {
        public RequestToModelProfile()
        {
            CreateMap<ClienteAddDTO, Cliente>();
            CreateMap<ProductUpdateDTO, Products>();
        }
    }
}
