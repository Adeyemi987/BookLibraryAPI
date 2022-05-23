using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Extensions
{
    public static class SwaggerExtensions
    {

        public static void AddSwagger(this IServiceCollection services)
        {
            // This method gets called by the runtime from the startup "ConfigureServices()" to add swagger.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Phonebook API",
                    Version = "v1",
                    Description = @"API service for creating, deleting, and updating books and categories entries in a library",
                    Contact = new OpenApiContact
                    {
                        Name = "Adeyemi Tubosun",
                        Email = "cadeyemi50@gmail.com"
                    }
                });
            });
        }
    }
}
