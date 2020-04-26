using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Data
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
