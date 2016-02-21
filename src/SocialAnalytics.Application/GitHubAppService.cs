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
            foreach (var gitHub in gitHubs)
            {
                var email = gitHub.Email + "";
                if (email.Equals("")) continue;

                var isAdd = false;
                var user = _userService.FindByEmail(email);

                if (NullOrEmpty.IsAnyNullOrEmptyObject(user))
                {
                    isAdd = true;
                    user = FindGitByEmail(email);
                }
                    
                if (NullOrEmpty.IsAnyNullOrEmptyObject(user)) continue;

                var stargazers = GetStargazers(user.Login);
                user.Stargazers.Add(stargazers);

                if (isAdd)
                {
                    _userService.Add(user);
                    continue;
                }

               _userService.Update(user);
            }

           return GetStargazersCounts();
        }

        private User FindGitByEmail(string email)
        {
            var gitHubClient = new GitHubClient();
            var user = gitHubClient.FindByEmail(email);
            return user;
        }

        //private bool IsAnyNullOrEmpty(object myObject)
        //{
        //    if (myObject == null) return true;
        //    foreach (var pi in myObject.GetType().GetProperties())
        //    {
        //        if (pi.PropertyType == typeof(string))
        //        {
        //            var value = (string)pi.GetValue(myObject);
        //            if (string.IsNullOrEmpty(value))
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        private Stargazers GetStargazers(string login)
        {
            var stargazers = new Stargazers();
            var gitHubClient = new GitHubClient();
 
            stargazers.Count = gitHubClient.GetCountStargazers(login);
            stargazers.DateImport = _dateImport;

            return stargazers;
        }

        private IEnumerable<StargazersCount> GetStargazersCounts()
        {
            var users = _userService.FindLastRecord();
            var stargazersCounts = new List<StargazersCount>();

            foreach (var user in users)
            {
                var stargazersCount = new StargazersCount();

                stargazersCount.Email = user.Email;

                foreach (var stargazers in user.Stargazers)
                {
                    stargazersCount.Count = stargazers.Count;
                }

                stargazersCounts.Add(stargazersCount);
            }

            return stargazersCounts;
        }



    }
}