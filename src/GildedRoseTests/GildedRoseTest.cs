using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Theory]
        [InlineData(1, 0, 1)]
        [InlineData(0, 0, 2)]
        [InlineData(-1, 0, 2)]
        [InlineData(-1, 50, 50)]
        public void AgedBrie_Quality(int sellIn, int quality, int expectedQuality)
        {
            var Items = new List<Item> { new() { Name = "Aged Brie", SellIn = sellIn, Quality = quality } };
            var sut = new GildedRose(Items);
            sut.UpdateQuality();
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(1, 0, 0)]
        [InlineData(0, 0, -1)]
        [InlineData(-1, 0, -2)]
        public void AgedBrie_SellIn(int sellIn, int quality, int expectedSellIn)
        {
            var Items = new List<Item> { new() { Name = "Aged Brie", SellIn = sellIn, Quality = quality } };
            var sut = new GildedRose(Items);
            sut.UpdateQuality();
            Assert.Equal(expectedSellIn, Items[0].SellIn);
        }
    }
}
