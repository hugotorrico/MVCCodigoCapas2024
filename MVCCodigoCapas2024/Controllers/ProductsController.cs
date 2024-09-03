using Infraestructure;
using Microsoft.AspNetCore.Mvc;
using MVCCodigoCapas2024.Models;
using Services;

namespace MVCCodigoCapas2024.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MarketContext _context;
        private ProductService _service;



        public ProductsController(MarketContext context)
        {
            _context = context;
            _service = new ProductService(_context);
        }

        public IActionResult Index()
        {
            
            //Lista de entidades de base de datos
            var products = _service.Get();


            //Lista de modelos
            var model = products.Select(x => new ProductModel
            {
                Id = x.ProductID,
                Name = x.Name,
                Price = x.Price
            }).ToList();



            return View(model);
        }
    }
}
