using System;
using System.Collections.Generic;
using System.Linq;
using BackendApi.Models;

namespace BackendApi.Services
{
    public class ProductAIModule
    {
        // Analyse simple basée sur des règles
        public string ProposeAction(Product product, IEnumerable<Sale> sales)
        {
            var now = DateTime.UtcNow;
            var daysToExpire = (product.DateExpiration - now).TotalDays;
            var recentSales = sales.Where(s => s.ProductId == product.Id && (now - s.DateVente).TotalDays < 30).Sum(s => s.Quantite);

            if (daysToExpire < 7)
            {
                if (recentSales < 5)
                    return "Retirer du stock (faible vente, expiration proche)";
                else
                    return "Remise immédiate (expiration proche)";
            }
            else if (daysToExpire < 30)
            {
                if (recentSales < 10)
                    return "Promotion recommandée (ventes faibles, expiration < 1 mois)";
                else
                    return "Surveiller (ventes correctes, expiration < 1 mois)";
            }
            else
            {
                if (recentSales < 3)
                    return "Promotion légère (ventes très faibles)";
                else
                    return "Aucune action nécessaire";
            }
        }
    }
}
