namespace GuildedRose.Core.Products
{
    /// <summary>
    /// Legendary products cannot be changed.
    /// </summary>
    public class LegendaryProduct : Product
    {
        public LegendaryProduct(
            string name,
            int sellIn,
            uint quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
            QualityDirection = ProductEnums.QualityDirection.None;
        }

        protected override void UpdateQuality()
        {
            // Quality does not change for legendary products.
        }

        protected override void UpdateSellIn()
        {
            // Sell In does not change for legendary products.
        }
    }
}