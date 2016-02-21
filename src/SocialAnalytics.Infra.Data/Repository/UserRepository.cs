using System.Collections.Generic;
using System.Linq;
using Dapper;
using SocialAnalytics.Domain.Entities;
using SocialAnalytics.Domain.Interfaces.Repository;

namespace SocialAnalytics.Infra.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public User FindByEmail(string email)
        {
            return Find(u => u.Email == email).FirstOrDefault();
        }

        public IEnumerable<User> FindLastRecord()
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM users INNER JOIN  stargazers ON users.UserId = stargazers.UserId " +
                        "WHERE DateImport IN (SELECT MAX(DateImport) FROM stargazers)";

            var users = cn.Query<User, Stargazers, User>(sql,
                (u, s) =>
                {
                    u.Stargazers.Add(s);
                    return u;
                }, splitOn: "UserId, StargazersId");

            return users;
        }
    }
}
