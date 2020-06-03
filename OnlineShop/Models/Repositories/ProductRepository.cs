using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly AppDbContext db;

        public ProductRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Add(Product product)
        {

            db.Products.Add(product);
            db.SaveChanges();

        }

        public void Delete(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var pro = db.Products.Find(id);
            db.Products.Remove(pro);
            db.SaveChanges();
        }

        public Product FindById(int id)
        {
            return db.Products.Include(x => x.ProductTypes).Include(x => x.SpecialTags).Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Product> List()
        {
            return db.Products.Include(x => x.ProductTypes).Include(x => x.SpecialTags).ToList();
        }

        public IEnumerable<Product> Search(string term)
        {
            return db.Products.Where(p => p.Name.Contains(term));
        }

        public Product SearchByName(Product product)
        {
            return db.Products.FirstOrDefault(p => p.Name == product.Name);
        }

        public void Update(Product product)
        {
            db.Products.Update(product);
            db.SaveChanges();
        }
    }
}
