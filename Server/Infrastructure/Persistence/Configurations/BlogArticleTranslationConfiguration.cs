using Domain.Models.BlogArticles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Models.ModelConstants.BlogArticleTranslation;

namespace Infrastructure.Persistence.Configurations
{
    public class BlogArticleTranslationConfiguration : IEntityTypeConfiguration<BlogArticleTranslation>
    {
        public void Configure(EntityTypeBuilder<BlogArticleTranslation> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Content)
                .HasMaxLength(ContentMaxLength)
                .IsUnicode(true)
                .IsRequired(true);

            builder.Property(p => p.Content)
                .HasMaxLength(TitleMaxLength)
                .IsUnicode(true)
                .IsRequired(true);

            builder.Property(a => a.Language)
                .IsRequired();

            builder.OwnsOne(p => p.Language, o =>
            {
                o.WithOwner();
                o.Property(p => p.Value);
            });
        }
    }
}
