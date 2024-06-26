using System;

namespace GildedRoseKata.ItemQualityCalculator.Specialised
{
    class AgedBrieQualityCalculator : ISpecialisedItemQualityCalculator
    {
        public bool HasToBeSold => true;

        public bool CanUpdateItem(string name)
        {
            return name == "Aged Brie";
        }

        public int GetNextQualityValue(int sellIn, int quality)
        {
            return Math.Min(
                quality + (sellIn > 0 ? Constants.StandardQualityIncrement : Constants.StandardQualityIncrement * 2),
                Constants.MaxQuality
            );
        }
    }
}