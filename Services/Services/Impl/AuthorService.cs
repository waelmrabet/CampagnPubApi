using BL.ServicePattern;
using Core.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Impl
{    
    public class AuthorService :  ServicePattern<Author>, IAuthorService
    {
        public AuthorService(IRepository<Author> authorRepo) : base(authorRepo) { }       

        public void Fawzi()
        {
            
        }

    }
}
