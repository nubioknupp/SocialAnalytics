
using System;
using System.Collections.Generic;

namespace SocialAnalytics.Domain.Entities
{
    public class User
    {
        public User()
        {
            UserId = Guid.NewGuid();
            Stargazers = new List<Stargazers>();
        }

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Stargazers> Stargazers { get; set; }
    }
}
