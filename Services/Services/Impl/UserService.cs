using BL.ServicePattern;
using Core.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Impl
{
    public class UserService : ServicePattern<User>, IUserService
    {
        public UserService(IRepository<User> userRepo) : base(userRepo) { }
    
    }
}
