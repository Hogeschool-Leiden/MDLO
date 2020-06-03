namespace CompetentieAppFrontend.Services
{
    public class Cell<TValue>
    {
        public Cell(TValue value) => Value = value;

        public TValue Value { get; }
    }
}