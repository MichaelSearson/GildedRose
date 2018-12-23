using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    /// <summary>
    /// Represents all the example data the application was handling before refactoring
    /// started. Used as a baseline for preventing regression.
    /// </summary>
    public class RegressionTests
    {
        [Fact]
        public void DexterityItemTest()
        {
            var item = new Item
            {
                Name = "+5 Dexterity Vest",
                SellIn = 10,
                Quality = 20
            };

            Program program = new Program
            {
                Items = new List<Item> { item }
            };

            program.UpdateQuality();

            Assert.True(program.Items[0].Quality == 19 && program.Items[0].SellIn == 9);
        }

        [Fact]
        public void AgedBrieItemTest()
        {
            var item = new Item
            {
                Name = "Aged Brie",
                SellIn = 2,
                Quality = 0
            };

            Program program = new Program
            {
                Items = new List<Item> { item }
            };

            program.UpdateQuality();

            Assert.True(program.Items[0].Quality == 1 && program.Items[0].SellIn == 1);
        }

        [Fact]
        public void ElixirOfTheMongooseItemTest()
        {
            var item = new Item
            {
                Name = "Elixir of the Mongoose",
                SellIn = 5,
                Quality = 7
            };

            Program program = new Program
            {
                Items = new List<Item> { item }
            };

            program.UpdateQuality();

            Assert.True(program.Items[0].Quality == 6 && program.Items[0].SellIn == 4);
        }

        [Fact]
        public void SulfurasHandOfRagnarosItemTest()
        {
            var item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 0,
                Quality = 80
            };

            Program program = new Program
            {
                Items = new List<Item> { item }
            };

            program.UpdateQuality();

            Assert.True(program.Items[0].Quality == 80 && program.Items[0].SellIn == 0);
        }

        [Fact]
        public void BackstagePassesItemTest()
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            };

            Program program = new Program
            {
                Items = new List<Item> { item }
            };

            program.UpdateQuality();

            Assert.True(program.Items[0].Quality == 21 && program.Items[0].SellIn == 14);
        }

        [Fact]
        public void ConjuredManaCakeItemTest()
        {
            var item = new Item
            {
                Name = "Conjured Mana Cake",
                SellIn = 3,
                Quality = 6
            };

            Program program = new Program
            {
                Items = new List<Item> { item }
            };

            program.UpdateQuality();

            // Note: we haven't implemented the conjured functionality yet so this will 
            // fail...which is good! It acts as a reminder of what the program still 
            // needs to do!
            Assert.True(program.Items[0].Quality == 3 && program.Items[0].SellIn == 1);
        }
    }
}