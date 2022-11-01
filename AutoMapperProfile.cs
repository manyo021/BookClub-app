using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookClub_app.DTOs.Book;

namespace BookClub_app
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Books, GetBookDto>();
            CreateMap<AddBookDto, Books>();

        }
    }
}