using System.Collections.Generic;

namespace GildedRose.Console
{
    public static class Program
    {
        public static IList<Item> Items;

        private static void Main()
        {
            System.Console.WriteLine("OMGHAI!");

            Execute();

            System.Console.ReadKey();
        }

        /// <summary>
        /// Represents the logical start for the application. Allows us to test in
        /// isolation the program logic without the console specific code that may exist
        /// in the <see cref="Main(string[])"/> method.
        /// </summary>
        public static void Execute()
        {
            InitialiseState();

            var endOfDayProcessor = new EndOfDayProcessor(Items);
            endOfDayProcessor.UpdateInventory();
        }

        #region Helpers

        /// <summary>
        /// Setup the application to have some data to operate on.
        /// </summary>
        private static void InitialiseState()
        {
            if (Items != null)
                return;

            Items = new List<Item>
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
        }

        #endregion Helpers
    }
}