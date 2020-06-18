using Domain.Common;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using static Domain.Models.ModelConstants.BlogArticle;

namespace Domain.Models.BlogArticles
{
    public class BlogArticle : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<BlogArticleTranslation> blogArticleTranslations;

        internal BlogArticle(DateTime dateOfCreation, DateTime dateOfLastEdit, HashSet<BlogArticleTranslation> blogArticleTranslations, byte[] imageByteArray)
        {
            this.ValidateDateOfCreation(dateOfCreation);
            this.ValidateImageByteArray(imageByteArray, ImageByteArrayMinSize, ImageByteArrayMaxSize, nameof(imageByteArray));

            this.blogArticleTranslations = blogArticleTranslations;
            this.DateOfCreation = dateOfCreation;
            this.imageByteArray = imageByteArray;
            this.DateOfLastEdit = dateOfLastEdit;
        }

        // This Constructor is Used for EF Core
        private BlogArticle(DateTime dateOfCreation)
        {
            this.ValidateDateOfCreation(dateOfCreation);

            this.DateOfCreation = dateOfCreation;
            this.DateOfLastEdit = this.DateTimeNow();
            this.blogArticleTranslations = default;
        }

        public DateTime DateOfCreation { get; private set; } = default;

        public DateTime DateOfLastEdit { get; private set; } = default;

        public byte[] imageByteArray { get; private set; } = new byte[ImageByteArrayMaxSize];

        public IReadOnlyCollection<BlogArticleTranslation> BlogArticleTranslations => this.blogArticleTranslations.ToList().AsReadOnly();

        public void AddTranslation(BlogArticleTranslation translation)
        {
            this.ValidateTranslationExist(translation);

            this.blogArticleTranslations.Add(translation);
        }

        public BlogArticle EditTranslation(BlogArticleTranslation updatedTranslation)
        {
            var id = updatedTranslation.Id;

            var oldtranslation = this.blogArticleTranslations
                .Where(t => t.Id == id)
                .FirstOrDefault();

            this.ValidateTranslation(oldtranslation, updatedTranslation, id);

            this.blogArticleTranslations.Remove(oldtranslation);

            this.blogArticleTranslations.Add(updatedTranslation);

            return this;
        }

        public BlogArticle DeleteTranslation(BlogArticleTranslation blogArticleTranslation)
        {
            var id = blogArticleTranslation.Id;

            var translation = this.blogArticleTranslations
                .Where(t => t.Id == id)
                .FirstOrDefault();

            this.ValidateTranslation(translation, blogArticleTranslation, id);

            this.blogArticleTranslations.Remove(translation);

            return this;
        }

        public BlogArticle AddDateOfCreation(DateTime dateOfCreation)
        {
            this.ValidateDateOfCreation(dateOfCreation);

            this.DateOfCreation = dateOfCreation;

            return this;
        }
        public BlogArticle UpdateDateOfLastEdit()
        {
            this.DateOfLastEdit = this.DateTimeNow();

            return this;
        }

        public BlogArticle UpdateImageByteArray(byte[] newImageByteArr)
        {
            this.ValidateImageByteArray(newImageByteArr, ImageByteArrayMinSize, ImageByteArrayMaxSize, nameof(imageByteArray));

            this.imageByteArray = newImageByteArr;

            return this;
        }

        private void ValidateDateOfCreation(DateTime dateOfCreation)
        {
            Guard.AgainstDateTimeIsDefault<InvalidBlogArticleException>(dateOfCreation, nameof(dateOfCreation));
        }

        private void ValidateTranslation(BlogArticleTranslation oldTranslation, BlogArticleTranslation newTranslation, int id)
        {
            if (oldTranslation.Equals(newTranslation))
            {
                return;
            }

            throw new InvalidBlogArticleException($"Invalid translation with id: {id}");
        }

        private void ValidateImageByteArray(byte[] arr, int minLength, int maxLength, string? propertyName = "value")
        {
            Guard.AgainstByteArrayLength<InvalidBlogArticleException>(arr?.Count() ?? 0, minLength, maxLength, propertyName);
        }

        public void ValidateTranslationExist(BlogArticleTranslation translation)
        {
            var id = translation.Id;

            if (this.blogArticleTranslations.Any(t => t.Id == id))
            {
                throw new InvalidBlogArticleTranslationException($"There cannot be two translations for one language:{ translation.Language.Name }");
            }
        }
    }
}
