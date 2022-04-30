namespace DevInSales.Models
{
    public class StateModel : EntityBase
    {
        public string Name { get; set; }
        public string Initial { get; set; }

        public virtual IEnumerable<StatePrice> StatesPrices{ get; set; }
    }
}
