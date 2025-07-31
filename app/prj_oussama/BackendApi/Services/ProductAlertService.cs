using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BackendApi.Models;

namespace BackendApi.Services
{
    public class ProductAlertService
    {
        private readonly List<Product> _products;
        private Timer _timer;

        public ProductAlertService(List<Product> products)
        {
            _products = products;
        }

        public void Start()
        {
            // Exécute la tâche chaque jour
            _timer = new Timer(CheckExpiringProducts, null, TimeSpan.Zero, TimeSpan.FromDays(1));
        }

        private void CheckExpiringProducts(object state)
        {
            var now = DateTime.UtcNow;
            var expiring = _products.Where(p => (p.DateExpiration - now).TotalDays <= 7 && (p.DateExpiration - now).TotalDays > 0).ToList();
            foreach (var product in expiring)
            {
                SendAlert(product);
            }
        }

        private void SendAlert(Product product)
        {
            // Ici, on simule l'envoi d'une alerte (log, notification, etc.)
            Console.WriteLine($"ALERTE : Le produit '{product.Nom}' (code-barres: {product.CodeBarres}) expire le {product.DateExpiration:yyyy-MM-dd}. Options : baisser le prix ou retirer du stock.");
        }
    }
}
