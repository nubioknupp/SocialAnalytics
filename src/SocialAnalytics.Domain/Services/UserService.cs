using System;
using System.Collections.Generic;
using SocialAnalytics.Domain.Entities;
using SocialAnalytics.Domain.Interfaces.Services;

namespace SocialAnalytics.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserService _userService;

        public UserService(IUserService userService)
        {
            _userService = userService;
        }

        public User Add(User user)
        {
            return _userService.Add(user);
        }

        public User FindById(Guid id)
        {
            return _userService.FindById(id);
        }

        public IEnumerable<User> FindAll()
        {
            return _userService.FindAll();
        }

        public User Update(User user)
        {
            return _userService.Update(user);
        }

        public void Remove(Guid id)
        {
            _userService.Remove(id);
        }

        public User FindByEmail(string email)
        {
            return _userService.FindByEmail(email);
        }

        public IEnumerable<User> FindLastRecord()
        {
            return _userService.FindLastRecord();
        }

        public void Dispose()
        {
            _userService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}