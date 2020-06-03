using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Repositories
{
    public interface IProductTypesRepository
    {
        public IEnumerable<ProductTypes> List();
        public IEnumerable<ProductTypes> Search(string term);
        public ProductTypes FindById(int id);
        public void Add(ProductTypes productTypes);
        public void Update(ProductTypes productTypes);
        public void Delete(ProductTypes productTypes);
        public void DeleteById(int id);
        
    }
}
