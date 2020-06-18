using System;

namespace Domain.Exceptions
{
    public class BaseDomainException: Exception
    {
        private string? error;

        public string Error
        {
            get => this.error ?? base.Message;
            set => this.error = value;
        }
    }
}
