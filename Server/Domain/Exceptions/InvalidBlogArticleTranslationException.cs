namespace Domain.Exceptions
{
    public class InvalidBlogArticleTranslationException : BaseDomainException
    {
        public InvalidBlogArticleTranslationException()
        {

        }
        public InvalidBlogArticleTranslationException(string error)
        {
            this.Error = error;
        }
    }
}
