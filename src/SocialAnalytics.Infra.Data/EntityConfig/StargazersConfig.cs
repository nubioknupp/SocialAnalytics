using System.Data.Entity.ModelConfiguration;
using SocialAnalytics.Domain.Entities;

namespace SocialAnalytics.Infra.Data.EntityConfig
{
    class StargazersConfig : EntityTypeConfiguration<Stargazers>
    {
        public StargazersConfig()
        {
            HasKey(e => e.StargazersId);

            Property(e => e.Count)
               .IsRequired();

            Property(e => e.DateImport)
                .IsRequired();

            HasRequired(e => e.User)
                .WithMany(c => c.Stargazers)
                .HasForeignKey(e => e.UserId);

            ToTable("Stargazers");
        }
    }
}
