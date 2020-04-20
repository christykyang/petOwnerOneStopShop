using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Contracts;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Data
{
    public class PetTypeRepository : RepositoryBase<PetType>, IPetTypeRepository
    {
        public PetTypeRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public ICollection<PetType> GetAllPetTypes()
        {
            return FindAll().ToList();
        }
    }
}
