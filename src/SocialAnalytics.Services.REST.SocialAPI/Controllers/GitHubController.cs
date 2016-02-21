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
        [Route("stargazers")]
        public HttpResponseMessage PostStargazers(ICollection<GitHub> gitHubs)
        {
            if (NullOrEmpty.IsAnyNullOrEmptyList(gitHubs))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageErro);
            }

            var stargazerses = _gitHubAppService.ProcessStargazerses(gitHubs);

            return Request.CreateResponse(HttpStatusCode.OK, stargazerses);
        }
    }
}
