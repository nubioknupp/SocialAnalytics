using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SocialAnalytics.Domain.Entities;
using SocialAnalytics.Infra.Data.EntityConfig;

namespace SocialAnalytics.Infra.Data.Context
{
    public class SocialAnalyticsContext : DbContext
    {
        public SocialAnalyticsContext() : base("SocialConnection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Stargazers> Stargazerses { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new StargazersConfig());

            base.OnModelCreating(modelBuilder);
        }

    }
}
