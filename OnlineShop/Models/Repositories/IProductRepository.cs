using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Repositories
{
    public interface IProductRepository
    {
        public IEnumerable<Product> List();
        public IEnumerable<Product> Search(string term);
        public Product FindById(int id);
        public void Add(Product product);
        public void Update(Product product);
        public void Delete(Product product);
        public void DeleteById(int id);
        public Product SearchByName(Product product);
    }
}
