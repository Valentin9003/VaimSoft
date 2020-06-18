using Domain.Common;

namespace Domain.Models
{
    public class Language : Enumeration
    {
        public static Language BG = new Language(0, nameof(BG));
        public static Language EN = new Language(1, nameof(EN));

        private Language(int value)
           : this(value, FromValue<Language>(value).Name)
        {
        }

        private Language(int value, string name) 
            : base(value, name)
        {
        }
    }
}
