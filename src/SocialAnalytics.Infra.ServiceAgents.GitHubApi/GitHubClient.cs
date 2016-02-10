using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        public User GetUserByLogin(string login)
        {
            var url = $"{UrlApiGitHub}/users/{login}?access_token={GitHubToken}";
            var request = WebRequest.Create(url) as HttpWebRequest;
            var user = new User();

            request.UserAgent = UserAgent;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                var reader = new StreamReader(response.GetResponseStream());
                var json = reader.ReadToEnd();
                var result = JsonConvert.DeserializeObject<dynamic>(json);

                user.Email = result.email.ToString();
                user.Login = result.login.ToString();
                user.Name = result.name.ToString();
            }
            return user;
        }

        public string GetLoginByEmail(string email)
        {
            var url = $"{UrlApiGitHub}/search/users?q={email}&access_token={GitHubToken}";
            var request = WebRequest.Create(url) as HttpWebRequest;
            var login = "";

            request.UserAgent = UserAgent;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                var reader = new StreamReader(response.GetResponseStream());
                var json = reader.ReadToEnd();
                var result = JsonConvert.DeserializeObject<dynamic>(json);

                login = result.items[0].login.ToString();
            }
            return login;
        }

        public int GetCountStargazers(IEnumerable<string> repositories)
        {
            var count = 0;

            foreach (var repository in repositories)
            {
                var url = $"{UrlApiGitHub}/repos/{repository}/stargazers?access_token={GitHubToken}";
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.UserAgent = UserAgent;
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    var reader = new StreamReader(response.GetResponseStream());
                    var content = reader.ReadToEnd();
                    var json = JArray.Parse(content);

                    count = count + json.Count;
                }
            }
            return count;
        }
    }
}
