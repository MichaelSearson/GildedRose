using System.Collections.Generic;

namespace GildedRose.Console
{
    /// <summary>
    /// Handles the end of day processes necessary for the Guilded Rose.
    /// </summary>
    public class EndOfDayProcessor
    {
        private const string BrieName = "Aged Brie";
        private const string BackstageName = "Backstage passes to a TAFKAL80ETC concert";
        private const string ConjuredName = "Conjured Mana Cake";

        private readonly IList<Item> _inventoryItems;

        public EndOfDayProcessor(IList<Item> inventoryItems)
        {
            _inventoryItems = inventoryItems;
        }

        /// <summary>
        /// Works through the provided inventory and updates the quality / sell in values
        /// as appropriate.
        /// </summary>
        public void UpdateInventory()
        {
            for (var i = 0; i < _inventoryItems.Count; i++)
            {
                var current = _inventoryItems[i];

                // Legendary items don't have to be sold, nor do they decrease in
                // quality.
                if (IsLegendaryItem(current))
                    continue;

                if (current.Name == BackstageName && current.SellIn <= 0)
                {
                    current.Quality = 0;
                }
                else if (ShouldIncreaseInQuality(current))
                {
                    if (current.Quality != 50)
                        ProcessIncreaseInQuality(current);
                }
                else if (current.Quality > 0)
                {
                    // Conjured items degrade in quality twice as fast as normal.
                    if (current.Name == ConjuredName)
                        current.Quality--;

                    // Handle the "normal item" base case.
                    current.Quality--;
                }

                current.SellIn--;

                // If the sell by date has passed the quality degrades twice as fast.
                if (current.Quality > 0 && current.SellIn < 0)
                    current.Quality--;
            }
        }

        #region Helpers

        /// <summary>
        /// Work out if the provided <paramref name="item"/> is legendary.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool IsLegendaryItem(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        /// <summary>
        /// Work out if the provided <paramref name="item"/> can increase its quality
        /// over time. Does not validate quality maximum.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ShouldIncreaseInQuality(Item item)
        {
            return item.Name == BrieName || item.Name == BackstageName;
        }

        /// <summary>
        /// Increase the quality value of the provided <paramref name="item"/>.
        /// </summary>
        /// <param name="item"></param>
        private void ProcessIncreaseInQuality(Item item)
        {
            item.Quality++;

            if (item.Name == BackstageName)
                ProcessBackstagePass(item);
        }

        /// <summary>
        /// Increase the quality of the provided <paramref name="item"/> again if it
        /// meets the Sell In criteria.
        /// </summary>
        /// <param name="item"></param>
        private void ProcessBackstagePass(Item item)
        {
            if (item.SellIn < 11 && item.Quality < 50)
            {
                item.Quality++;
            }

            if (item.SellIn < 6 && item.Quality < 50)
            {
                item.Quality++;
            }
        }

        #endregion Helpers
    }
}