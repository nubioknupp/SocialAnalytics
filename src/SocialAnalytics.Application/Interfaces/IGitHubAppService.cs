using System.Collections.Generic;
using SocialAnalytics.Application.ViewModels;

namespace SocialAnalytics.Application.Interfaces
{
    public interface IGitHubAppService
    {
        IEnumerable<GitHubCountResult> GetStargazersCount(ICollection<GitHubRequest> gitHubs);
    }
}