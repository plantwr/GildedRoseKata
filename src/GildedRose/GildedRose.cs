using System;
using System.Collections.Generic;
using GildedRoseKata.ItemQualityCalculator;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private readonly IItemQualityCalculatorProvider _itemQualityCalculatorProvider;
        IList<Item> Items;

        public GildedRose(IList<Item> Items, IItemQualityCalculatorProvider itemQualityCalculatorProvider)
        {
            this.Items = Items;
            _itemQualityCalculatorProvider = itemQualityCalculatorProvider;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
                var calculator = _itemQualityCalculatorProvider.Get(item.Name);
                item.Quality = calculator.GetNextQualityValue(item.SellIn, item.Quality);
                item.SellIn -= calculator.HasToBeSold ? 1 : 0;
            }
        }
    }
}
