using AutoMapper;
using System;
using Lesson_58_HT.Models;

namespace Lesson_58_HT.Services
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Product, Product>();
        }
    }
}
