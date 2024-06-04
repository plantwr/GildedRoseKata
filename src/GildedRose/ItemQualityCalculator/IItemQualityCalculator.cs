namespace GildedRoseKata.ItemQualityCalculator
{
    public interface IItemQualityCalculator
    {
        bool CanUpdateItem(string name);
        int GetNextQualityValue(int sellIn, int quality);
        bool HasToBeSold { get; }
    }
}