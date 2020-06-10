namespace CompetentieAppFrontend.Services.Projections
{
    public class Cell<TValue>
    {
        public Cell(TValue value) => Value = value;

        public TValue Value { get; }
    }
}