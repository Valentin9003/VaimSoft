using Domain.Models.BlogArticles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Models.ModelConstants.BlogArticle;

namespace Infrastructure.Persistence.Configurations
{
    public class BlogArticleConfiguration : IEntityTypeConfiguration<BlogArticle>
    {
        public void Configure(EntityTypeBuilder<BlogArticle> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.imageByteArray)
                .HasMaxLength(ImageByteArrayMaxSize)
                .IsRequired(true);

            builder.Property(p => p.DateOfCreation)
                .IsRequired(true);

            builder
                .HasMany(pr => pr.BlogArticleTranslations)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("blogArticleTranslations");

        }
    }
}
