using System;
using BackendApi.Models;

namespace BackendApi.Services
{
    public class BarcodeScannerService
    {
        // Simule un scan de code-barres et retourne des dates fictives
        public (DateTime dateProduction, DateTime dateExpiration) ScanBarcode(string barcode)
        {
            // Simulation : génère des dates en fonction du code-barres
            // (en vrai, ici on appellerait un service tiers)
            var now = DateTime.UtcNow;
            var prod = now.AddDays(-10); // production il y a 10 jours
            var exp = now.AddMonths(6);  // expiration dans 6 mois
            return (prod, exp);
        }
    }
}
