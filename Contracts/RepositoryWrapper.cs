using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Data;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Contracts
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _context;
        private IAddressRepository _address;
        private IAdoptableRepository _adoptable;
        private IBusinessTypeRepository _businessType;
        private ICalendarRepository _calendarRepo;
        private ICalendarRequest _calendarReq;
        private IEventRepository _event;
		private IFeedUpdateRepository _feedUpdate;
		private IFollowRepository _follow;
		private IGetCoordinatesRequest _getCoordinatesReq;
		private IInviteRepository _invite;
		private IMessageRepository _message;
		private IPetBusinessRepository _petBusiness;
		private IPetOwnerRepository _petOwner;
		private IPetProfileRepository _pet;
		private IPetTypeRepository _petType;
		private IServiceOfferedRepository _serviceOffered;
		private IServiceRepository _service;

		public RepositoryWrapper(ApplicationDbContext context)
		{
			_context = context;
		}
		public IAddressRepository Address
		{
			get
			{
				if (_address == null)
				{
					_address = new AddressRepository(_context);
				}
				return _address;
			}
		}
		public IAdoptableRepository Adoptable
		{
			get
			{
				if (_adoptable == null)
				{
					_adoptable = new AdoptableRepository(_context);
				}
				return _adoptable;
			}
		}
		public IBusinessTypeRepository BusinessType
		{
			get
			{
				if (_businessType == null)
				{
					_businessType = new BusinessTypeRepository(_context);
				}
				return _businessType;
			}
		}
		public ICalendarRepository CaledarRepo
		{
			get
			{
				if (_calendarRepo == null)
				{
					_calendarRepo = new CalendarRepository(_context);
				}
				return _calendarRepo;
			}
		}
		public IEventRepository Event
		{
			get
			{
				if (_event == null)
				{
					_event = new EventRepository(_context);
				}
				return _event;
			}
		}
		public IFeedUpdateRepository FeedUpdate
		{
			get
			{
				if (_feedUpdate == null)
				{
					_feedUpdate = new FeedUpdateRepository(_context);
				}
				return _feedUpdate;
			}
		}
		public IFollowRepository Follow
		{
			get
			{
				if (_follow == null)
				{
					_follow = new FollowRepository(_context);
				}
				return _follow;
			}
		}
		public IInviteRepository Invite
		{
			get
			{
				if (_invite == null)
				{
					_invite = new InviteRepository(_context);
				}
				return _invite;
			}
		}
		public IMessageRepository Message
		{
			get
			{
				if (_message == null)
				{
					_message = new MessageRepository(_context);
				}
				return _message;
			}
		}
		public IPetBusinessRepository PetBusiness
		{
			get
			{
				if (_petBusiness == null)
				{
					_petBusiness = new PetBusinessRepository(_context);
				}
				return _petBusiness;
			}
		}
		public IPetOwnerRepository PetOwner
		{
			get
			{
				if (_petOwner == null)
				{
					_petOwner = new PetOwnerRepository(_context);
				}
				return _petOwner;
			}
		}
		public IPetProfileRepository PetProfile
		{
			get
			{
				if (_pet == null)
				{
					_pet = new PetProfileRepository(_context);
				}
				return _pet;
			}
		}
		public IPetTypeRepository PetType
		{
			get
			{
				if (_petType == null)
				{
					_petType = new PetTypeRepository(_context);
				}
				return _petType;
			}
		}
		public IServiceRepository Service
		{
			get
			{
				if (_service == null)
				{
					_service = new ServiceRepository(_context);
				}
				return _service;
			}
		}
		public IServiceOfferedRepository ServiceOffered
		{
			get
			{
				if (_serviceOffered == null)
				{
					_serviceOffered = new ServiceOfferedRepository(_context);
				}
				return _serviceOffered;
			}
		}

		public ICalendarRepository Calendar => throw new NotImplementedException();

		public void Save()
		{
			_context.SaveChanges();
		}

		public Task SaveChangesAsync()
		{
			throw new NotImplementedException();
		}

		public IEnumerable Set<T>()
		{
			throw new NotImplementedException();
		}

		public void Update(PetOwner petOwner)
		{
			throw new NotImplementedException();
		}
	}
}
