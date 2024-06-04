namespace GildedRoseKata.ItemQualityCalculator.Specialised
{
    class SulfurasQualityCalculator : ISpecialisedItemQualityCalculator
    {
        public bool HasToBeSold => false;

        public bool CanUpdateItem(string name)
        {
            return name != null && name.StartsWith("Sulfuras");
        }

        public int GetNextQualityValue(int sellIn, int quality)
        {
            return quality;
        }
    }
}