namespace GuildedRose.Core.Products
{
    public class BackstagePassProduct : Product
    {
        public BackstagePassProduct(
            string name,
            int sellIn,
            uint quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
            QualityDirection = ProductEnums.QualityDirection.Increase;
        }

        protected override void UpdateQuality()
        {
            // Passes have no value after the concert.
            if (SellIn <= 0)
            {
                Quality = 0;
                return;
            }

            // Quality increases by two for 10 days or less.
            if (SellIn < 11 && Quality < 50)
                Quality++;

            // Quality increases by three for 5 days or less.
            if (SellIn < 6 && Quality < 50)
                Quality++;

            base.UpdateQuality();
        }
    }
}