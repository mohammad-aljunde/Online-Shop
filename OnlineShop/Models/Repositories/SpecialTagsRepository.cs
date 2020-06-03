using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Repositories
{
    public class SpecialTagsRepository : ISpecialTagsRepository
    {
        private readonly AppDbContext db;

        public SpecialTagsRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Add(SpecialTags specialTags)
        {
            db.SpecialTags.Add(specialTags);
            db.SaveChanges();
        }

        public void Delete(SpecialTags specialTags)
        {
            db.SpecialTags.Remove(specialTags);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var pro = db.SpecialTags.Find(id);
            db.SpecialTags.Remove(pro);
            db.SaveChanges();
        }

        public SpecialTags FindById(int id)
        {
            return db.SpecialTags.Find(id);
        }

        public IEnumerable<SpecialTags> List()
        {
            return db.SpecialTags.ToList();
        }

        public IEnumerable<SpecialTags> Search(string term)
        {
            return db.SpecialTags.Where(p => p.SpecialTag.Contains(term));
        }

        public void Update(SpecialTags specialTags)
        {
            db.SpecialTags.Update(specialTags);
            db.SaveChanges();
        }
    }
}
