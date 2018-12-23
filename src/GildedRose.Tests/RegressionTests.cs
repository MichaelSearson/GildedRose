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

            Program.Items = new List<Item> { item };
            Program.Execute();

            Assert.True(Program.Items[0].Quality == 19 && Program.Items[0].SellIn == 9);
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

            Program.Items = new List<Item> { item };

            Program.Execute();

            Assert.True(Program.Items[0].Quality == 1 && Program.Items[0].SellIn == 1);
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

            Program.Items = new List<Item> { item };

            Program.Execute();

            Assert.True(Program.Items[0].Quality == 6 && Program.Items[0].SellIn == 4);
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

            Program.Items = new List<Item> { item };

            Program.Execute();

            Assert.True(Program.Items[0].Quality == 80 && Program.Items[0].SellIn == 0);
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

            Program.Items = new List<Item> { item };

            Program.Execute();

            Assert.True(Program.Items[0].Quality == 21 && Program.Items[0].SellIn == 14);
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

            Program.Items = new List<Item> { item };

            Program.Execute();

            // Note: we haven't implemented the conjured functionality yet so this will
            // fail...which is good! It acts as a reminder of what the program still
            // needs to do!
            Assert.True(Program.Items[0].Quality == 4 && Program.Items[0].SellIn == 2);
        }

        [Fact]
        public void HandleMultipleItemsTest()
        {
            Program.Items = new List<Item>
            {
                new Item
                {
                    Name = "+5 Dexterity Vest",
                    SellIn = 10,
                    Quality = 20
                },
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 2,
                    Quality = 0
                },
                new Item
                {
                    Name = "Elixir of the Mongoose",
                    SellIn = 5,
                    Quality = 7
                },
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = 0,
                    Quality = 80
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 3,
                    Quality = 6
                }
            };

            Program.Execute();

            bool firstIsValid = Program.Items[0].Quality == 19
                && Program.Items[0].SellIn == 9;

            bool secondIsValid = Program.Items[1].Quality == 1
                && Program.Items[1].SellIn == 1;

            bool thirdIsValid = Program.Items[2].Quality == 6
                && Program.Items[2].SellIn == 4;

            bool fourthIsValid = Program.Items[3].Quality == 80
                && Program.Items[3].SellIn == 0;

            bool fifthIsValid = Program.Items[4].Quality == 21
                && Program.Items[4].SellIn == 14;

            bool sixthIsValid = Program.Items[5].Quality == 4
                && Program.Items[5].SellIn == 2;

            // TODO: uncomment the sixth boolean check when conjured functionality is 
            // implemented.
            Assert.True(
                firstIsValid
                && secondIsValid
                && thirdIsValid
                && fourthIsValid
                && firstIsValid
                /*&& sixthIsValid*/);
        }
    }
}