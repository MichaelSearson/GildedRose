using GildedRose.Console;
using GildedRose.Core.Inventory;
using GuildedRose.Core.Products;
using Moq;
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
        [Fact]
        public void ProductSellInLowersByOneEachDay()
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

            bool validFirstDay = currentState[0].SellIn == 9;

            app.Run();

            currentState = mock.Object.GetCurrentInventory();

            bool validSecondDay = currentState[0].SellIn == 8;

            Assert.True(validFirstDay && validSecondDay);
        }

        [Fact]
        public void ProductQualityLowersByOneEachDay()
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

            bool validFirstDay = currentState[0].Quality == 19;

            app.Run();

            currentState = mock.Object.GetCurrentInventory();

            bool validSecondDay = currentState[0].Quality == 18;

            Assert.True(validFirstDay && validSecondDay);
        }

        [Fact]
        public void ProductQualityDegradesTwiceAsFastAfterSellBy()
        {
            var data = new List<Product>
            {
                new NormalProduct
                (
                    "+5 Dexterity Vest",
                    1,
                    10,
                    ProductEnums.QualityDirection.Decrease
                )
            };

            var mock = new Mock<IInventory>();
            mock.Setup(x => x.GetCurrentInventory()).Returns(data);

            var endOfDayProcessor = new EndOfDayProcessor(mock.Object);

            var app = new App(endOfDayProcessor);
            app.Run();

            var currentState = mock.Object.GetCurrentInventory();

            bool validFirstDay = currentState[0].Quality == 9;

            app.Run();

            currentState = mock.Object.GetCurrentInventory();

            bool validSecondDay = currentState[0].Quality == 7;

            Assert.True(validFirstDay && validSecondDay);
        }

        [Fact]
        public void ProductQualityIsNeverNegative()
        {
            var data = new List<Product>
            {
                new NormalProduct
                (
                    "+5 Dexterity Vest",
                    0,
                    1,
                    ProductEnums.QualityDirection.Decrease
                )
            };

            var mock = new Mock<IInventory>();
            mock.Setup(x => x.GetCurrentInventory()).Returns(data);

            var endOfDayProcessor = new EndOfDayProcessor(mock.Object);

            var app = new App(endOfDayProcessor);
            app.Run();

            var currentState = mock.Object.GetCurrentInventory();

            bool validFirstDay = currentState[0].Quality == 0;

            app.Run();

            currentState = mock.Object.GetCurrentInventory();

            bool validSecondDay = currentState[0].Quality == 0;

            Assert.True(validFirstDay && validSecondDay);
        }

        [Fact]
        public void ProductQualityIsNeverMoreThanFiftyForNormalProducts()
        {
            var data = new List<Product>
            {
                new NormalProduct
                (
                    "Aged Brie",
                    10,
                    49,
                    ProductEnums.QualityDirection.Increase
                )
            };

            var mock = new Mock<IInventory>();
            mock.Setup(x => x.GetCurrentInventory()).Returns(data);

            var endOfDayProcessor = new EndOfDayProcessor(mock.Object);

            var app = new App(endOfDayProcessor);
            app.Run();

            var currentState = mock.Object.GetCurrentInventory();

            bool validFirstDay = currentState[0].Quality == 50;

            app.Run();

            currentState = mock.Object.GetCurrentInventory();

            bool validSecondDay = currentState[0].Quality == 50;

            Assert.True(validFirstDay && validSecondDay);
        }

        [Fact]
        public void LegendaryProductsDoNotDegradeInQuality()
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

            Assert.True(currentState[0].Quality == 80);
        }

        [Fact]
        public void BackstagePassProductsIncreaseInQualityTenDaysRemaining()
        {
            var data = new List<Product>
            {
                new BackstagePassProduct
                (
                    "Backstage passes to a TAFKAL80ETC concert",
                    11,
                    20
                )
            };

            var mock = new Mock<IInventory>();
            mock.Setup(x => x.GetCurrentInventory()).Returns(data);

            var endOfDayProcessor = new EndOfDayProcessor(mock.Object);

            var app = new App(endOfDayProcessor);
            app.Run();

            var currentState = mock.Object.GetCurrentInventory();

            bool validFirstDay = currentState[0].Quality == 21;

            app.Run();

            currentState = mock.Object.GetCurrentInventory();

            bool validSecondDay = currentState[0].Quality == 23;

            Assert.True(validFirstDay && validSecondDay);
        }

        public void BackstagePassProductsIncreaseInQualityFiveDaysRemaining()
        {
            var data = new List<Product>
            {
                new BackstagePassProduct
                (
                    "Backstage passes to a TAFKAL80ETC concert",
                    5,
                    23
                )
            };

            var mock = new Mock<IInventory>();
            mock.Setup(x => x.GetCurrentInventory()).Returns(data);

            var endOfDayProcessor = new EndOfDayProcessor(mock.Object);

            var app = new App(endOfDayProcessor);
            app.Run();

            var currentState = mock.Object.GetCurrentInventory();

            Assert.True(currentState[0].Quality == 26);
        }

        [Fact]
        public void BackstagePassProductsHaveNoQualityAfterConcert()
        {
            var data = new List<Product>
            {
                new BackstagePassProduct
                (
                    "Backstage passes to a TAFKAL80ETC concert",
                    0,
                    20
                )
            };

            var mock = new Mock<IInventory>();
            mock.Setup(x => x.GetCurrentInventory()).Returns(data);

            var endOfDayProcessor = new EndOfDayProcessor(mock.Object);

            var app = new App(endOfDayProcessor);
            app.Run();

            var currentState = mock.Object.GetCurrentInventory();

            Assert.True(currentState[0].Quality == 0);
        }

        [Fact]
        public void ConjuredProductsDegradeTwiceAsFastAsNormalProducts()
        {
            var data = new List<Product>
            {
                new ConjuredProduct
                (
                    "Conjured Mana Cake",
                    1,
                    5
                )
            };

            var mock = new Mock<IInventory>();
            mock.Setup(x => x.GetCurrentInventory()).Returns(data);

            var endOfDayProcessor = new EndOfDayProcessor(mock.Object);

            var app = new App(endOfDayProcessor);
            app.Run();

            var currentState = mock.Object.GetCurrentInventory();

            bool validFirstDay = currentState[0].Quality == 3;

            app.Run();

            currentState = mock.Object.GetCurrentInventory();

            bool validSecondDay = currentState[0].Quality == 0;

            Assert.True(validFirstDay && validSecondDay);
        }
    }
}