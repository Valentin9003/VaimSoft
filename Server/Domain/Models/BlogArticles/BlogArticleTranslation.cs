using Domain.Common;
using Domain.Exceptions;
using System;

namespace Domain.Models.BlogArticles
{
    public class BlogArticleTranslation : TranslationEntity<int>
    {
        internal BlogArticleTranslation(string title, string content, Language language)
        {
            this.ValidateTranslation(title, content);

            this.Language = language;
            this.Title = title;
            this.Content = content;
        }

        // This Constructor is Used for EF Core
        private BlogArticleTranslation(string content, string title)
        {

            this.Language = default;
            this.Title = title;
            this.Content = content;
        }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public BlogArticleTranslation ChangeTitle(string newTitle)
        {
            this.ValidateStringIsEmptyOrNull(newTitle, nameof(Title));

            return this;
        }

        public BlogArticleTranslation ChangeContent(string newContent)
        {
            this.ValidateStringIsEmptyOrNull(newContent, nameof(Content));

            this.Content = newContent;

            return this;
        }

        public BlogArticleTranslation AddLanguage(Language language)
        {
            this.ValidateLanguage(language);
            this.Language = language;

            return this;
        }

        private void ValidateLanguage(Language language)
        {
            if (language != default)
            {
                return;
            }

            throw new InvalidBlogArticleTranslationException("Cannot change the language after first initialization!");
        }

        private void ValidateStringIsEmptyOrNull(string text, string fieldName)
        {
            Guard.AgainstEmptyString<InvalidBlogArticleTranslationException>(text, fieldName);
        }

        private void ValidateTranslation(string title, string content)
        {
            Guard.AgainstEmptyString<InvalidBlogArticleTranslationException>(title, nameof(Title));
            Guard.AgainstEmptyString<InvalidBlogArticleTranslationException>(content, nameof(Content));
        }
    }
}
