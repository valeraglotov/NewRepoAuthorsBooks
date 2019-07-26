using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL.Entity;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AuthorsBooks.Classes
{
    public static class DependencyInjectionForEntities
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorsBooksService, AuthorsBooksService>();
            //services.AddScoped<IAuthorService, PaginationModel>();

            services.AddScoped<IRepository<Author>, AuthorRepository>();
            services.AddScoped<IRepository<Book>, BookRepository>();
            services.AddScoped<IRepository<DAL.Entity.AuthorsBooks>, AuthorsBooksRepository>();
            return services; 
        }
    }
}
