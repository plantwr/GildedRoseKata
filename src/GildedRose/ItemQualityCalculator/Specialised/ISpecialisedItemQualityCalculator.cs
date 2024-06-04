namespace GildedRoseKata.ItemQualityCalculator.Specialised
{
    public interface ISpecialisedItemQualityCalculator : IItemQualityCalculator
    {
        bool CanUpdateItem(string name);
    }
}