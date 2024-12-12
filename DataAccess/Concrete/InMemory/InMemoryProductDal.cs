using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>() {
        new Product{CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=14,ProductId=1},
        new Product{CategoryId=1,ProductName="Kamera",UnitPrice=12,UnitsInStock=14,ProductId=2},
        new Product{CategoryId=2,ProductName="Telefon",UnitPrice=16,UnitsInStock=14,ProductId=3},
        new Product{CategoryId=2,ProductName="Klavye",UnitPrice=1,UnitsInStock=14,ProductId=4},
        new Product{CategoryId=2,ProductName="Fare",UnitPrice=150,UnitsInStock=14,ProductId=5},
    };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
   
            Product productToDelete=_products.SingleOrDefault(p=>p.ProductId==product.ProductId);    

            _products.Remove(productToDelete);  
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {

            return _products.Where(p=>p.CategoryId==categoryId).ToList();
            //return Product productByCategory=_products.SingleOrDefault(p=>p.CategoryId==categoryId)
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName= product.ProductName;
            productToUpdate.UnitPrice= product.UnitPrice;
            productToUpdate.ProductId= product.ProductId;
            productToUpdate.CategoryId= product.CategoryId;
            productToUpdate.UnitsInStock= product.UnitsInStock;
        }
    }
}
