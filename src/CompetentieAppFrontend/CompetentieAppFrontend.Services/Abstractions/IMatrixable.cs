namespace CompetentieAppFrontend.Services.Abstractions
{
    public interface IMatrixable<out TValue>
    {
        public string XHeader { get; }

        public string YHeader { get; }

        public TValue Value { get; }
    }
}