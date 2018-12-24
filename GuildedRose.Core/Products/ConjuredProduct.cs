namespace GuildedRose.Core.Products
{
    public class ConjuredProduct : Product
    {
        public ConjuredProduct(
            string name,
            int sellIn,
            uint quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
            QualityDirection = ProductEnums.QualityDirection.Decrease;
        }

        protected override void UpdateQuality()
        {
            // Conjured products degrade twice as fast as normal products.
            if (Quality > 0)
                Quality--;

            base.UpdateQuality();
        }
    }
}