using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Models;
using static PawentsOneStopShop.Models.PetOwner;

namespace PawentsOneStopShop.Contracts
{
    public interface IRepositoryWrapper
    {
		IAddressRepository Address { get; }
		IAdoptableRepository Adoptable { get; }
		IBusinessTypeRepository BusinessType { get; }
		IObjectCalendarRepository ObjectCalendar { get; }
		IObjectEventRepository ObjectEvent { get; }
		IFollowRepository Follow { get; }
		IObjectInviteRepository ObjectInvite { get; }
		IMessageRepository Message { get; }
		IPetBusinessRepository PetBusiness { get; }
		IServiceRepository Service { get; }
		IPetOwnerRepository PetOwner { get; }
		IPetProfileRepository PetProfile { get; }
		IPetTypeRepository PetType { get; }
		IServiceOfferedRepository ServiceOffered { get; }
		IFeedUpdateRepository FeedUpdate { get; }
		INewsFeedRepository NewsFeed { get; }

		void Save();
        IEnumerable Set<T>();
		Task SaveChangesAsync();
        void Update(PetOwner petOwner);
    }
}
