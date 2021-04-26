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
        private readonly IRepository<User> _userRepo;

        public UserService(IRepository<User> userRepo) : base(userRepo)
        {
            _userRepo = userRepo;
        }

        public void DesactivateUser(int userId, bool activate)
        {
            var user = GetById(userId);
            user.Activated = activate;
            Commit();
        }
    }
}
