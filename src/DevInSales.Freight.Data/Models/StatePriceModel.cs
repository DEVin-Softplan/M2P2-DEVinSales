namespace DevInSales.Freight.Data.Models
{
    public class StatePriceModel : EntityBase
    {
        public int StateId { get; set; }
        public int ShippingCompanyId { get; set; }
        public decimal BasePreco { get; set; }

        public virtual StateModel State { get; set; }
        public virtual ShippingCompanyModel ShippingCompany { get; set; }


    }
}
