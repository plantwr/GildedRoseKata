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

        [Theory]
        [InlineData(0, 80, 80)]
        [InlineData(-1, 80, 80)]
        public void Sulfuras_Quality(int sellIn, int quality, int expectedQuality)
        {
            var Items = new List<Item> { new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality } };
            var sut = new GildedRose(Items);
            sut.UpdateQuality();
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(0, 80, 0)]
        [InlineData(-1, 80, -1)]
        public void Sulfuras_SellIn(int sellIn, int quality, int expectedSellIn)
        {
            var Items = new List<Item> { new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality } };
            var sut = new GildedRose(Items);
            sut.UpdateQuality();
            Assert.Equal(expectedSellIn, Items[0].SellIn);
        }

        [Theory]
        [InlineData(11, 5, 6)]
        [InlineData(11, 50, 50)]
        [InlineData(10, 5, 7)]
        [InlineData(6, 5, 7)]
        [InlineData(6, 50, 50)]
        [InlineData(5, 5, 8)]
        [InlineData(1, 5, 8)]
        [InlineData(1, 50, 50)]
        [InlineData(0, 5, 0)]
        [InlineData(-1, 5, 0)]
        public void BackstagePasses_Quality(int sellIn, int quality, int expectedQuality)
        {
            var Items = new List<Item> { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };
            var sut = new GildedRose(Items);
            sut.UpdateQuality();
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(1, 5, 0)]
        [InlineData(0, 5, -1)]
        [InlineData(-1, 5, -2)]
        public void BackstagePasses_SellIn(int sellIn, int quality, int expectedSellIn)
        {
            var Items = new List<Item> { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };
            var sut = new GildedRose(Items);
            sut.UpdateQuality();
            Assert.Equal(expectedSellIn, Items[0].SellIn);
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(-1, 1, 0)]
        [InlineData(1, 5, 4)]
        [InlineData(0, 5, 3)]
        [InlineData(-1, 5, 3)]
        public void Default_Quality(int sellIn, int quality, int expectedQuality)
        {
            var Items = new List<Item> { new() { Name = "Elixir of the Mongoose", SellIn = sellIn, Quality = quality } };
            var sut = new GildedRose(Items);
            sut.UpdateQuality();
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(1, 5, 0)]
        [InlineData(0, 5, -1)]
        [InlineData(-1, 5, -2)]
        public void Default_SellIn(int sellIn, int quality, int expectedSellIn)
        {
            var Items = new List<Item> { new() { Name = "Elixir of the Mongoose", SellIn = sellIn, Quality = quality } };
            var sut = new GildedRose(Items);
            sut.UpdateQuality();
            Assert.Equal(expectedSellIn, Items[0].SellIn);
        }
    }
}
