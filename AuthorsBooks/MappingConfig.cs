using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using DAL.Entity;

namespace AuthorsBooks
{
    public static class MappingConfig
    {
        public static void InitializeAutoMapper()
        {
            //Mapper.Initialize(cfg => { });
            AutoMapper.Mapper.Initialize(cfg =>
            {
              
                cfg.CreateMap<AuthorModel, Author>();
                cfg.CreateMap<Author, AuthorModel>();
                //cfg.CreateMap<IEnumerable<Author>, IEnumerable<AuthorModel>>();

                cfg.CreateMap<BookModel, Book>();
                cfg.CreateMap<Book, BookModel>();

                //Common.BookModel
                cfg.CreateMap<IEnumerable<Book>, IEnumerable<BookModel>>();
                cfg.CreateMap<IEnumerable<BookModel>, IEnumerable<Book>>();

                //Common.BookModel
                //cfg.CreateMap<IEnumerable<Book>, IEnumerable<BookModel>>();
                //cfg.CreateMap<IEnumerable<BookModel>, IEnumerable<Book>>();

                //cfg.CreateMap<IEnumerable<Common.BookModel>, DAL.Entity.Book>();
                //cfg.CreateMap<DAL.Entity.Book, IEnumerable<Common.BookModel>>();

                //cfg.CreateMap<IEnumerable<BookModel>, IEnumerable<Book>>();


                //cfg.CreateMap<AuthorsBooksModel, DAL.Entity.AuthorsBooks>();
                //cfg.CreateMap<DAL.Entity.AuthorsBooks, AuthorsBooksModel>();

                //cfg.CreateMap<AuthorsBooksModel, DAL.Entity.AuthorsBooks>();

            });
        }
    }
}
