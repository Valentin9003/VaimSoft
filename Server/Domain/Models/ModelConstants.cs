using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ModelConstants
    {
        public  class Common
        {
            public static int MaxUrlLength = 2048;
        }

        public class BlogArticle
        { 
            public static int ImageByteArrayMaxSize = 5*1024*1024;

            public static int ImageByteArrayMinSize = 100;

            public static int BlogArticleTranslationsMinLength = 1;

            public static int BlogArticleTranslationsMaxLength = 2;
        }
            public class BlogArticleTranslation
        {
            public static int TitleMaxLength = 130;

            public static int ContentMaxLength = 15000;
        }
    }
}
