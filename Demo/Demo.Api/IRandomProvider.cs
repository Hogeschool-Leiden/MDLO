namespace Demo.Api
{
    public interface IRandomProvider
    {
        int Next(in int minimum, in int maximum);
        int Next(in int maximum);
    }
}