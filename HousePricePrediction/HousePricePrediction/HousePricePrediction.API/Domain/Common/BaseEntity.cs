using System;

namespace HousePricePrediction.API.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
