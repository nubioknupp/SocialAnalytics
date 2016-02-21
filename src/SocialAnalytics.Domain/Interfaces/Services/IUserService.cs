using System;
using System.Collections.Generic;
using SocialAnalytics.Domain.Entities;

namespace SocialAnalytics.Domain.Interfaces.Services
{
    public interface IUserService : IDisposable
    {
        User Add(User user);
        User FindById(Guid id);
        IEnumerable<User> FindAll();
        User Update(User obj);
        void Remove(Guid id);
        User FindByEmail(string email);
        IEnumerable<User> FindLastRecord();
    }
}