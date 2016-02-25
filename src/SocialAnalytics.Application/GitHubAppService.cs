using System.Collections.Generic;
using SocialAnalytics.Application.Interfaces;
using SocialAnalytics.Application.ViewModels;
using SocialAnalytics.Infra.ServiceAgents.GitHubApi;

namespace SocialAnalytics.Application
{
    public class GitHubAppService : IGitHubAppService
    {
        public IEnumerable<GitHubCountResult> GetStargazersCount(ICollection<GitHubRequest> requests)
        {
            return GetGitHubCountResults(requests, "stargazers");
        }

        public IEnumerable<GitHubCountResult> GetRepositoriesCount(ICollection<GitHubRequest> requests)
        {
            return GetGitHubCountResults(requests, "repositories");
        }

        public IEnumerable<GitHubCountResult> GetFollowersCount(ICollection<GitHubRequest> requests)
        {
            return GetGitHubCountResults(requests, "followers");
        }

        public IEnumerable<GitHubCountResult> GetFollowingCount(ICollection<GitHubRequest> requests)
        {
            return GetGitHubCountResults(requests, "following");
        }

        public IEnumerable<GitHubCountResult> GetCommitsCount(ICollection<GitHubRequest> requests)
        {
            return GetGitHubCountResults(requests, "commits");
        }

        private string GetLoginByEmail(string email)
        {
            var gitHubClient = new GitHubClient();

            return gitHubClient.GetLoginByEmail(email);
        }

        private IEnumerable<GitHubCountResult> GetGitHubCountResults(ICollection<GitHubRequest> requests, string type)
        {
            var countResults = new List<GitHubCountResult>();

            foreach (var request in requests)
            {
                var countResult = new GitHubCountResult();
                var email = request.Email + "";
                if (email.Equals("")) continue;

                countResult.Email = email;
                countResult.Count = CountResult(GetLoginByEmail(email), type);

                countResults.Add(countResult);
            }

            return countResults;
        }

        private int CountResult(string login, string type)
        {
            if (login.Equals("")) return 0;

            var gitHubClient = new GitHubClient();
            switch (type)
            {
                case "commits":
                    return gitHubClient.GetCountCommits(login);
                case "followers":
                    return gitHubClient.GetCountFollowers(login);
                case "following":
                    return gitHubClient.GetCountFollowing(login);
                case "stargazers":
                    return gitHubClient.GetCountStargazers(login);
                case "repositories":
                    return gitHubClient.GetCountRepositories(login);
                default:
                    return 0;
            }
        }
    }
}