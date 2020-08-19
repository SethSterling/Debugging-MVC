using AspnetCoreWithBugs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreWithBugs
{
    public static class ProductDB
    {
        public static async Task<List<Product>> GetAllProductsAsync(ProductContext _context)
        {
            return await _context.Product.ToListAsync();
        }

        public static async Task<Product> AddAsync(ProductContext _context, Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public static async Task<Product> EditAsync(ProductContext _context, Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public static async Task<Product> DeleteAsync(ProductContext _context, Product product)
        {
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public static async Task<Product> SelectedProduct(ProductContext _context, int id)
        {
           return await _context.Product
                .FirstOrDefaultAsync(m => m.ProductId == id);
        }
    }
}
