using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == "Aged Brie")
                {
                    Items[i].Quality = Math.Min(Items[i].Quality + (Items[i].SellIn > 0 ? 1 : 2), 50);
                    Items[i].SellIn -= 1;
                    continue;
                }

                if (Items[i].Name.StartsWith("Sulfuras"))
                {
                    continue;
                }

                if (Items[i].Name.StartsWith("Backstage passes"))
                {
                    if (Items[i].SellIn <= 0)
                    {
                        Items[i].Quality = 0;
                    }
                    else if (Items[i].SellIn <= 5)
                    {
                        Items[i].Quality = Math.Min(Items[i].Quality + 3, 50);
                    }
                    else if (Items[i].SellIn <= 10)
                    {
                        Items[i].Quality = Math.Min(Items[i].Quality + 2, 50);
                    }
                    else
                    {
                        Items[i].Quality = Math.Min(Items[i].Quality + 1, 50);
                    }
                    Items[i].SellIn -= 1;
                    continue;
                }

                if (Items[i].Name.StartsWith("Conjured"))
                {
                    Items[i].Quality = Math.Max(Items[i].Quality - (Items[i].SellIn > 0 ? 2 : 4), 0);
                    Items[i].SellIn = Items[i].SellIn - 1;
                    continue;
                }

                Items[i].Quality = Math.Max(Items[i].Quality - (Items[i].SellIn > 0 ? 1 : 2), 0);
                Items[i].SellIn = Items[i].SellIn - 1;
            }
        }
    }
}
