using BookLibrary.Domain.Entities;
using BookLibrary.Infrastructure.Data.DatabaseContexts;
using BookLibrary.Infrastructure.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure.Services.Implementations
{
    public class CategoryServices : BookLibraryGenericQuery<Category>, ICategoryServices
    {
        public CategoryServices(BookLibraryDbContext context) : base(context) { }
    }
}
