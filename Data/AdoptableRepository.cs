using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Data
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
