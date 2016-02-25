using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SocialAnalytics.Domain.Entities;

namespace SocialAnalytics.Infra.ServiceAgents.GitHubApi
{
    public class GitHubClient
    {
        private const string GitHubToken = "";
        private const string UrlApiGitHub = "https://api.github.com";
        private const string UserAgent = "SocialAnalytics";

        public IEnumerable<string> GetRepositories(string userLogin)
        {
            var url = $"{UrlApiGitHub}/users/{userLogin}/repos?access_token={GitHubToken}";
            var request = WebRequest.Create(url) as HttpWebRequest;
            IEnumerable<string> repositories;

            request.UserAgent = UserAgent;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                var reader = new StreamReader(response.GetResponseStream());
                var content = reader.ReadToEnd();
                var json = JArray.Parse(content);

                repositories = json.Select(item => item.Value<string>("full_name")).ToList();
            }

            return repositories;
        }

        public User FindByEmail(string email)
        {
            var login = GetLoginByEmail(email);

            return GetUserByLogin(login);
        }


        public User GetUserByLogin(string login)
        {
            var url = $"{UrlApiGitHub}/users/{login}?access_token={GitHubToken}";
            var request = WebRequest.Create(url) as HttpWebRequest;
            var user = new User();

            request.UserAgent = UserAgent;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                var reader = new StreamReader(response.GetResponseStream());
                var content = reader.ReadToEnd();
                var result = JsonConvert.DeserializeObject<dynamic>(content);

                user.Email = result.email.ToString();
                user.Login = result.login.ToString();
                user.Name = result.name.ToString();
            }

            return user;
        }

        public string GetLoginByEmail(string email)
        {
            var login = "";

            var url = $"{UrlApiGitHub}/search/users?q={email}&access_token={GitHubToken}";
            var request = WebRequest.Create(url) as HttpWebRequest;

            request.UserAgent = UserAgent;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                var reader = new StreamReader(response.GetResponseStream());
                var content = reader.ReadToEnd();
                var result = JsonConvert.DeserializeObject<dynamic>(content);
                var str = result.ToString();

                if (str.IndexOf("login") >= 0) login = result.items[0].login.ToString();
            }

            return login;
        }

        public int GetCountStargazers(string login)
        {
            var count = 0;
            var repositories = GetRepositories(login);

            foreach (var repository in repositories)
            {
                var url = $"{UrlApiGitHub}/repos/{repository}/stargazers?access_token={GitHubToken}";
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.UserAgent = UserAgent;
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    var reader = new StreamReader(response.GetResponseStream());
                    var content = reader.ReadToEnd();

                    count = count + AnalyticsCountStargazers(content, login);
                }
            }

            return count;
        }

        private int AnalyticsCountStargazers(string content, string loginRepository)
        {
            var results = JsonConvert.DeserializeObject<dynamic>(content);
            var count = 0;

            foreach (var result in results)
            {
                var login = result.login.ToString();

                if (!login.Equals(loginRepository)) count = count + 1;
            }

            return count;
        }

        public int GetCountRepositories(string login)
        {
            return GetRepositories(login).Count();
        }

        public int GetCountFollowers(string login)
        {
            var count = 0;
            var url = $"{UrlApiGitHub}/users/{login}/followers?access_token={GitHubToken}";
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.UserAgent = UserAgent;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                var reader = new StreamReader(response.GetResponseStream());
                var content = reader.ReadToEnd();

                count = JArray.Parse(content).Count;
            }

            return count;
        }

        public int GetCountFollowing(string login)
        {
            var count = 0;
            var url = $"{UrlApiGitHub}/users/{login}/following?access_token={GitHubToken}";
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.UserAgent = UserAgent;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                var reader = new StreamReader(response.GetResponseStream());
                var content = reader.ReadToEnd();

                count = JArray.Parse(content).Count;
            }

            return count;
        }

        public int GetCountCommits(string login)
        {
            var count = 0;
            var repositories = GetRepositories(login);

            foreach (var repository in repositories)
            {
                var url = $"{UrlApiGitHub}/repos/{repository}/commits?access_token={GitHubToken}";
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.UserAgent = UserAgent;
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    var reader = new StreamReader(response.GetResponseStream());
                    var content = reader.ReadToEnd();

                    count = count + JArray.Parse(content).Count;
                }
            }

            return count;
        }
    }
}