using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Data
{
    public class BusinessTypeRepository : RepositoryBase<BusinessType>, IBusinessTypeRepository
    {
        public BusinessTypeRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public async Task<ICollection<BusinessType>> GetAllBusinessTypesAsync()
        {
            return await FindAll().ToListAsync();
        }
        public ICollection<BusinessType> GetAllBusinessTypes()
        {
            return FindAll().ToList();
        }
        public BusinessType GetBusinessTypeByBusinessTypeName(string businessType)
        {
            return FindByCondition(t => t.TypeOfBusiness == businessType).FirstOrDefault();
        }
    }
}
