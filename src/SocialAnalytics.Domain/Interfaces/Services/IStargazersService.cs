using System;
using System.Collections.Generic;
using SocialAnalytics.Domain.Entities;

namespace SocialAnalytics.Domain.Interfaces.Services
{
    public interface IStargazersService : IDisposable
    {
        Stargazers Add(Stargazers stargazers);
        Stargazers FindById(Guid id);
        IEnumerable<Stargazers> FindAll();
        Stargazers Update(Stargazers obj);
        void Remove(Guid id);
    }
}