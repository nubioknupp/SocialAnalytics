using System;

namespace SocialAnalytics.Domain.Entities
{
    public class Stargazers
    {
        public Stargazers()
        {
            StargazersId = new Guid();
        }

        public Guid StargazersId { get; set; }
        public int Count { get; set; }
        public DateTime DateImport { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
