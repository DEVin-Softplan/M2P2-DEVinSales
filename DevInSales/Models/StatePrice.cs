using DevInSales.Models;

public class StatePrice : EntityBase
{
    public int StateId { get; set; }
    public int ShippingCompanyId { get; set; }
    public decimal BasePrice { get; set; }

    public virtual StateModel State { get; set; }
    public virtual ShippingCompany ShippingCompany { get; set; }


}
