using System;

namespace Demo.Api
{
    public class RandomProvider : IRandomProvider
    {
        private readonly Random _random;

        public RandomProvider() => _random = new Random();

        public int Next(in int minimum, in int maximum) => _random.Next(minimum, maximum);

        public int Next(in int maximum) => _random.Next(maximum);
    }
}