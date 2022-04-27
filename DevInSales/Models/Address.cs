namespace DevInSales.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int City_Id { get; set; }
        public string Street { get; set; }
        public string CEP { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
    }
}
