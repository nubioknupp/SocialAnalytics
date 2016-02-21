using System.Collections.Generic;
using SocialAnalytics.Domain.Entities;

namespace SocialAnalytics.Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByEmail(string email);

        IEnumerable<User> FindLastRecord();
    }
}
