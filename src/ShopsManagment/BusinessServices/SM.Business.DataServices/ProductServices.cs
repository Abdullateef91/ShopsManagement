using SM.Business.DataServices.Interfaces;
using SM.Business.Models;
using System.Reflection;

namespace SM.Business.DataServices
{    public class ProductServices:IProductService
    {
        private List<ProductModel> products = new List<ProductModel>();
        public List<ProductModel> getAll()
        {
            products.Add(new ProductModel { ProductId = 1, Name = "Product1", Description = "Product Description" });
            products.Add(new ProductModel { ProductId = 2, Name = "Product2", Description = "Product Description" });
            products.Add(new ProductModel { ProductId = 3, Name = "Product3", Description = "Product Description" });
            products.Add(new ProductModel { ProductId = 4, Name = "Product4", Description = "Product Description" });
            products.Add(new ProductModel { ProductId = 5, Name = "Product5", Description = "Product Description" });
            return products;
        }

        public void Add(ProductModel model) 
        {
            products.Add(model);
        }

        public void Delete(int id)
        {
            var productToDelete = products.Where(x => x.ProductId == id).FirstOrDefault();
            if (productToDelete != null) 
            {
                products.Remove(productToDelete);
            }
            
        }
    }
}