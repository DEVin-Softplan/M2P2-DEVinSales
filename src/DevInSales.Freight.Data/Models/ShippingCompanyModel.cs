namespace DevInSales.Freight.Data.Models
{
    public class ShippingCompanyModel: EntityBase
    {
        public string Name { get; set; }
        public virtual IEnumerable<StatePriceModel> StatesPrices { get; set; }

    }
}
