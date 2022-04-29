namespace DevInSales.Freight.Data.Models
{
    public class StateModel:EntityBase
    {
        public string Name { get; set; }
        public string Initial { get; set; }

        public virtual IEnumerable<StatePriceModel> StatesPrices{ get; set; }
    }
}
