using AutoMapper;
using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Models.DTO.BookDTOs;
using BookLibrary.Domain.Models.DTO.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure.Helpers
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            //Book
            CreateMap<Book, BookRequestDTO>().ReverseMap();
            CreateMap<Book, BookResponseDTO>().ReverseMap();

            //Category
            CreateMap<Book, CategoryRequestDTO>().ReverseMap();
            CreateMap<Book, CategoryResponseDTO>().ReverseMap();
        }
       
    }
}
