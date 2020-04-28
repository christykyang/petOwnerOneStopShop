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

            IQueryable<FeedUpdate> allUpdates = new FeedUpdate[] { }.AsQueryable();

            foreach (var follow in follows)
            {
                foreach (var business in petBusinesses)
                {
                    if(follow.PetBusinessId == business.Id)
                    {
                        var updates = _repo.FeedUpdate.FindByCondition(u => u.PetBusinessId == business.Id);
                        allUpdates.Concat(updates);
                    }
                }
            }

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

        // GET: PetOwners/Create
        //public IActionResult Create()
        //{
        //    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    PetOwner petOwner = new PetOwner();

        //    petOwner.IdentityUserId = userId;
        //    return View(petOwner);
        //}

        //// POST: PetOwners/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create([Bind("Id,Name")] PetOwner petOwner)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (_repo.Address.GetByAddress(petOwner.Address) == null)
        //        {
        //            _repo.Address.CreateAddress(petOwner.Address);
        //            string url = _getCoordinates.GetAddressAsURL(petOwner.Address);
        //            petOwner.Address.Lat = _getCoordinates.GetLat(url, petOwner.Address).Result;
        //            petOwner.Address.Lng = _getCoordinates.GetLng(url, petOwner.Address).Result;
        //            _repo.Save();

        //        }
        //        else
        //        {
        //            petOwner.Address = _repo.Address.GetByAddress(petOwner.Address);
        //            string url = _getCoordinates.GetAddressAsURL(petOwner.Address);
        //            petOwner.Address.Lat = _getCoordinates.GetLat(url, petOwner.Address).Result;
        //            petOwner.Address.Lng = _getCoordinates.GetLng(url, petOwner.Address).Result;
        //            _repo.Save();
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(petOwner);
        //}

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

        public async Task<IActionResult> SearchPetBusinesses()
        {
            ViewModelServiceOffered viewModel = new ViewModelServiceOffered();

            var businesses = await _repo.PetBusiness.GetBusinessesIncludeAllAsync();
            IEnumerable<PetBusiness> petBusinesses = businesses.ToList();
            var services = await _repo.ServiceOffered.GetServicesOfferedIncludeAllAsync();
            IEnumerable<ServiceOffered> servicesOffered = services.ToList();

            viewModel.PetBusinesses = _repo.PetBusiness.FindAll().ToList();
            viewModel.PetBusinesses.Insert(0, (new PetBusiness()));
            viewModel.ServicesOffered = servicesOffered.ToList();
            viewModel.BusinessTypes = _repo.BusinessType.GetAllBusinessTypes().ToList();
            viewModel.BusinessTypes.Insert(0, new BusinessType());
            viewModel.Addresses = _repo.Address.GetAllAddresses().ToList();
            viewModel.Addresses.Insert(0, new Address());
            viewModel.Services = _repo.Service.GetAllServices().ToList();
            viewModel.Services.Insert(0, new Service());

            return View(viewModel);
        }

        public async Task<IActionResult> FilteredPetBusinessSearch(ViewModelServiceOffered searchResults)
        {
            ViewModelServiceOffered viewModel = new ViewModelServiceOffered();

            var businesses = await _repo.PetBusiness.GetBusinessesIncludeAllAsync();
            IEnumerable<PetBusiness> petBusinesses = businesses.ToList();
            var services = await _repo.ServiceOffered.GetServicesOfferedIncludeAllAsync();
            IEnumerable<ServiceOffered> servicesOffered = services.ToList();

            if (searchResults.BusinessTypeId != 0)
            {
                petBusinesses = petBusinesses.Where(bt => bt.BusinessTypeId == searchResults.BusinessTypeId);
            }
            if (searchResults.AddressId != 0)
            {
                petBusinesses = petBusinesses.Where(bt => bt.BusinessTypeId == searchResults.AddressId);
            }
            if (searchResults.ServiceId != 0)
            {
                servicesOffered = servicesOffered.Where(s => s.ServiceId == searchResults.ServiceId);
            }

            try
            {
                if (double.Parse(searchResults.Cost) != 0)
                {
                    servicesOffered = servicesOffered.Where(s => double.Parse(s.Cost) <= double.Parse(searchResults.Cost));
                }
            }
            catch
            {

            }
            viewModel.PetBusinesses = _repo.PetBusiness.FindAll().ToList();
            viewModel.PetBusinesses.Insert(0, (new PetBusiness()));
            viewModel.ServicesOffered = servicesOffered.ToList();
            viewModel.BusinessTypes = _repo.BusinessType.GetAllBusinessTypes().ToList();
            viewModel.BusinessTypes.Insert(0, new BusinessType());
            viewModel.Addresses = _repo.Address.GetAllAddresses().ToList();
            viewModel.Addresses.Insert(0, new Address());
            viewModel.Services = _repo.Service.GetAllServices().ToList();
            viewModel.Services.Insert(0, new Service());
            return View("DisplayPetBusinesses", viewModel);
        }

        public IActionResult DisplayPetBusinessDetails(int id)
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var petOwnerId = _repo.PetOwner.GetPetOwnerById(userId).Id;

            PetBusiness petBusiness = _repo.PetBusiness.GetPetBusiness(id);

            ViewModelPetBusiness petBusinessViewing = new ViewModelPetBusiness();
            petBusinessViewing.PetBusinessId = id;
            petBusinessViewing.PetOwnerId = petOwnerId;
            petBusinessViewing.Name = petBusiness.Name;
            petBusinessViewing.BusinessTypeId = petBusiness.BusinessTypeId;
            petBusinessViewing.Address = petBusiness.Address;

            return View(petBusinessViewing);
        }

        //public IActionResult ToggleFollowAndUnfollow(int? followId, int petBusinessId, int petOwnerId)
        //{
        //    Follow follow = _repo.Follow.FindByCondition(f => f.Id == followId).FirstOrDefault();
        //    if (followId >= 0 && _repo.Follow.FindByCondition(f => f.PetOwnerId == petOwnerId && f.PetBusinessId == petBusinessId && f.IsFollowing == true).Any())
        //    {
        //        _repo.Follow.Unfollow(followId, petBusinessId, petOwnerId);
        //        _repo.Save();
        //    }
        //    else if (followId >= 0 && _repo.Follow.FindByCondition(f => f.PetOwnerId == petOwnerId && f.PetBusinessId == petBusinessId && f.IsFollowing == false).Any())
        //    {
        //        _repo.Follow.Follow(followId, petBusinessId, petBusinessId);
        //        _repo.Save();
        //    }
        //    else
        //    {
        //        CreateFollow(petBusinessId, petOwnerId);
        //    }
        //    return RedirectToAction(nameof(DisplayPetBusinessDetails));
        //}

        public IActionResult CreateFollow(int petBusinessId, int petOwnerId)
        {
            Follow follow = _repo.Follow.GetFollowByPetOwnerAndPetBusiness(petBusinessId, petOwnerId);

            if(follow == null)
            {
                Follow newFollow = new Follow();
                newFollow.PetBusinessId = petBusinessId;
                newFollow.PetOwnerId = petOwnerId;

                Dictionary<int, string> following = CreateNullableBoolDictionary("N/A", "Following", "Not Following");
                ViewData["Follow Status"] = new SelectList(following, "Key", "Value");

                follow = newFollow;
            }
            else
            {
                Dictionary<int, string> following = CreateNullableBoolDictionary("N/A", "Following", "Not Following");
                ViewData["Follow Status"] = new SelectList(following, "Key", "Value");
            }

            return View(follow);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFollow(int followId, int petBusinessId, int petOwnerId, PetBusiness petBusiness, PetOwner petOwner)
        {
            Follow following = new Follow();

            if (petBusinessId == petBusiness.Id && petOwnerId == petOwner.Id)
            {
                following.PetOwnerId = petOwner.Id;
                following.PetBusinessId = petBusiness.Id;
                following.IsFollowing = true;
                _repo.Follow.CreateFollow(following);
                _repo.Save();
                return RedirectToAction(nameof(DisplayPetBusinessDetails));
            }
            else
            {
                following.PetOwnerId = petOwner.Id;
                following.PetBusinessId = petBusiness.Id;
                following.IsFollowing = true;
                _repo.Follow.Update(following);
                _repo.Save();
                return RedirectToAction(nameof(DisplayPetBusinessDetails));
            }


        }

        public IActionResult PetBusinessNewsFeed(int petBusinessId)
        {
            var newsFeedUpdates = _repo.FeedUpdate.FindUpdatesByPetBusinessIdIncludeAll(petBusinessId);

            return View(newsFeedUpdates);
        }

        public IActionResult Unfollow(int id)
        {
            Follow follow = _repo.Follow.FindByCondition(f => f.Id == id).FirstOrDefault();

            Dictionary<int, string> following = CreateNullableBoolDictionary("N/A", "Following", "Not Following");
            ViewData["FollowStatus"] = new SelectList(following, "Key", "Value");

            return View(follow);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Unfollow(int id, PetBusiness petBusiness, PetOwner petOwner)
        {
            Follow following = _repo.Follow.FindByCondition(f => f.Id == id).FirstOrDefault();
            following.PetBusinessId = petBusiness.Id;
            following.PetOwnerId = petOwner.Id;
            following.IsFollowing = false;
            _repo.Follow.Update(following);
            _repo.Save();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SearchPetProfiles()
        {
            ViewModelPetProfile viewModel = new ViewModelPetProfile();

            var pets = await _repo.PetProfile.GetPetIncludeAll();
            IEnumerable<PetProfile> petProfiles = pets.ToList();

            viewModel.PetProfiles = _repo.PetProfile.FindAll().ToList();
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

            viewModel.PetProfiles = _repo.PetProfile.FindAll().ToList();
            viewModel.PetProfiles.Insert(0, (new PetProfile()));
            viewModel.PetTypes = _repo.PetType.GetAllPetTypes().ToList();
            viewModel.PetTypes.Insert(0, new PetType());
            viewModel.GenderOptions = new Dictionary<int, string>() { { 0, "" }, { 1, "N/A" }, { 2, "Male" }, { 3, "Female" } };
            viewModel.Adoption = new Dictionary<int, string>() { { 0, "" }, { 1, "N/A" }, { 2, "Adopted" }, { 3, "Avaliable" } };
            return View("SearchPetProfiles", viewModel);
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

