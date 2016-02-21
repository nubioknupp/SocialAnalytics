using System.Collections.Generic;
using SocialAnalytics.Application.ViewModels;

namespace SocialAnalytics.Application.Interfaces
{
    public interface IGitHubAppService
    {
        IEnumerable<StargazersCount> ProcessStargazerses(ICollection<GitHub> gitHubs);
    }
}