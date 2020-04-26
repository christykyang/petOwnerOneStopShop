using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Contracts
{
    public interface IAddressRepository : IRepositoryBase<Address>
    {
        void CreateAddress(Address address);
        Address GetByAddress(Address address);
        Address GetAddressById(int? addressId);
        Task<Address> GetAddressByIdAsync(int? addressId);
        Task<Address> GetByAddressAsync(Address address);
        ICollection<Address> GetAllAddresses();
    }
}
