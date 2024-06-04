namespace GildedRoseKata.ItemQualityCalculator
{
    public interface IItemQualityCalculator
    {
        int GetNextQualityValue(int sellIn, int quality);
        bool HasToBeSold { get; }
    }
}