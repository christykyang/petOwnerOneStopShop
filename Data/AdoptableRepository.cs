using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Contracts;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Data
{
    public class AdoptableRepository : RepositoryBase<Adoptable>, IAdoptableRepository
    {
        public AdoptableRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public void CreateAdoptable(Adoptable adoptable) => Create(adoptable);
    }
}
