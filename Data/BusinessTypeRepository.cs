using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Contracts;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Data
{
    public class BusinessTypeRepository : RepositoryBase<BusinessType>, IBusinessTypeRepository
    {
        public BusinessTypeRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public ICollection<BusinessType> GetAllBusinessTypes()
        {
            return FindAll().ToList();
        }
    }
}
