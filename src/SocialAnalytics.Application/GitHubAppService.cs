using System.Collections.Generic;
using SocialAnalytics.Application.Interfaces;
using SocialAnalytics.Application.ViewModels;
using SocialAnalytics.Infra.ServiceAgents.GitHubApi;

namespace SocialAnalytics.Application
{
    public class GitHubAppService : IGitHubAppService
    {
        #region Stargazers

        public IEnumerable<GitHubCountResult> GetStargazersCount(ICollection<GitHubRequest> requests)
        {
            var stargazersCounts = new List<GitHubCountResult>();

            foreach (var request in requests)
            {
                var countResult = new GitHubCountResult();
                var email = request.Email + "";
                if (email.Equals("")) continue;

                var login = GetLoginByEmail(email);

                if (login.Equals("")) continue;

                countResult.Email = email;
                countResult.Count = GetCountStargazers(login);

                stargazersCounts.Add(countResult);
            }

            return stargazersCounts;
        }

        private int GetCountStargazers(string login)
        {
            var gitHubClient = new GitHubClient();

            return gitHubClient.GetCountStargazers(login);
        }

        #endregion

        #region Repositories

        public IEnumerable<GitHubCountResult> GetRepositoriesCount(ICollection<GitHubRequest> requests)
        {
            var stargazersCounts = new List<GitHubCountResult>();

            foreach (var request in requests)
            {
                var countResult = new GitHubCountResult();
                var email = request.Email + "";
                if (email.Equals("")) continue;

                var login = GetLoginByEmail(email);

                if (login.Equals("")) continue;

                countResult.Email = email;
                countResult.Count = GetCountRepositories(login);

                stargazersCounts.Add(countResult);
            }

            return stargazersCounts;
        }

        private int GetCountRepositories(string login)
        {
            var gitHubClient = new GitHubClient();

            return gitHubClient.GetCountRepositories(login);
        }

        #endregion

        #region Followers

        public IEnumerable<GitHubCountResult> GetFollowersCount(ICollection<GitHubRequest> requests)
        {
            var stargazersCounts = new List<GitHubCountResult>();

            foreach (var request in requests)
            {
                var countResult = new GitHubCountResult();
                var email = request.Email + "";
                if (email.Equals("")) continue;

                var login = GetLoginByEmail(email);

                if (login.Equals("")) continue;

                countResult.Email = email;
                countResult.Count = GetCountFollowers(login);

                stargazersCounts.Add(countResult);
            }

            return stargazersCounts;
        }

        private int GetCountFollowers(string login)
        {
            var gitHubClient = new GitHubClient();

            return gitHubClient.GetCountFollowers(login);
        }

        #endregion

        #region Following

        public IEnumerable<GitHubCountResult> GetFollowingCount(ICollection<GitHubRequest> requests)
        {
            var stargazersCounts = new List<GitHubCountResult>();

            foreach (var request in requests)
            {
                var countResult = new GitHubCountResult();
                var email = request.Email + "";
                if (email.Equals("")) continue;

                var login = GetLoginByEmail(email);

                if (login.Equals("")) continue;

                countResult.Email = email;
                countResult.Count = GetCountFollowing(login);

                stargazersCounts.Add(countResult);
            }

            return stargazersCounts;
        }

        private int GetCountFollowing(string login)
        {
            var gitHubClient = new GitHubClient();

            return gitHubClient.GetCountFollowing(login);
        }

        #endregion

        #region Code Shared

        private string GetLoginByEmail(string email)
        {
            var gitHubClient = new GitHubClient();

            return gitHubClient.GetLoginByEmail(email);
        }

        #endregion
    }
}