using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SocialAnalytics.Application;
using SocialAnalytics.Application.ViewModels;

namespace SocialAnalytics.Services.REST.SocialAPI.Controllers
{
    [EnableCors("http://localhost:5740, http://socialanalyticsdev.azurewebsites.net", "*", "*")]
    [RoutePrefix("api/v1/github")]
    public class GitHubController : ApiController
    {
        private readonly GitHubAppService _gitHubAppService  = new GitHubAppService();

        [HttpPost]
        [Route("stargazers")]

        public HttpResponseMessage PostStargazers(ICollection<GitHub> gitHubs)
        {
            if (gitHubs == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            var stargazerses = _gitHubAppService.ProcessStargazerses(gitHubs);

            return Request.CreateResponse(HttpStatusCode.OK, stargazerses);
        }

    }
}
