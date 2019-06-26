using System;
using System.Collections.Generic;
using System.Linq;
using WebApiVU.Helpers;
using WebApiVU.Models;

namespace WebApiVU.Services
{
    public class ProductsService
    {
        private DataContext _context;

        public ProductsService(DataContext context)
        {
            _context = context;
        }


        public Product AddProduct(Product model)
        {
            try
            {
                var result = _context.Add(model);
                _context.SaveChanges();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Nie udalo sie dodac produkt do bazy: " + ex.Message);
            }
        }

        public Product UpdateProduct(Product model)
        {
            try
            {
                var result = _context.Update(model);
                _context.SaveChanges();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Nie udalo sie aktualizować produkt: " + ex.Message);
            }
        }

        public Product GetById(long id)
        {
            try
            {
                var result = _context.Product.FirstOrDefault(x => x.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Nie udalo sie pobrac produkt z bazy: " + ex.Message);
            }
        }

        public IEnumerable<Product> GetList()
        {
            try
            {
                var result = _context.Product.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Nie udalo sie pobrac listy produktow z bazy: " + ex.Message);
            }
        }

        public void Detele(long id)
        {
            try
            {
                var result = _context.Product.FirstOrDefault(x => x.Id == id);
                var qa = _context.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Nie udalo sie usunac produkt z bazy: " + ex.Message);
            }
        }
    }
}
