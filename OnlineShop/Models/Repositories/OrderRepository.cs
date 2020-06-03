using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly AppDbContext db;

        public OrderRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Add(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public void Delete(Order productTypes)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Order FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> List()
        {
            return db.Orders.ToList();
        }

        public IEnumerable<Order> Search(string term)
        {
            throw new NotImplementedException();
        }

        public void Update(Order productTypes)
        {
            throw new NotImplementedException();
        }
    }
}
