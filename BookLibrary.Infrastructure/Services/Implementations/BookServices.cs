using BookLibrary.Domain.Entities;
using BookLibrary.Infrastructure.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure.Services.Implementations
{
    public class BookServices : IBookServices
    {
        public List<Book> GetBooks()
        {
            return new List<Book> { };
        }
    }
}
