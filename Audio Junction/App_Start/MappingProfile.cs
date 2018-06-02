using Audio_Junction.Dtos;
using Audio_Junction.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audio_Junction.App_Start
{
    public class MappingProfile : Profile

    {
        public MappingProfile()
        {

            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            //CreateMap<Customer, CustomerDto>()
            //     .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<Movie, MoviesDto>();
            Mapper.CreateMap<MoviesDto, Movie>();

            //CreateMap<Movie, MoviesDto>()
            //   .ForMember(m => m.ID, opt => opt.Ignore());
        }
    }
}