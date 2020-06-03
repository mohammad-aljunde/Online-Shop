using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Repositories
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> List();
        public IEnumerable<Order> Search(string term);
        public Order FindById(int id);
        public void Add(Order productTypes);
        public void Update(Order productTypes);
        public void Delete(Order productTypes);
        public void DeleteById(int id);
    }
}
