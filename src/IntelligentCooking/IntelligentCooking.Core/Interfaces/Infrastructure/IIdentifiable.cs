namespace IntelligentCooking.Core.Interfaces.Infrastructure
{
    public interface IIdentifiable<TKey>
    {
        TKey Id { get; }
    }
}
