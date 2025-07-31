using System;

namespace BackendApi.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantite { get; set; }
        public DateTime DateVente { get; set; }

        public Product Product { get; set; }
    }
}
