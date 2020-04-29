using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Contracts
{
    public interface IBusinessTypeRepository : IRepositoryBase<BusinessType>
    {
        Task<ICollection<BusinessType>> GetAllBusinessTypesAsync();
        ICollection<BusinessType> GetAllBusinessTypes();
        BusinessType GetBusinessTypeByBusinessTypeName(string businessType);
    }
}
