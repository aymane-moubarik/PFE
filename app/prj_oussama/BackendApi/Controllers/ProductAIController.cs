using Microsoft.AspNetCore.Mvc;
using BackendApi.Models;
using BackendApi.Services;
using System.Collections.Generic;
using System.Linq;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductAIController : ControllerBase
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Nom = "Produit A", CodeBarres = "123456", DateProduction = System.DateTime.UtcNow.AddMonths(-1), DateExpiration = System.DateTime.UtcNow.AddDays(6) },
            new Product { Id = 2, Nom = "Produit B", CodeBarres = "789012", DateProduction = System.DateTime.UtcNow.AddMonths(-2), DateExpiration = System.DateTime.UtcNow.AddDays(30) }
        };
        private static readonly List<Sale> _sales = new List<Sale>
        {
            new Sale { Id = 1, ProductId = 1, Quantite = 2, DateVente = System.DateTime.UtcNow.AddDays(-2) },
            new Sale { Id = 2, ProductId = 1, Quantite = 1, DateVente = System.DateTime.UtcNow.AddDays(-10) },
            new Sale { Id = 3, ProductId = 2, Quantite = 5, DateVente = System.DateTime.UtcNow.AddDays(-5) }
        };
        private readonly ProductAIModule _aiModule = new ProductAIModule();

        [HttpGet("propose-action/{productId}")]
        public ActionResult<string> ProposeAction(int productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product == null) return NotFound("Produit non trouvé");
            var action = _aiModule.ProposeAction(product, _sales);
            return Ok(action);
        }
    }
}
