namespace GuildedRose.Core.Products
{
    public class NormalProduct : Product
    {
        public NormalProduct(
            string name,
            int sellIn,
            uint quality,
            ProductEnums.QualityDirection qualityDirection)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
            QualityDirection = qualityDirection;
        }
    }
}