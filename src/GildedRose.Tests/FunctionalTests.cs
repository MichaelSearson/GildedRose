using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    /// <summary>
    /// Represents all the tests necessary for the business rules defined in the README
    /// that are not already covered by the regression suite.
    /// </summary>
    public class FunctionalTests
    {
        private const string FunctionalCollection = "Functional";

        [Fact]
        public void ItemSellInLowersByOneEachDay()
        {
            var item = new Item
            {
                Name = "+5 Dexterity Vest",
                SellIn = 10,
                Quality = 20
            };

            Program.Items = new List<Item> { item };

            Program.Execute();

            bool validFirstDay = Program.Items[0].SellIn == 9;

            Program.Execute();

            bool validSecondDay = Program.Items[0].SellIn == 8;

            Assert.True(validFirstDay && validSecondDay);
        }

        [Fact]
        public void ItemQualityLowersByOneEachDay()
        {
            var item = new Item
            {
                Name = "+5 Dexterity Vest",
                SellIn = 10,
                Quality = 20
            };

            Program.Items = new List<Item> { item };

            Program.Execute();

            bool validFirstDay = Program.Items[0].Quality == 19;

            Program.Execute();

            bool validSecondDay = Program.Items[0].Quality == 18;

            Assert.True(validFirstDay && validSecondDay);
        }

        [Fact]
        public void ItemQualityDegradesTwiceAsFastAfterSellBy()
        {
            var item = new Item
            {
                Name = "+5 Dexterity Vest",
                SellIn = 1,
                Quality = 10
            };

            Program.Items = new List<Item> { item };

            Program.Execute();

            bool validFirstDay = Program.Items[0].Quality == 9;

            Program.Execute();

            bool validSecondDay = Program.Items[0].Quality == 7;

            Assert.True(validFirstDay && validSecondDay);
        }

        [Fact]
        public void ItemQualityIsNeverNegative()
        {
            var item = new Item
            {
                Name = "+5 Dexterity Vest",
                SellIn = 0,
                Quality = 1
            };

            Program.Items = new List<Item> { item };

            Program.Execute();

            bool validFirstDay = Program.Items[0].Quality == 0;

            Program.Execute();

            bool validSecondDay = Program.Items[0].Quality == 0;

            Assert.True(validFirstDay && validSecondDay);
        }

        [Fact]
        public void ItemQualityIsNeverMoreThanFiftyForNormalItems()
        {
            var item = new Item
            {
                Name = "Aged Brie",
                SellIn = 10,
                Quality = 49
            };

            Program.Items = new List<Item> { item };

            Program.Execute();

            bool validFirstDay = Program.Items[0].Quality == 50;

            Program.Execute();

            bool validSecondDay = Program.Items[0].Quality == 50;

            Assert.True(validFirstDay && validSecondDay);
        }

        [Fact]
        public void LegendaryItemsDoNotDegradeInQuality()
        {
            var item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 0,
                Quality = 80
            };

            Program.Items = new List<Item> { item };

            Program.Execute();

            Assert.True(Program.Items[0].Quality == 80);
        }

        [Fact]
        public void BackstagePassItemsIncreaseInQuality()
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 11,
                Quality = 20
            };

            Program.Items = new List<Item> { item };

            Program.Execute();

            bool validFirstDay = Program.Items[0].Quality == 21;

            Program.Execute();

            bool validSecondDay = Program.Items[0].Quality == 23;

            // Skip to the next change in quality step value.
            Program.Items[0].SellIn = 5;

            Program.Execute();

            bool validThirdDay = Program.Items[0].Quality == 26;

            Assert.True(validFirstDay && validSecondDay && validThirdDay);
        }

        [Fact]
        public void BackstagePassItemsHaveNoQualityAfterConcert()
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 0,
                Quality = 20
            };

            Program.Items = new List<Item> { item };

            Program.Execute();

            Assert.True(Program.Items[0].Quality == 0);
        }

        [Fact]
        public void ConjuredItemsDegradeTwiceAsFastAsNormalItems()
        {
            var item = new Item
            {
                Name = "Conjured Mana Cake",
                SellIn = 1,
                Quality = 5
            };

            Program.Items = new List<Item> { item };

            Program.Execute();

            bool validFirstDay = Program.Items[0].Quality == 3;

            Program.Execute();

            bool validSecondDay = Program.Items[0].Quality == 0;

            Assert.True(validFirstDay && validSecondDay);
        }
    }
}