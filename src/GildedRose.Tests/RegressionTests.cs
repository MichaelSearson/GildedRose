using GildedRose.Console;
using GildedRose.Core.Inventory;
using GuildedRose.Core.Products;
using Moq;
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
        public void DexterityProductTest()
        {
            var data = new List<Product>
            {
                new NormalProduct
                (
                    "+5 Dexterity Vest",
                    10,
                    20,
                    ProductEnums.QualityDirection.Decrease
                )
            };

            var mock = new Mock<IInventory>();
            mock.Setup(x => x.GetCurrentInventory()).Returns(data);

            var endOfDayProcessor = new EndOfDayProcessor(mock.Object);

            var app = new App(endOfDayProcessor);
            app.Run();

            var currentState = mock.Object.GetCurrentInventory();

            Assert.True(currentState[0].Quality == 19 && currentState[0].SellIn == 9);
        }

        [Fact]
        public void AgedBrieProductTest()
        {
            var data = new List<Product>
            {
                new NormalProduct
                (
                    "Aged Brie",
                    2,
                    0,
                    ProductEnums.QualityDirection.Increase
                )
            };

            var mock = new Mock<IInventory>();
            mock.Setup(x => x.GetCurrentInventory()).Returns(data);

            var endOfDayProcessor = new EndOfDayProcessor(mock.Object);

            var app = new App(endOfDayProcessor);
            app.Run();

            var currentState = mock.Object.GetCurrentInventory();

            Assert.True(currentState[0].Quality == 1 && currentState[0].SellIn == 1);
        }

        [Fact]
        public void ElixirOfTheMongooseProductTest()
        {
            var data = new List<Product>
            {
                new NormalProduct
                (
                    "Elixir of the Mongoose",
                    5,
                    7,
                    ProductEnums.QualityDirection.Decrease
                )
            };

            var mock = new Mock<IInventory>();
            mock.Setup(x => x.GetCurrentInventory()).Returns(data);

            var endOfDayProcessor = new EndOfDayProcessor(mock.Object);

            var app = new App(endOfDayProcessor);
            app.Run();

            var currentState = mock.Object.GetCurrentInventory();

            Assert.True(currentState[0].Quality == 6 && currentState[0].SellIn == 4);
        }

        [Fact]
        public void SulfurasHandOfRagnarosProductTest()
        {
            var data = new List<Product>
            {
                new LegendaryProduct
                (
                    "Sulfuras, Hand of Ragnaros",
                    0,
                    80
                )
            };

            var mock = new Mock<IInventory>();
            mock.Setup(x => x.GetCurrentInventory()).Returns(data);

            var endOfDayProcessor = new EndOfDayProcessor(mock.Object);

            var app = new App(endOfDayProcessor);
            app.Run();

            var currentState = mock.Object.GetCurrentInventory();

            Assert.True(currentState[0].Quality == 80 && currentState[0].SellIn == 0);
        }

        [Fact]
        public void BackstagePassesProductTest()
        {
            var data = new List<Product>
            {
                new BackstagePassProduct
                (
                    "Backstage passes to a TAFKAL80ETC concert",
                    15,
                    20
                )
            };

            var mock = new Mock<IInventory>();
            mock.Setup(x => x.GetCurrentInventory()).Returns(data);

            var endOfDayProcessor = new EndOfDayProcessor(mock.Object);

            var app = new App(endOfDayProcessor);
            app.Run();

            var currentState = mock.Object.GetCurrentInventory();

            Assert.True(currentState[0].Quality == 21 && currentState[0].SellIn == 14);
        }

        [Fact]
        public void ConjuredManaCakeProductTest()
        {
            var data = new List<Product>
            {
                new ConjuredProduct
                (
                    "Conjured Mana Cake",
                    3,
                    6
                )
            };

            var mock = new Mock<IInventory>();
            mock.Setup(x => x.GetCurrentInventory()).Returns(data);

            var endOfDayProcessor = new EndOfDayProcessor(mock.Object);

            var app = new App(endOfDayProcessor);
            app.Run();

            var currentState = mock.Object.GetCurrentInventory();

            Assert.True(currentState[0].Quality == 4 && currentState[0].SellIn == 2);
        }

        [Fact]
        public void HandleMultipleProductsTest()
        {
            var data = new List<Product>
            {
                 new NormalProduct(
                    "+5 Dexterity Vest",
                    10,
                    20,
                    ProductEnums.QualityDirection.Decrease),

                new NormalProduct(
                    "Aged Brie",
                    2,
                    0,
                    ProductEnums.QualityDirection.Increase),

                new NormalProduct(
                    "Elixir of the Mongoose",
                    5,
                    7,
                    ProductEnums.QualityDirection.Decrease),

                 new LegendaryProduct(
                     "Sulfuras, Hand of Ragnaros",
                     0,
                     80),

                new BackstagePassProduct(
                    "Backstage passes to a TAFKAL80ETC concert",
                    15,
                    20),

                new ConjuredProduct(
                    "Conjured Mana Cake",
                    3,
                    6)
            };

            var mock = new Mock<IInventory>();
            mock.Setup(x => x.GetCurrentInventory()).Returns(data);

            var endOfDayProcessor = new EndOfDayProcessor(mock.Object);

            var app = new App(endOfDayProcessor);
            app.Run();

            var currentState = mock.Object.GetCurrentInventory();

            bool firstIsValid = currentState[0].Quality == 19
                && currentState[0].SellIn == 9;

            bool secondIsValid = currentState[1].Quality == 1
                && currentState[1].SellIn == 1;

            bool thirdIsValid = currentState[2].Quality == 6
                && currentState[2].SellIn == 4;

            bool fourthIsValid = currentState[3].Quality == 80
                && currentState[3].SellIn == 0;

            bool fifthIsValid = currentState[4].Quality == 21
                && currentState[4].SellIn == 14;

            bool sixthIsValid = currentState[5].Quality == 4
                && currentState[5].SellIn == 2;

            Assert.True(
                firstIsValid
                && secondIsValid
                && thirdIsValid
                && fourthIsValid
                && firstIsValid
                && sixthIsValid);
        }
    }
}