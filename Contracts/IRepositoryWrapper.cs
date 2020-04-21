using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Contracts
{
    public interface IRepositoryWrapper
    {
		IAddressRepository Address { get; }
		IAdoptableRepository Adoptable { get; }
		IBusinessTypeRepository BusinessType { get; }
		ICalendarRepository Calendar { get; }
		IEventRepository Event { get; }
		IFollowRepository Follow { get; }
		IInviteRepository Invite { get; }
		IMessageRepository Message { get; }
		IPetBusinessRepository PetBusiness { get; }
		IServiceRepository Service { get; }
		IPetOwnerRepository PetOwner { get; }
		IPetProfileRepository PetProfile { get; }
		IPetTypeRepository PetType { get; }
		IServiceOfferedRepository ServiceOffered { get; }

		void Save();
        IEnumerable Set<T>();
		Task SaveChangesAsync();
        void Update(PetOwner petOwner);
    }
}
