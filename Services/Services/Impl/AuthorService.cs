using BL.ServicePattern;
using Core.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Impl
{
    public class AuthorService : ServicePattern<Author>, IAuthorService
    {
        private readonly IAuthorRepository _authorRepo;
        public AuthorService(IAuthorRepository authorRepo) : base(authorRepo)
        {
            _authorRepo = authorRepo;
        }
    }
}
