using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Services.InfrastructureServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure.Services.Abstractions
{
    public interface IBookServices : IBookLibraryGenericQuery<Book>
    {
      
    }
}
