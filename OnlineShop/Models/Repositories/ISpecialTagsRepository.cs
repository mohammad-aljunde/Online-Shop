using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Repositories
{
    public interface ISpecialTagsRepository
    {
        public IEnumerable<SpecialTags> List();
        public SpecialTags FindById(int id);
        public void Add(SpecialTags specialTags);
        public void Update(SpecialTags specialTags);
        public void Delete(SpecialTags specialTags);
        public void DeleteById(int id);
        
    }
}
