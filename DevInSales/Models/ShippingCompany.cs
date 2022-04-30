namespace DevInSales.Models
{
    public class ShippingCompany : EntityBase
    {
        public string Name { get; set; }
        public virtual IEnumerable<StatePrice> StatesPrices { get; set; }

    }

}
