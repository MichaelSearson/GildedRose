using GuildedRose.Core.Products;
using System.Collections.Generic;

namespace GildedRose.Core.Inventory
{
    public class Inventory : IInventory
    {
        /// <summary>
        /// Retrieves the complete current state of the inventory.
        /// </summary>
        /// <returns></returns>
        public IList<Product> GetCurrentInventory()
        {
            // Note: that this could easily be resolved from file, database, network etc.
            return new List<Product>
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
        }
    }
}