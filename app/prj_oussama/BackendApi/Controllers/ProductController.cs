using Microsoft.AspNetCore.Mvc;
using BackendApi.Models;
using BackendApi.Services;
using System;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly BarcodeScannerService _barcodeScannerService = new BarcodeScannerService();

        [HttpPost("scan-barcode")]
        public ActionResult<ProductScanResult> ScanBarcode([FromBody] BarcodeScanRequest request)
        {
            var (dateProd, dateExp) = _barcodeScannerService.ScanBarcode(request.Barcode);
            return Ok(new ProductScanResult
            {
                DateProduction = dateProd,
                DateExpiration = dateExp
            });
        }
    }

    public class BarcodeScanRequest
    {
        public string Barcode { get; set; }
    }

    public class ProductScanResult
    {
        public DateTime DateProduction { get; set; }
        public DateTime DateExpiration { get; set; }
    }
}
