namespace GildedRoseKata.ItemQualityCalculator
{
    public interface IItemQualityCalculatorProvider
    {
        IItemQualityCalculator Get(string name);
    }
}