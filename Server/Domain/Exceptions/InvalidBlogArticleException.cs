namespace Domain.Exceptions
{
    public class InvalidBlogArticleException: BaseDomainException
    {
        public InvalidBlogArticleException()
        {

        }

        public InvalidBlogArticleException(string error) => this.Error = error;
    }
}
