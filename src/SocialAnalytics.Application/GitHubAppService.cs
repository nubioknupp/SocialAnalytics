using System;
using System.Collections.Generic;
using SocialAnalytics.Application.Interfaces;
using SocialAnalytics.Application.ViewModels;
using SocialAnalytics.Domain.Entities;
using SocialAnalytics.Infra.Data.Repository;
using SocialAnalytics.Infra.ServiceAgents.GitHubApi;
using SocialAnalytics.Infra.CrossCutting.Universal;

namespace SocialAnalytics.Application
{
    public class GitHubAppService : IGitHubAppService
    {
        private readonly UserRepository _userService = new UserRepository();
        private readonly DateTime _dateImport;

        public GitHubAppService()
        {
            _dateImport = DateTime.Now;
        }


        public IEnumerable<StargazersCount> ProcessStargazerses(ICollection<GitHub> gitHubs)
        {
            var stargazersCounts = new List<StargazersCount>();

            foreach (var gitHub in gitHubs)
            {
                var stargazersCount = new StargazersCount();
                var email = gitHub.Email + "";
                if (email.Equals("")) continue;

                var login = GetLoginByEmail(email);

                if (login.Equals("")) continue;

                stargazersCount.Email = email;
                stargazersCount.Count = GetCountStargazers(login);

                stargazersCounts.Add(stargazersCount);
            }

            return stargazersCounts;
        }

        private string GetLoginByEmail(string email)
        {
            var gitHubClient = new GitHubClient();

            return gitHubClient.GetLoginByEmail(email);
        }

        private int GetCountStargazers(string login)
        {
            var gitHubClient = new GitHubClient();

            return gitHubClient.GetCountStargazers(login);
        }
    }
}