using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string CodeBarres { get; set; }
        public DateTime DateProduction { get; set; }
        public DateTime DateExpiration { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
