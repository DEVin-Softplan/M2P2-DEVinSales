using DevInSales.Models;

namespace DevInSales.Seeds
{
    public static class CitySeed
    {

        public static List<City> Seed()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\Seeds\CitySeed.csv");
            
            string[] text = System.IO.File.ReadAllLines(sFile);   
            List<City> list = new List<City>();
            foreach (string line in text)
            {
                var dados = line.Split(',');
                list.Add(new City
                {
                    Id = Convert.ToInt32(dados[0]),
                    Name = dados[3],
                    State_Id = Convert.ToInt32(dados[1])

                });
            }
         
            return list;
        
        }
        
    }
}
