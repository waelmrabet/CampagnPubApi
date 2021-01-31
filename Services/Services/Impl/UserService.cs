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
        private readonly IUserRepository _userRepo;        
        public UserService(IUserRepository userRepo) : base(userRepo) {
            _userRepo = userRepo;
        }

    }
}
