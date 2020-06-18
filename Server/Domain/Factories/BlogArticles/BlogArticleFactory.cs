using Domain.Models.BlogArticles;
using System;
using System.Collections.Generic;

namespace Domain.Factories.BlogArticles
{
    public class BlogArticleFactory : IBlogArticleFactory
    {
        private DateTime DateOfCreation = default;

        private DateTime DateOfLastEdit  = default;

        private byte[] imageByteArray  = default;


        private HashSet<BlogArticleTranslation> blogArticleTranslations = default;

        public IBlogArticleFactory WithDateOfCreation(DateTime dateOfCreation)
        {
            this.DateOfCreation = dateOfCreation;

            return this;
        }

        public IBlogArticleFactory WithTranslation(params BlogArticleTranslation[] translations)
        {
            foreach (var translation in translations)
            {
                this.blogArticleTranslations.Add(translation);
            }
          
            return this;
        }

        public IBlogArticleFactory WithDateOfLastEdit(DateTime dateOfLastEdit)
        {
            this.DateOfLastEdit = dateOfLastEdit;

            return this;
        }

        public IBlogArticleFactory WithImageByteArray(byte[] imageArray)
        {
            this.imageByteArray = imageArray;

            return this;
        }
        public BlogArticle Build()
        {
            return new BlogArticle(
                this.DateOfCreation,
                this.DateOfLastEdit,
                this.blogArticleTranslations,
                this.imageByteArray
                );
        }

    }
}
