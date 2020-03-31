using System;

namespace Demo.Api
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}