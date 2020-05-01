using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Policy;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Data;
using PawentsOneStopShop.Models;

namespace NewPetApp.Controllers
{
    [Authorize(Roles = "Pet-Friendly Business")]
    public class PetBusinessesController : Controller
    {
        private IGetCoordinatesRequest _getCoordinates;
        private IRepositoryWrapper _repo;

        public IdentityUser IdentityUser { get; private set; }

        public PetBusinessesController(IRepositoryWrapper repo, IGetCoordinatesRequest getCoordinates)
        {
            _repo = repo;
            _getCoordinates = getCoordinates;
        }

        // GET: PetBusinesses



        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var petBusiness = _repo.PetBusiness.GetPetBusinessById(userId).Id;
            var newsFeedUpdates = _repo.FeedUpdate.FindUpdatesByPetBusinessIdIncludeAll(petBusiness);

            return View(newsFeedUpdates);
        }

        public IActionResult CreateUpdate()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var petBusiness = _repo.PetBusiness.GetPetBusinessById(userId);

            FeedUpdate update = new FeedUpdate();
            update.PetBusinessId = petBusiness.Id;
            update.BusinessName = petBusiness.Name;

            return View(update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(FeedUpdate update)
        {
            FeedUpdate newUpdate = new FeedUpdate();
            DateTime dt = DateTime.Now;

            string timeStamp = dt.ToShortDateString();

            newUpdate.Description = update.Description;
            newUpdate.PubDate = timeStamp;
            newUpdate.PetBusinessId = update.PetBusinessId;
            newUpdate.BusinessName = update.BusinessName;
            _repo.FeedUpdate.Create(newUpdate);
            _repo.Save();

            return RedirectToAction(nameof(Index));

        }

        //public IActionResult EditUpdate(int id)
        //{
        //    FeedUpdate update = _repo.FeedUpdate.FindUpdateById(id);

        //    return View(update);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditUpdate(int id, FeedUpdate post)
        //{
        //    FeedUpdate update = new FeedUpdate();
        //    update.Id = id;
        //    update.PubDate = post.PubDate;
        //    News
        //}


        // GET: PetBusinesses/Details/5
        public IActionResult Details(int? id)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            PetBusiness petBusiness = _repo.PetBusiness.GetPetBusinessById(userId);
            return View(petBusiness);
        }

        // GET: PetBusinesses/Create
        public IActionResult Create()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            PetBusiness petBusiness = new PetBusiness();

            petBusiness.IdentityUserId = userId;

            ViewData["BusinessType"] = new SelectList(_repo.BusinessType.GetAllBusinessTypes(), "Id", "TypeOfBusiness", petBusiness.BusinessType);
            return View(petBusiness);
        }

        // POST: PetBusinesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PetBusiness petBusiness)
        {
            try
            {
                if (_repo.Address.GetByAddress(petBusiness.Address) == null)
                {
                    _repo.Address.CreateAddress(petBusiness.Address);
                    string url = _getCoordinates.GetAddressAsURL(petBusiness.Address);
                    petBusiness.Address.Lat = _getCoordinates.GetLat(url, petBusiness.Address).Result;
                    petBusiness.Address.Lng = _getCoordinates.GetLng(url, petBusiness.Address).Result;
                    _repo.Save();

                }
                else
                {
                    petBusiness.Address = _repo.Address.GetByAddress(petBusiness.Address);
                    string url = _getCoordinates.GetAddressAsURL(petBusiness.Address);
                    petBusiness.Address.Lat = _getCoordinates.GetLat(url, petBusiness.Address).Result;
                    petBusiness.Address.Lng = _getCoordinates.GetLng(url, petBusiness.Address).Result;
                    _repo.Save();
                }
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                //TRY MOVING THIS AFTER DELETING and UPGRADING MIGRATION MY
                _repo.PetBusiness.CreatePetBusiness(petBusiness.Name, petBusiness.BusinessTypeId, petBusiness.Address.Id, userId);
                _repo.Save();

                ObjectCalendar userCalender = new ObjectCalendar();
                userCalender.IdentityUserId = userId;
                _repo.Calendar.CreateCalendar(userCalender);
                _repo.Save();

                return RedirectToAction(nameof(Index));
            }

            catch
            {
                ViewData["BusinessType"] = new SelectList(_repo.BusinessType.GetAllBusinessTypes(), "Id", "TypeOfBusiness", petBusiness.BusinessType);
                return View(petBusiness);
            }
            
        }

        // GET: PetBusinesses/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petBusiness = _repo.PetBusiness.FindByCondition(b => b.BusinessTypeId == id);
            if (petBusiness == null)
            {
                return NotFound();
            }
            ViewData["BusinessType"] = new SelectList(_repo.BusinessType.GetAllBusinessTypes(), "Id", "TypeOfBusiness");
            return View(petBusiness);
        }

        // POST: PetBusinesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AddressId,IdentityUserId,BusinessTypeId")] PetBusiness petBusiness)
        {
            if (id != petBusiness.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.PetBusiness.Update(petBusiness);
                    await _repo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetBusinessExists(petBusiness.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusinessType"] = new SelectList(_repo.BusinessType.GetAllBusinessTypes(), "Id", "TypeOfBusiness", petBusiness.BusinessType);
            return View(petBusiness);
        }

        // GET: PetBusinesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var petBusiness = await _repo.PetBusiness.FindByCondition(b => b.BusinessTypeId == id).FirstOrDefaultAsync();
   
            if (petBusiness == null)
            {
                return NotFound();
            }

            return View(petBusiness);
        }

        // POST: PetBusinesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petBusiness = _repo.PetBusiness.FindByCondition(b => b.BusinessTypeId == id);
            _repo.PetBusiness.DeleteBusiness(petBusiness);
            await _repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DisplayServices()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            int petBusinessId = _repo.PetBusiness.GetPetBusinessById(userId).Id;
            IEnumerable<ServiceOffered> servicesOffered = await _repo.ServiceOffered.GetServicesOfferedIncludeAllAsync(petBusinessId);

            return View(servicesOffered);
        }
        public IActionResult DisplayServiceOfferedDetails(int id)
        {
            ServiceOffered serviceOffered = _repo.ServiceOffered.GetServicesOfferedIncludeAll().Where(s => s.Id == id).FirstOrDefault();
            return View(serviceOffered);
        }
        public IActionResult CreateServiceOffered()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            PetBusiness petBusiness = _repo.PetBusiness.GetPetBusinessById(userId);
            ServiceOffered serviceOffered = new ServiceOffered();

            serviceOffered.PetBusinessId = petBusiness.Id;
            //_repo.Service.GetAllServices();

            ViewData["Services"] = new SelectList(_repo.Service.GetAllServices(), "Id", "ServiceName");

            return View(serviceOffered);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateServiceOffered(ServiceOffered serviceOffered)
        {
            try
            {
                _repo.ServiceOffered.CreateServiceOffered(serviceOffered.Cost, serviceOffered.PetBusinessId, serviceOffered.ServiceId);
                _repo.Save();

                return RedirectToAction(nameof(DisplayServices));
            }
            catch
            {
                return View(serviceOffered);
            }
        }


        public IActionResult EditServiceOffered(int id)
        {
            ServiceOffered serviceOffered = _repo.ServiceOffered.FindByCondition(s => s.Id == id).FirstOrDefault();

            ViewData["Services"] = new SelectList(_repo.Service.GetAllServices(), "Id", "ServiceName");

            serviceOffered.PetBusiness = new PetBusiness();
            return View(serviceOffered);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditServiceOffered(int id, ServiceOffered serviceOffered)
        {
            ServiceOffered updatedServiceOffered = new ServiceOffered();
            updatedServiceOffered.Id = id;
            updatedServiceOffered.PetBusinessId = serviceOffered.PetBusinessId;
            updatedServiceOffered.Cost = serviceOffered.Cost;
            updatedServiceOffered.Service = _repo.Service.FindByCondition(s => s.Id == serviceOffered.ServiceId).FirstOrDefault();
            _repo.ServiceOffered.Update(updatedServiceOffered);
            _repo.Save();
            return RedirectToAction(nameof(DisplayServices));
        }
        public IActionResult DeleteServiceOffered(int id)
        {
            ServiceOffered serviceOffered = _repo.ServiceOffered.GetServicesOfferedIncludeAll(id).FirstOrDefault();
            return View(serviceOffered);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteServiceOffered(ServiceOffered serviceOffered)
        {
            ServiceOffered serviceOfferedToBeDeleted = _repo.ServiceOffered.GetServicesOfferedIncludeAll().FirstOrDefault(s => s.Id == serviceOffered.Id);
            _repo.ServiceOffered.Delete(_repo.ServiceOffered.GetServiceOffered(serviceOfferedToBeDeleted.Id));
            _repo.Save();
            return RedirectToAction(nameof(DisplayServices));

        }

        public IActionResult DisplayCalendar(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var petBusiness = _repo.PetBusiness.GetPetBusinessById(userId).Id;
            var businessCalendar = _repo.Calendar.GetCalenderByIdentityUser(userId).Id;
            var events = _repo.Event.GetEventsTiedToCalenderId(businessCalendar);

            return View(events);
        }

        public IActionResult CreateEvent()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var petBusiness = _repo.PetBusiness.GetPetBusinessById(userId).Id;
            var businessCalendar = _repo.Calendar.GetCalenderByIdentityUser(userId).Id;

            ObjectEvent newEvent = new ObjectEvent();
            newEvent.ObjectCalendarId = businessCalendar;

            return View(newEvent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEvent(ObjectEvent objectEvent)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var petBusiness = _repo.PetBusiness.GetPetBusinessById(userId).Id;
            var businessCalendar = _repo.Calendar.GetCalenderByIdentityUser(userId).Id;

            ObjectEvent newEvent = new ObjectEvent();
            newEvent.ObjectCalendarId = businessCalendar;
            newEvent.Title = objectEvent.Title;
            newEvent.Location = objectEvent.Location;
            newEvent.Details = objectEvent.Details;
            newEvent.Date = objectEvent.Date;
            newEvent.StartTime = objectEvent.StartTime;
            newEvent.EndTime = objectEvent.EndTime;

            _repo.Event.CreateEvent(newEvent);
            _repo.Save();

            return View("DisplayCalendar", businessCalendar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendPlaydate(ViewModelSendInvite invite)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var petOwnerId = _repo.PetOwner.GetPetOwnerById(userId).Id;

            ObjectCalendar objectCalendar = _repo.Calendar.GetCalenderByIdentityUser(userId);

            ObjectEvent eventCreated = new ObjectEvent();
            eventCreated.Title = invite.Title;
            eventCreated.Date = invite.Date;
            eventCreated.Details = invite.Details;
            eventCreated.StartTime = invite.StartTime;
            eventCreated.Location = invite.Location;
            eventCreated.EndTime = invite.EndTime;
            eventCreated.ObjectCalendarId = objectCalendar.Id;
            _repo.Event.CreateEvent(eventCreated);
            _repo.Save();

            ObjectEvent objectEvent = _repo.Event.GetEventByAllProperties(invite.Title, invite.Location, invite.Details, invite.Date, invite.StartTime, invite.EndTime, objectCalendar.Id);
            ObjectInvite invitation = new ObjectInvite();
            invitation.isInvitationAccepted = null;
            invitation.ObjectEventId = eventCreated.Id;
            invitation.OwnerInvitedId = invite.OwnerInvitedId;
            invitation.OwnerSendingId = petOwnerId;
            _repo.Invite.CreateInvite(invitation);
            _repo.Save();

            return RedirectToAction("DisplayNotMyPetProfileDetails", invite.PetProfileId);
        }
        public IActionResult EditEvent(int id)
        {
            ObjectEvent editedEvent = _repo.Event.FindByCondition(e => e.Id == id).FirstOrDefault();

            return View(editedEvent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEvent(int id, ObjectEvent objectEvent)
        {
            ObjectEvent newEvent = _repo.Event.FindByCondition(e => e.Id == id).FirstOrDefault();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var petBusiness = _repo.PetBusiness.GetPetBusinessById(userId).Id;
            var businessCalendar = _repo.Calendar.GetCalenderByIdentityUser(userId).Id;

            newEvent.ObjectCalendarId = businessCalendar;
            newEvent.Title = objectEvent.Title;
            newEvent.Location = objectEvent.Location;
            newEvent.Details = objectEvent.Details;
            newEvent.Date = objectEvent.Date;
            newEvent.StartTime = objectEvent.StartTime;
            newEvent.EndTime = objectEvent.EndTime;

            _repo.Event.Update(newEvent);
            _repo.Save();

            return View("DisplayCalendar", businessCalendar);
        }

        public IActionResult DeleteEvent(int id)
        {
            ObjectEvent deletingEvent = _repo.Event.FindByCondition(e => e.Id == id).FirstOrDefault();

            return View(deletingEvent);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEvent(ObjectEvent objectEvent)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var petBusiness = _repo.PetBusiness.GetPetBusinessById(userId).Id;
            var businessCalendar = _repo.Calendar.GetCalenderByIdentityUser(userId).Id;

            ObjectEvent deletingEvent = _repo.Event.FindByCondition(e => e.Id == objectEvent.Id).FirstOrDefault();
            _repo.Event.Delete(deletingEvent);
            _repo.Save();
            return View("DisplayCalendar", businessCalendar);

        }

        private bool PetBusinessExists(int id)
        {
            if(_repo.PetBusiness.FindByCondition(e => e.Id == id) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



    }
}
