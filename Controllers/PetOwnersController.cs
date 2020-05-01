using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Cache;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Data;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Controllers
{
    [Authorize(Roles = "Pet Owner")]
    public class PetOwnersController : Controller
    {
        private IGetCoordinatesRequest _getCoordinates;
        private IRepositoryWrapper _repo;
        private readonly IWebHostEnvironment webHostEnvironment;

        public IdentityUser IdentityUser { get; private set; }

        public PetOwnersController(IRepositoryWrapper repo, IGetCoordinatesRequest getCoordinates, IWebHostEnvironment hostEnvironment)
        {
            _repo = repo;
            _getCoordinates = getCoordinates;
            webHostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var petOwner = _repo.PetOwner.GetPetOwnerById(userId).Id;

            var follows = _repo.Follow.GetAllFollowsEqualTrueByPetOwnerIncludeAll(petOwner);

            var petBusinesses = _repo.PetBusiness.FindAll();

            
            List<FeedUpdate> feedUpdates = new List<FeedUpdate>();

            foreach (var follow in follows)
            {
                foreach (var business in petBusinesses)
                {
                    if(follow.PetBusinessId == business.Id)
                    {
                        var updates = _repo.FeedUpdate.FindUpdatesByPetBusinessIdIncludeAll(business.Id);
                        foreach (var update in updates)
                        {
                            feedUpdates.Add(update);
                        }
                    }
                }
            }
            IEnumerable<FeedUpdate> allUpdates = feedUpdates.ToList();

            return View(allUpdates);
        }

        // GET: PetOwners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petOwner = await _repo.PetOwner.FindByCondition(o => o.Id == id)
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (petOwner == null)
            {
                return NotFound();
            }

            return View(petOwner);
        }

        public IActionResult Create()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            PetOwner petOwner = new PetOwner();

            petOwner.IdentityUserId = userId;
            return View(petOwner);
        }

        // POST: PetOwners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PetOwner petOwner)
        {
            try
            {
                if (_repo.Address.GetByAddress(petOwner.Address) == null)
                {
                    _repo.Address.CreateAddress(petOwner.Address);
                    string url = _getCoordinates.GetAddressAsURL(petOwner.Address);
                    petOwner.Address.Lat = _getCoordinates.GetLat(url, petOwner.Address).Result;
                    petOwner.Address.Lng = _getCoordinates.GetLng(url, petOwner.Address).Result;
                    _repo.Save();

                }
                else
                {
                    petOwner.Address = _repo.Address.GetByAddress(petOwner.Address);
                    string url = _getCoordinates.GetAddressAsURL(petOwner.Address);
                    petOwner.Address.Lat = _getCoordinates.GetLat(url, petOwner.Address).Result;
                    petOwner.Address.Lng = _getCoordinates.GetLng(url, petOwner.Address).Result;
                    _repo.Save();
                }
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                ObjectCalendar userCalender = new ObjectCalendar();
                userCalender.IdentityUserId = userId;
                _repo.ObjectCalendar.CreateCalendar(userCalender);
                _repo.Save();

                //TRY MOVING THIS AFTER DELETING and UPGRADING MIGRATION MY
                _repo.PetOwner.CreatePetOwner(petOwner.Name, petOwner.Address.Id, userId);
                _repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(petOwner);
            }
        }

        // GET: PetOwners/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petOwner = _repo.PetOwner.FindByCondition((System.Linq.Expressions.Expression<Func<PetOwner, bool>>)(o => o.Id == id));
            if (petOwner == null)
            {
                return NotFound();
            }
            return View(petOwner);
        }

        // POST: PetOwners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PetOwner petOwner)
        {
            if (id != petOwner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(petOwner);
                    await _repo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetOwnerExists(petOwner.Id))
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
            return View(petOwner);
        }

        // GET: PetOwners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petOwner = await _repo.PetOwner.FindByCondition(o => o.Id == id)
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync();
            if (petOwner == null)
            {
                return NotFound();
            }

            return View(petOwner);
        }

        // POST: PetOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var petOwner = _repo.PetOwner.GetPetOwner(id);
            _repo.PetOwner.Remove(petOwner);
            _repo.Save();
            return RedirectToAction(nameof(Index));
        }

        //NOT WORKING
        public async Task<IActionResult> DisplayPetProfiles()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var petOwnerId = _repo.PetOwner.GetPetOwnerById(userId).Id;
            IEnumerable<PetProfile> petProfiles = await _repo.PetProfile.GetPetsByOwnerIdAndIncludeAll(petOwnerId);

            return View(petProfiles);
        }

        public IActionResult DisplayMyPetProfileDetails(int id)
        {
            //PetProfile pet = _repo.PetProfile.GetPetAndIncludeAll().Where(p => p.Id == id).FirstOrDefault();

            PetProfile petProfile = _repo.PetProfile.GetPetByIdIncludeAll(id);

            ViewModelPetProfile petProfileViewing = new ViewModelPetProfile();
            petProfileViewing.PetProfileId = id;
            petProfileViewing.Name = petProfile.Name;
            petProfileViewing.Age = petProfile.Age;

            ViewData["PetType"] = new SelectList(_repo.PetType.GetAllPetTypes(), "Id", "TypeName");

            Dictionary<int, string> genderDictionary = CreateNullableBoolDictionary("N/A", "Male", "Female");
            ViewData["GenderSelection"] = new SelectList(genderDictionary, "Key", "Value");

            Dictionary<int, string> adoption = CreateNullableBoolDictionary("N/A", "Adopted", "Avaliable");
            ViewData["AdoptionStatus"] = new SelectList(adoption, "Key", "Value");


            return View(petProfileViewing);
        }

        public IActionResult DisplayNotMyPetProfileDetails(int id)
        {
            //PetProfile pet = _repo.PetProfile.GetPetAndIncludeAll().Where(p => p.Id == id).FirstOrDefault();

            PetProfile petProfile = _repo.PetProfile.GetPetByIdIncludeAll(id);

            ViewModelPetProfile petProfileViewing = new ViewModelPetProfile();
            petProfileViewing.PetProfileId = id;
            petProfileViewing.Name = petProfile.Name;
            petProfileViewing.Age = petProfile.Age;
            petProfileViewing.PetOwnerId = petProfile.PetOwnerId;

            ViewData["PetType"] = new SelectList(_repo.PetType.GetAllPetTypes(), "Id", "TypeName");

            Dictionary<int, string> genderDictionary = CreateNullableBoolDictionary("N/A", "Male", "Female");
            ViewData["GenderSelection"] = new SelectList(genderDictionary, "Key", "Value");

            Dictionary<int, string> adoption = CreateNullableBoolDictionary("N/A", "Adopted", "Avaliable");
            ViewData["AdoptionStatus"] = new SelectList(adoption, "Key", "Value");


            return View(petProfileViewing);
        }

        public IActionResult CreatePetProfile()
        {
            ViewModelPetProfile petProfile = new ViewModelPetProfile();

            _repo.PetType.GetAllPetTypes();
            ViewData["PetType"] = new SelectList(_repo.PetType.GetAllPetTypes(), "Id", "TypeName");

            Dictionary<int, string> genderDictionary = CreateNullableBoolDictionary("N/A", "Male", "Female");
            ViewData["GenderSelection"] = new SelectList(genderDictionary, "Key", "Value");

            Dictionary<int, string> adoption = CreateNullableBoolDictionary("N/A", "Adopted", "Avaliable");
            ViewData["AdoptionStatus"] = new SelectList(adoption, "Key", "Value");

            return View(petProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePetProfile(ViewModelPetProfile viewModel)
        {

            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var petOwnerId = _repo.PetOwner.GetPetOwnerById(userId).Id;
                string uniqueFileName = UploadedPicture(viewModel);

                PetProfile petProfile = new PetProfile
                {
                    Name = viewModel.Name,
                    Age = viewModel.Age,
                    IsMale = viewModel.IsMale,
                    IsAdopted = viewModel.IsAdopted,
                    PetOwnerId = petOwnerId,
                    PetTypeId = viewModel.PetTypeId,
                    ProfilePicture = uniqueFileName,
                };

                _repo.PetProfile.CreatePetProfile(petOwnerId, petProfile.PetTypeId, petProfile.Name, petProfile.Age, petProfile.IsMale, petProfile.IsAdopted, uniqueFileName);
                _repo.Save();

                return RedirectToAction(nameof(DisplayPetProfiles));
            }
            catch
            {
                ViewData["PetType"] = new SelectList(_repo.PetType.GetAllPetTypes(), "Id", "TypeName");
                Dictionary<int, string> genderDictionary = CreateNullableBoolDictionary("N/A", "Male", "Female");
                ViewData["GenderSelection"] = new SelectList(genderDictionary, "Key", "Value");
                Dictionary<int, string> adoption = CreateNullableBoolDictionary("N/A", "Adopted", "Avaliable");
                ViewData["AdoptionStatus"] = new SelectList(adoption, "Key", "Value");
                return View(viewModel);
            }
        }

        public IActionResult EditPetProfile(int id)
        {
            PetProfile petProfile = _repo.PetProfile.GetPetByIdIncludeAll(id);

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var petOwnerId = _repo.PetOwner.GetPetOwnerById(userId).Id;

            ViewModelPetProfile petProfileUpdating = new ViewModelPetProfile();
            petProfileUpdating.PetOwnerId = petOwnerId;
            petProfileUpdating.PetProfileId = id;
            petProfileUpdating.Name = petProfile.Name;
            petProfileUpdating.Age = petProfile.Age;

            ViewData["PetType"] = new SelectList(_repo.PetType.GetAllPetTypes(), "Id", "TypeName");

            Dictionary<int, string> genderDictionary = CreateNullableBoolDictionary("N/A", "Male", "Female");
            ViewData["GenderSelection"] = new SelectList(genderDictionary, "Key", "Value");

            Dictionary<int, string> adoption = CreateNullableBoolDictionary("N/A", "Adopted", "Avaliable");
            ViewData["AdoptionStatus"] = new SelectList(adoption, "Key", "Value");

            //petProfile.PetOwner = new PetOwner();
            return View(petProfileUpdating);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPetProfile(int id, ViewModelPetProfile viewModel)
        {

            string uniqueFileName = UploadedPicture(viewModel);

            PetProfile petProfile = _repo.PetProfile.FindByCondition(p => p.Id == id).FirstOrDefault();
            petProfile.Name = viewModel.Name;
            petProfile.Age = viewModel.Age;
            petProfile.IsMale = viewModel.IsMale;
            petProfile.IsAdopted = viewModel.IsAdopted;
            petProfile.PetOwnerId = viewModel.PetOwnerId;
            petProfile.PetTypeId = viewModel.PetTypeId;
            petProfile.ProfilePicture = uniqueFileName;

            _repo.PetProfile.Update(petProfile);
            _repo.Save();
            return RedirectToAction(nameof(DisplayPetProfiles));
        }

        public IActionResult DeletePetProfile(int id)
        {
            PetProfile petProfile = _repo.PetProfile.GetPetByIdIncludeAll(id);

            ViewModelPetProfile petProfileDeleting = new ViewModelPetProfile();
            petProfileDeleting.PetProfileId = id;
            petProfileDeleting.Name = petProfile.Name;
            petProfileDeleting.Age = petProfile.Age;

            ViewData["PetType"] = new SelectList(_repo.PetType.GetAllPetTypes(), "Id", "TypeName");

            Dictionary<int, string> genderDictionary = CreateNullableBoolDictionary("N/A", "Male", "Female");
            ViewData["GenderSelection"] = new SelectList(genderDictionary, "Key", "Value");

            Dictionary<int, string> adoption = CreateNullableBoolDictionary("N/A", "Adopted", "Avaliable");
            ViewData["AdoptionStatus"] = new SelectList(adoption, "Key", "Value");

            return View(petProfileDeleting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePetProfile(ViewModelPetProfile viewModel)
        {
            //PetProfile petProfileToDelete = _repo.PetProfile.GetPetAndIncludeAll().FirstOrDefault(s => s.Id == petProfile.Id);
            //_repo.PetProfile.Delete(_repo.PetProfile.GetPetById(petProfile.Id));
            //_repo.Save();
            //return RedirectToAction(nameof(DisplayPetProfiles));

            PetProfile petProfileDeleting = _repo.PetProfile.GetPetAndIncludeAll().FirstOrDefault(s => s.Id == viewModel.PetProfileId);
            //petProfileDeleting.Id = viewModel.PetProfileId;

            _repo.PetProfile.Delete(petProfileDeleting);
            _repo.Save();
            return RedirectToAction(nameof(DisplayPetProfiles));

        }

        private string UploadedPicture(ViewModelPetProfile model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        //SearchPetBusinesses
        public async Task<IActionResult> SearchPetBusinesses()
        {
            ViewModelPetBusiness viewModel = new ViewModelPetBusiness();

            var businesses = await _repo.PetBusiness.GetBusinessesIncludeAllAsync();
            IEnumerable<PetBusiness> petBusinesses = businesses.ToList();

            viewModel.PetBusinesses = petBusinesses.ToList();
            viewModel.PetBusinesses.Insert(0, (new PetBusiness()));
            viewModel.Services = _repo.Service.GetAllServices().ToList();
            viewModel.Services.Insert(0, new Service());
            viewModel.BusinessTypes = _repo.BusinessType.GetAllBusinessTypes().ToList();
            viewModel.BusinessTypes.Insert(0, new BusinessType());
            viewModel.Addresses = _repo.Address.GetAllAddresses().ToList();
            viewModel.Addresses.Insert(0, new Address());

            return View(viewModel);
        }
        public async Task<IActionResult> FilteredPetBusinessSearch(ViewModelPetBusiness searchResults)
        {
            ViewModelPetBusiness viewModel = new ViewModelPetBusiness();

            var businesses = await _repo.PetBusiness.GetBusinessesIncludeAllAsync();
            IEnumerable<PetBusiness> petBusinesses = businesses.ToList();
            var services = await _repo.Service.GetAllServicesAsync();
            IEnumerable<Service> servicesList = services.ToList();
            var addresses = await _repo.Address.GetAllAddressesAsync();
            IEnumerable<Address> businessAddresses = addresses.ToList();
            var typesOfBusinesses = await _repo.BusinessType.GetAllBusinessTypesAsync();
            IEnumerable<BusinessType> businessTypes = typesOfBusinesses.ToList();

            if (searchResults.PetBusinessId != 0)
            {
                petBusinesses = petBusinesses.Where(b => b.Id == searchResults.PetBusinessId);
            }
            if (searchResults.BusinessTypeId != 0)
            {
                petBusinesses = petBusinesses.Where(bt => bt.BusinessTypeId == searchResults.BusinessTypeId);
            }
            //if (searchResults.ServiceId != 0)
            //{
            //    servicesList = servicesList.Where(s => s.Id == searchResults.ServiceId);
            //}
            if (searchResults.AddressId != 0)
            {
                petBusinesses = petBusinesses.Where(a => a.AddressId == searchResults.AddressId);
            }

            viewModel.PetBusinesses = petBusinesses.ToList();
            viewModel.PetBusinesses.Insert(0, (new PetBusiness()));
            viewModel.Services = _repo.Service.GetAllServices().ToList();
            viewModel.Services.Insert(0, new Service());
            viewModel.BusinessTypes = _repo.BusinessType.GetAllBusinessTypes().ToList();
            viewModel.BusinessTypes.Insert(0, new BusinessType());
            viewModel.Addresses = _repo.Address.GetAllAddresses().ToList();
            viewModel.Addresses.Insert(0, new Address());

            return View("SearchPetBusinesses", viewModel);
        }

        public IActionResult DisplayPetBusinessDetails(int id)
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var petOwnerId = _repo.PetOwner.GetPetOwnerById(userId).Id;

            IEnumerable<ServiceOffered> servicesOffered =  _repo.ServiceOffered.GetServicesOfferedIncludeAll(id);

            //NEED INCLUDE ALL reference in REPO
            PetBusiness petBusiness = _repo.PetBusiness.GetPetBusiness(id);
            Address address = _repo.Address.GetAddressById(petBusiness.AddressId);
            Follow follow = _repo.Follow.GetFollowByPetOwnerAndPetBusiness(id, petOwnerId);

            if(follow == null)
            {
                Follow newFollow = new Follow();
                newFollow.PetOwnerId = petOwnerId;
                newFollow.PetBusinessId = id;
                newFollow.IsFollowing = false;
                _repo.Follow.CreateFollow(newFollow);
                _repo.Save();

                follow = newFollow;
            }

            ViewModelPetBusiness petBusinessViewing = new ViewModelPetBusiness();
            petBusinessViewing.PetBusiness = petBusiness;
            petBusinessViewing.PetBusinessId = id;
            petBusinessViewing.PetOwnerId = petOwnerId;
            petBusinessViewing.Name = petBusiness.Name;
            petBusinessViewing.BusinessTypeId = petBusiness.BusinessTypeId;
            petBusinessViewing.Address = address;
            petBusinessViewing.IsFollowing = follow.IsFollowing;
            //petBusinessViewing.Address.Lat = address.Lat;
            //petBusinessViewing.Address.Lng = address.Lng;
            petBusinessViewing.ServicesOffered = servicesOffered.ToList();

            return View(petBusinessViewing);
        }

        public IActionResult FollowAndUnfollow(int petBusinessId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var petOwnerId = _repo.PetOwner.GetPetOwnerById(userId).Id;

            Follow follow = _repo.Follow.GetFollowByPetOwnerAndPetBusiness(petBusinessId, petOwnerId);

            if (follow.IsFollowing == false)
            {
                follow.IsFollowing = true;
                _repo.Follow.Update(follow);
                _repo.Save();
                return RedirectToAction("DisplayPetBusinessDetails", new { id = petBusinessId });
            }
            else 
            {
                follow.IsFollowing = false;
                _repo.Follow.Update(follow);
                _repo.Save();

                return RedirectToAction("DisplayPetBusinessDetails", new { id = petBusinessId });
            }
        }

        //DOES NOT WORK to return to PetBusinessDetails
        public IActionResult PetBusinessNewsFeed(int petBusinessId)
        {
            var newsFeedUpdates = _repo.FeedUpdate.FindUpdatesByPetBusinessIdIncludeAll(petBusinessId);

            return View(newsFeedUpdates);
        }

        public async Task<IActionResult> SearchPetProfiles()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var petOwnerId = _repo.PetOwner.GetPetOwnerById(userId).Id;  

            ViewModelPetProfile viewModel = new ViewModelPetProfile();

            var pets = await _repo.PetProfile.GetPetIncludeAll();
            IEnumerable<PetProfile> petProfiles = pets.ToList();
            //IQueryable<PetProfile> notMyPets = new PetProfile[] { }.AsQueryable();

            //foreach (var pet in petProfiles)
            //{
            //    if(pet.PetOwnerId != petOwnerId)
            //    {
            //        var notMyPet = _repo.PetProfile.GetPetById(pet.Id);
            //        notMyPets.Concat(notMyPet);
            //    }
            //}

            //viewModel.PetProfiles = petProfiles.ToList();
            viewModel.PetProfiles = petProfiles.ToList();
            viewModel.PetProfiles.Insert(0, (new PetProfile()));
            viewModel.PetTypes = _repo.PetType.GetAllPetTypes().ToList();
            viewModel.PetTypes.Insert(0, new PetType());
            viewModel.GenderOptions = new Dictionary<int, string>() { { 0, "" }, { 1, "N/A" }, { 2, "Male" }, { 3, "Female" } };
            viewModel.Adoption = new Dictionary<int, string>() { { 0, "" }, { 1, "N/A" }, { 2, "Adopted" }, { 3, "Avaliable" } };

            return View(viewModel);
        }

        public async Task<IActionResult> FilteredThroughPetProfiles(ViewModelPetProfile searchResults)
        {
            ViewModelPetProfile viewModel = new ViewModelPetProfile();

            var pets = await _repo.PetProfile.GetPetIncludeAll();
            IEnumerable<PetProfile> petProfiles = pets.ToList();

            if (searchResults.PetTypeId != 0)
            {
                petProfiles = petProfiles.Where(bt => bt.PetTypeId == searchResults.PetTypeId);
            }
            if (searchResults.GenderSelection != 0)
            {
                switch (searchResults.GenderSelection)
                {
                    case 1:
                        petProfiles = petProfiles.Where(p => p.IsMale == null);
                        break;
                    case 2:
                        petProfiles = petProfiles.Where(p => p.IsMale == true);
                        break;
                    case 3:
                        petProfiles = petProfiles.Where(p => p.IsMale == false);
                        break;
                    default:
                        break;
                }
            }
            if (searchResults.AdoptionStatus != 0)
            {
                switch (searchResults.AdoptionStatus)
                {
                    case 1:
                        petProfiles = petProfiles.Where(p => p.IsAdopted == null);
                        break;
                    case 2:
                        petProfiles = petProfiles.Where(p => p.IsAdopted == true);
                        break;
                    case 3:
                        petProfiles = petProfiles.Where(p => p.IsAdopted == false);
                        break;
                    default:
                        break;
                }
            }

            viewModel.PetProfiles = petProfiles.ToList();
            viewModel.PetProfiles.Insert(0, (new PetProfile()));
            viewModel.PetTypes = _repo.PetType.GetAllPetTypes().ToList();
            viewModel.PetTypes.Insert(0, new PetType());
            viewModel.GenderOptions = new Dictionary<int, string>() { { 0, "" }, { 1, "N/A" }, { 2, "Male" }, { 3, "Female" } };
            viewModel.Adoption = new Dictionary<int, string>() { { 0, "" }, { 1, "N/A" }, { 2, "Adopted" }, { 3, "Avaliable" } };
            return View("SearchPetProfiles", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendPlaydate(ViewModelSendInvite invite)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var petOwnerId = _repo.PetOwner.GetPetOwnerById(userId).Id;

            ObjectCalendar objectCalendar = _repo.ObjectCalendar.GetCalenderByIdentityUser(userId);

            ObjectEvent eventCreated = new ObjectEvent();
            eventCreated.Title = invite.Title;
            eventCreated.Date = invite.Date;
            eventCreated.Details = invite.Details;
            eventCreated.StartTime = invite.StartTime;
            eventCreated.Location = invite.Location;
            eventCreated.EndTime = invite.EndTime;
            eventCreated.ObjectCalendarId = objectCalendar.Id;
            _repo.ObjectEvent.CreateEvent(eventCreated);
            _repo.Save();

            ObjectEvent objectEvent = _repo.ObjectEvent.GetEventByAllProperties(invite.Title, invite.Location, invite.Details, invite.Date, invite.StartTime, invite.EndTime, objectCalendar.Id);
            ObjectInvite invitation = new ObjectInvite();
            invitation.isInvitationAccepted = null;
            invitation.ObjectEventId = eventCreated.Id;
            invitation.OwnerInvitedId = invite.OwnerInvitedId;
            invitation.OwnerSendingId = petOwnerId;
            invitation.ObjectEventId = objectEvent.Id;
            _repo.ObjectInvite.CreateInvite(invitation);
            _repo.Save();

            return RedirectToAction("SearchPetProfiles");
        }
        public IActionResult SendPlaydate(int petOwnerId, int petProfileId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var thisPetOwnerId = _repo.PetOwner.GetPetOwnerById(userId).Id;

            ViewModelSendInvite invite = new ViewModelSendInvite();
            invite.OwnerInvitedId = petOwnerId;
            invite.OwnerSendingId = thisPetOwnerId;
            invite.PetProfileId = petProfileId;

            return View(invite);
        }

        public IActionResult DisplayInvites()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var petOwnerId = _repo.PetOwner.GetPetOwnerById(userId).Id;

            var invites = _repo.ObjectInvite.GetInvitesSentToOwner(petOwnerId);

            List<ObjectInvite> listOfInvites = new List<ObjectInvite>();

            foreach (var invite in invites)
            {
                if(invite.isInvitationAccepted == null)
                {
                    //var newInvite = _repo.ObjectInvite.FindByCondition(i => i.isInvitationAccepted == null);
                    //newInvites.Concat(newInvite);
                    listOfInvites.Add(invite);
                }
            }
            IEnumerable<ObjectInvite> newInvites = listOfInvites.ToList();

            return View(newInvites);
        }

        public IActionResult AcceptorDeclineInvite(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var petOwnerId = _repo.PetOwner.GetPetOwnerById(userId).Id;

            ObjectInvite invitation = _repo.ObjectInvite.FindByCondition(i => i.Id == id).FirstOrDefault();

            if (!invitation.isInvitationAccepted.HasValue)
            {
                invitation.isInvitationAccepted = true;
                ObjectEvent objectEvent = _repo.ObjectEvent.GetEventById(invitation.ObjectEventId);
                ObjectCalendar invitedOwnerCalendar = _repo.ObjectCalendar.GetCalenderByIdentityUser(userId);

                ObjectEvent newEvent = new ObjectEvent();
                newEvent.Title = objectEvent.Title;
                newEvent.Location = objectEvent.Location;
                newEvent.Details = objectEvent.Details;
                newEvent.Date = objectEvent.Date;
                newEvent.StartTime = objectEvent.StartTime;
                newEvent.EndTime = objectEvent.EndTime;
                newEvent.ObjectCalendarId = invitedOwnerCalendar.Id;
                _repo.ObjectEvent.CreateEvent(newEvent);
                _repo.Save();
            }
            else if (invitation.isInvitationAccepted.Value == true)
            {
                invitation.isInvitationAccepted = false;
                _repo.ObjectInvite.Update(invitation);
                _repo.Save();
            }
            else
            {
                invitation.isInvitationAccepted = null;
                _repo.ObjectInvite.Update(invitation);
                _repo.Save();
            }

            return RedirectToAction(nameof(DisplayInvites), id);
        }

        public IActionResult DisplayCalendar()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var ownerCalendar = _repo.ObjectCalendar.GetCalenderByIdentityUser(userId).Id;
            var events = _repo.ObjectEvent.GetEventsTiedToCalenderId(ownerCalendar);

            return View(events);
        }

        public IActionResult CreateEvent()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var petOwner = _repo.PetBusiness.GetPetBusinessById(userId).Id;
            var ownerCalendar = _repo.ObjectCalendar.GetCalenderByIdentityUser(userId).Id;

            ObjectEvent newEvent = new ObjectEvent();
            newEvent.ObjectCalendarId = ownerCalendar;

            return View(newEvent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEvent(ObjectEvent objectEvent)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var petOwner = _repo.PetBusiness.GetPetBusinessById(userId).Id;
            var ownerCalendar = _repo.ObjectCalendar.GetCalenderByIdentityUser(userId).Id;

            ObjectEvent newEvent = new ObjectEvent();
            newEvent.ObjectCalendarId = ownerCalendar;
            newEvent.Title = objectEvent.Title;
            newEvent.Location = objectEvent.Location;
            newEvent.Details = objectEvent.Details;
            newEvent.Date = objectEvent.Date;
            newEvent.StartTime = objectEvent.StartTime;
            newEvent.EndTime = objectEvent.EndTime;

            _repo.ObjectEvent.CreateEvent(newEvent);
            _repo.Save();

            return RedirectToAction("DisplayCalendar");
        }

        public IActionResult EditEvent(int id)
        {
            ObjectEvent editedEvent = _repo.ObjectEvent.FindByCondition(e => e.Id == id).FirstOrDefault();

            return View(editedEvent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEvent(int id, ObjectEvent objectEvent)
        {
            ObjectEvent newEvent = _repo.ObjectEvent.FindByCondition(e => e.Id == id).FirstOrDefault();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var petOwner = _repo.PetBusiness.GetPetBusinessById(userId).Id;
            var ownerCalendar = _repo.ObjectCalendar.GetCalenderByIdentityUser(userId).Id;

            newEvent.ObjectCalendarId = ownerCalendar;
            newEvent.Title = objectEvent.Title;
            newEvent.Location = objectEvent.Location;
            newEvent.Details = objectEvent.Details;
            newEvent.Date = objectEvent.Date;
            newEvent.StartTime = objectEvent.StartTime;
            newEvent.EndTime = objectEvent.EndTime;

            _repo.ObjectEvent.Update(newEvent);
            _repo.Save();

            return RedirectToAction("DisplayCalendar");
        }

        public IActionResult DeleteEvent(int id)
        {
            ObjectEvent deletingEvent = _repo.ObjectEvent.FindByCondition(e => e.Id == id).FirstOrDefault();

            return View(deletingEvent);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEvent(ObjectEvent objectEvent)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var petOwner = _repo.PetBusiness.GetPetBusinessById(userId).Id;
            var ownerCalendar = _repo.ObjectCalendar.GetCalenderByIdentityUser(userId).Id;

            ObjectEvent deletingEvent = _repo.ObjectEvent.FindByCondition(e => e.Id == objectEvent.Id).FirstOrDefault();
            _repo.ObjectEvent.Delete(deletingEvent);
            _repo.Save();

            return RedirectToAction("DisplayCalendar");
        }

        private bool PetOwnerExists(int id)
        {
            if (_repo.PetOwner.FindByCondition((System.Linq.Expressions.Expression<Func<PetOwner, bool>>)(e => e.Id == id)) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Dictionary<int, string> CreateNullableBoolDictionary(string nullValue, string trueValue, string falseValue)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>()
            {
                { 0, nullValue },
                { 1, trueValue },
                { 2, falseValue }
            };

            return dictionary;
        }
        private bool? ConvertToNullableBool(int resultFromForm)
        {
            switch (resultFromForm)
            {
                case 0:
                    return null;
                case 1:
                    return true;
                case 2:
                    return false;
            }

            return ConvertToNullableBool(resultFromForm);
        }
        private int ConvertNullableBoolToInt(bool? nullableBool)
        {
            if (!nullableBool.HasValue)
            {
                return 0;
            }
            else if (nullableBool.Value == true)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}

