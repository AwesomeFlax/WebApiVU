using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVU.Helpers;
using WebApiVU.Models;

namespace WebApiVU.Services
{
    public class RecipesService
    {
        private DataContext _context;
        private ProductsService ProductsService;
        private UserService UserService;

        public RecipesService(DataContext context, ProductsService productsService, UserService userService)
        {
            _context = context;
            ProductsService = productsService;
            UserService = userService;
        }

        public Recipe AddRecipe(Recipe model)
        {
            try
            {
                var prods = new List<RecipeProduct>();
                var steps = new List<RecipeStep>();

                foreach (var reqProduct in model.RequiredProducts)
                {
                    reqProduct.Product = ProductsService.GetById(reqProduct.Product.Id);
                    prods.Add(_context.Add(reqProduct).Entity);
                }
                _context.SaveChanges();

                foreach (var step in model.Steps)
                {
                    steps.Add(_context.Add(step).Entity);
                }
                _context.SaveChanges();

                model.RequiredProducts = prods;
                model.Steps = steps;
                model.RecipeAuthor = UserService.GetById(model.RecipeAuthor.Id);

                var result = _context.Add(model);
                _context.SaveChanges();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Nie udalo sie dodac przepis do bazy: " + ex.Message);
            }
        }

        public Recipe GetById(long id)
        {
            try
            {
                var result = _context.Recipes
                    .Where(x => x.Id == id)
                    .Include(x => x.Steps)
                    .Include(x => x.RequiredProducts)
                    .ThenInclude(y => y.Product)
                    .Include(x => x.RecipeAuthor)
                    .FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Nie udalo sie pobrac przepis z bazy: " + ex.Message);
            }
        }

        public Recipe UpdateRecipe(Recipe model)
        {
            try
            {
                var result = _context.Update(model);
                _context.SaveChanges();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Nie udalo sie aktualizować przepis: " + ex.Message);
            }
        }

        public void Detele(long id)
        {
            try
            {
                var result = _context.Recipes.FirstOrDefault(x => x.Id == id);
                var qa = _context.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Nie udalo sie usunac przepis z bazy: " + ex.Message);
            }
        }

        public IEnumerable<Recipe> GetList()
        {
            try
            {
                var result = _context.Recipes.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Nie udalo sie pobrac listy przepisow z bazy: " + ex.Message);
            }
        }
    }
}
