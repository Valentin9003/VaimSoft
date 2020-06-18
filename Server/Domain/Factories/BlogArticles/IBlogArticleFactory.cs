using Domain.Models.BlogArticles;
using System;

namespace Domain.Factories.BlogArticles
{
    public interface IBlogArticleFactory : IFactory<BlogArticle>
    {
        IBlogArticleFactory WithTranslation(params BlogArticleTranslation[] translations);

        IBlogArticleFactory WithImageByteArray(byte[] imageArr);

        IBlogArticleFactory WithDateOfLastEdit(DateTime dateOfLastEdit);

        IBlogArticleFactory WithDateOfCreation(DateTime dateOfCreation);      
    }
}
