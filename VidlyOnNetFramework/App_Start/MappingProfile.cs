using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyOnNetFramework.Dtos;
using VidlyOnNetFramework.Models;

namespace VidlyOnNetFramework.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapper.Map<Customer, CustomerDto>(Customer, CustomerDto);
        }
    }
}