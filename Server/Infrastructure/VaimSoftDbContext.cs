using Domain.Models.BlogArticles;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    internal class VaimSoftDbContext: IdentityDbContext<User>
    {
        public VaimSoftDbContext(DbContextOptions<VaimSoftDbContext> options)
          : base(options)
        {
        }

        public DbSet<BlogArticle> BlogArticle { get; set; } = default!;

        public DbSet<BlogArticleTranslation> BlogArticleTranslations { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
