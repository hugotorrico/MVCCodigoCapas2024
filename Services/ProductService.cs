using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService
    {
        private readonly MarketContext _context;

        public ProductService(MarketContext context)
        {
            _context = context;
        }

        public List<Product> Get()
        {
            var query = _context.Products;

            return query.ToList();
        }
        public List<Product> GetByFilterName(string name)
        {
            var query = _context.Products.Where(x=>x.Name.Contains(name));

            return query.ToList();
        }
        public void Insert(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

        }
    }
}
