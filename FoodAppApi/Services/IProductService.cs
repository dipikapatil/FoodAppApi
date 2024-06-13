using FoodAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Services
{
    public interface IProductService
    {     
        public List<Category> GetCategories();
        public List<Product> GetProducts();
        public void AddEntity(object model);

        public void Update(object model);
    }
}
