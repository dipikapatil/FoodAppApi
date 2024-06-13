using FoodAppApi.Context;
using FoodAppApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Services
{
    public class ProductService : IProductService
    {
        private FoodContext _context;
        public ProductService(FoodContext context)
        {

            _context = context;
        }

        public void AddEntity(object model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Category> GetCategories()
        {
            List<Category> categoryList;
            try
            {
                categoryList = _context.Set<Category>().ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return categoryList;
        }

        

        public List<Product> GetProducts()
        {
            List<Product> productsList;
            try
            {
                productsList = _context.Set<Product>().ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return productsList;
        }

        public void Update(object model)
        {
            try
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
