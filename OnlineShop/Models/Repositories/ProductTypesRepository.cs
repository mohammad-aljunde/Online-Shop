using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Repositories
{
    public class ProductTypesRepository : IProductTypesRepository
    {
        private readonly AppDbContext db;

        public ProductTypesRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Add(ProductTypes productTypes)
        {
           
            db.ProductTypes.Add(productTypes);
            db.SaveChanges();
            
        }

        public void Delete(ProductTypes productTypes)
        {
            db.ProductTypes.Remove(productTypes);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var pro = db.ProductTypes.Find(id);
            db.ProductTypes.Remove(pro);
            db.SaveChanges();
        }

        public ProductTypes FindById(int id)
        {
            return db.ProductTypes.Find(id);
        }

        public IEnumerable<ProductTypes> List()
        {
            return db.ProductTypes.ToList();
        }

        public IEnumerable<ProductTypes> Search(string term)
        {
            return db.ProductTypes.Where(p => p.ProductType.Contains(term));
        }

        public void Update(ProductTypes productTypes)
        {
            db.ProductTypes.Update(productTypes);
            db.SaveChanges();
        }
    }
}
