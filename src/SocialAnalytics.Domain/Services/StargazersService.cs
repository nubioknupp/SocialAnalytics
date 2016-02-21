using System;
using System.Collections.Generic;
using SocialAnalytics.Domain.Entities;
using SocialAnalytics.Domain.Interfaces.Services;

namespace SocialAnalytics.Domain.Services
{
    public class StargazersService : IStargazersService
    {
        private readonly IStargazersService _stargazersService;

        public StargazersService(IStargazersService stargazersService)
        {
            _stargazersService = stargazersService;
        }

        public Stargazers Add(Stargazers stargazers)
        {
            return _stargazersService.Add(stargazers);
        }

        public Stargazers FindById(Guid id)
        {
            return _stargazersService.FindById(id);
        }

        public IEnumerable<Stargazers> FindAll()
        {
            return _stargazersService.FindAll();
        }

        public Stargazers Update(Stargazers stargazers)
        {
            return _stargazersService.Update(stargazers);
        }

        public void Remove(Guid id)
        {
            _stargazersService.Remove(id);
        }

        public void Dispose()
        {
            _stargazersService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}