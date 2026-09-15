using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using testAPI_2.DBContext;
using testAPI_2.DTOs;
using testAPI_2.Models;
using testAPI_2.Services.Interfaces;

namespace testAPI_2.Services.Implementations
{
    public class ProductDbService : IProductService
    {
        private readonly LearnApiContext _context;

        public ProductDbService(LearnApiContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            List<Product> listProd = _context.Products.ToList();
            return listProd;
        }

        public Product GetProductsById(int id)
        {
            Product? prod = _context.Products.Find(id);
            if(prod == null)
            {
                throw new Exception($"id: {id} không tồn tại");
            }
            return prod;
        }

        public Product InsertProduct(ProductDto product)
        {
            Product prod = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
            };
            _context.Products.Add(prod);
            _context.SaveChanges();

            //var res = prod; lay ra id tu tang (identity)
            return prod;
        }

        //public bool UpdateProduct(int id, ProductDto product)
        //{
        //    Product? prod = _context.Products.FirstOrDefault(x => x.Id == id);
        //    if(prod == null) return false;

        //    prod.Name = product.Name;
        //    prod.Price = product.Price;
        //    prod.Stock = product.Stock;
        //    prod.CategoryId = product.CategoryId;
        //    _context.SaveChanges();


        //    return true;

        //}

        public bool UpdateProduct(int id, ProductDto product)
        {
            Product prod = new Product()
            {
                Id = id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId
            };

            _context.Products.Update(prod);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteProduct(int id)
        {
            Product prod = _context.Products.FirstOrDefault(x => x.Id == id);
            if(prod == null)
            {
                return false;
            }
            _context.Products.Remove(prod);
            _context.SaveChanges();
            return true;
        }
    }
}
