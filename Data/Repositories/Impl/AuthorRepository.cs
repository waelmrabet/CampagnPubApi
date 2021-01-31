using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Impl
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository, IRepository<Author>
    {
        public AuthorRepository(MyDataBaseContext context) : base(context) { }

        public Task<Author> GetByName(string name)
        {
            return context.Set<Author>().FirstOrDefaultAsync(author => author.Name == name);
        }
    }
}
