using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SocialAnalytics.Application;
using SocialAnalytics.Application.ViewModels;
using SocialAnalytics.Infra.CrossCutting.Universal;

namespace SocialAnalytics.Services.REST.SocialAPI.Controllers
{
    [EnableCors("http://localhost:5740, http://socialanalyticsdev.azurewebsites.net", "*", "*")]
    [RoutePrefix("api/v1/github")]
    public class GitHubController : ApiController
    {
        private readonly GitHubAppService _gitHubAppService = new GitHubAppService();

        private const string MessageErro = "Falha ao realizar requisição: Nenhum valor foi fornecido " +
                                           "para um ou mais parâmetros necessários.";

        [HttpPost]
        [Route("stargazers/count")]
        public HttpResponseMessage PostStargazersCountCount(ICollection<GitHubRequest> requests)
        {
            if (NullOrEmpty.IsAnyNullOrEmptyList(requests))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageErro);
            }

            var results = _gitHubAppService.GetStargazersCount(requests);

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [HttpPost]
        [Route("following/count")]
        public HttpResponseMessage PostFollowingCount(ICollection<GitHubRequest> requests)
        {
            if (NullOrEmpty.IsAnyNullOrEmptyList(requests))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageErro);
            }

            var results = _gitHubAppService.GetFollowingCount(requests);

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [HttpPost]
        [Route("followers/count")]
        public HttpResponseMessage PostFollowersCount(ICollection<GitHubRequest> requests)
        {
            if (NullOrEmpty.IsAnyNullOrEmptyList(requests))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageErro);
            }

            var results = _gitHubAppService.GetFollowersCount(requests);

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [HttpPost]
        [Route("repositories/count")]
        public HttpResponseMessage PostRepositoriesCount(ICollection<GitHubRequest> requests)
        {
            if (NullOrEmpty.IsAnyNullOrEmptyList(requests))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageErro);
            }

            var results = _gitHubAppService.GetRepositoriesCount(requests);

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [HttpPost]
        [Route("commits/count")]
        public HttpResponseMessage PostCommitsCount(ICollection<GitHubRequest> requests)
        {
            if (NullOrEmpty.IsAnyNullOrEmptyList(requests))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageErro);
            }

            var results = _gitHubAppService.GetCommitsCount(requests);

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }
    }
}
