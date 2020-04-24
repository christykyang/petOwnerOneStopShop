using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using petOwnerOneStopShop.Contracts;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Data
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
		public AddressRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{
		}
		public void CreateAddress(Address address) => Create(address);
		public Address GetAddressById(int? addressId)
		{
			return FindByCondition(a => a.Id == addressId).SingleOrDefault();
		}
		public async Task<Address> GetAddressByIdAsync(int? addressId)
		{
			return await FindByCondition(a => a.Id == addressId).FirstOrDefaultAsync();
		}
		public Address GetByAddress(Address address)
		{
			return FindByCondition(a => a.StreetAddress == address.StreetAddress && a.City == address.City && a.State == address.State && a.ZipCode == address.ZipCode).SingleOrDefault();
		}
		public async Task<Address> GetByAddressAsync(Address address)
		{
			return await FindByCondition(a => a.StreetAddress == address.StreetAddress && a.City == address.City && a.State == address.State && a.ZipCode == address.ZipCode).FirstOrDefaultAsync();
		}
		public ICollection<Address> GetAllAddresses()
		{
			return FindAll().ToList();
		}
		public Address GetAddressByFullAddress(string streetAddress, string city, string state, string zipcode)
		{
			return FindByCondition(a => a.StreetAddress == streetAddress && a.City == city && a.State == state && a.ZipCode == zipcode).FirstOrDefault();
		}
	}
}
