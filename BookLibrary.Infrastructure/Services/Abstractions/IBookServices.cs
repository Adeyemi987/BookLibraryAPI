﻿using BookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure.Services.Abstractions
{
    public interface IBookServices
    {
        List<Book> GetBooks();
    }
}
