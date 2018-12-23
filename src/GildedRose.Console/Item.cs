namespace GildedRose.Console
{
    public class Item
    {
        public string Name { get; set; }

        /// <summary>
        /// Number of days before an item must be sold.
        /// </summary>
        public int SellIn { get; set; }

        /// <summary>
        /// How valuable a given item is.
        /// </summary>
        public int Quality { get; set; }
    }
}