using Domain.Models;
using System;

namespace Domain.Common
{
    public abstract class TranslationEntity<TId>: Entity<TId>
        where TId: struct
    {
        public Language Language { get; protected set; }
    }
}
