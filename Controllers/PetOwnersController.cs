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
using petOwnerOneStopShop.Contracts;
using petOwnerOneStopShop.Data;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Controllers
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

        // GET: PetOwners
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var petOwner = _repo.PetOwner.GetPetOwnerById(userId);

            NewsFeed newsFeed = _repo.NewsFeed.GetNewsFeedByPetOwner(petOwner.Id);
            if (newsFeed == null)
            {
                NewsFeed creatingNewsFeed = new NewsFeed();
                creatingNewsFeed.PetOwnerId = petOwner.Id;
                _repo.NewsFeed.Create(creatingNewsFeed);
                _repo.Save();
                newsFeed.Id = creatingNewsFeed.Id;
            }

            var newsFeedUpdate = _repo.FeedUpdate.FindUpdatesByNewsFeedId(newsFeed.Id);
            return View(newsFeedUpdate);
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
                return RedirectToAction(nameof(Details));
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

            var petOwner = _repo.PetOwner.FindByCondition(o => o.Id == id);
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

        public async Task<IActionResult> DisplayPetProfiles()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            int petOwner = _repo.PetOwner.GetPetOwnerById(userId).Id;
            IEnumerable<PetProfile> petProfiles = await _repo.PetProfile.GetPetsByOwnerIdAndIncludeAll(petOwner);

            return View(petProfiles);
        }

        public IActionResult DisplayPetProfileDetails(int id)
        {
            PetProfile pet = _repo.PetProfile.GetPetAndIncludeAll().Where(p => p.Id == id).FirstOrDefault();
            return View(pet);
        }

        public IActionResult CreatePetProfile()
        {
            PetProfile petProfile = new PetProfile();

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
        public IActionResult CreatePetProfile(PetProfileViewModel viewModel)
        {
            try
            {
                //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                string uniqueFileName = UploadedPicture(viewModel);

                PetProfile petProfile = new PetProfile
                {
                    Name = viewModel.Name,
                    Age = viewModel.Age,
                    IsMale = viewModel.IsMale,
                    IsAdopted = viewModel.IsAdopted,
                    PetOwnerId = viewModel.PetOwnerId,
                    PetTypeId = viewModel.PetTypeId,
                    ProfilePicture = uniqueFileName,
                };

                _repo.PetProfile.CreatePetProfile(petProfile.PetOwner, petProfile.PetType, petProfile.Name, petProfile.Age, petProfile.IsMale, petProfile.IsAdopted, uniqueFileName);
                _repo.Save();

                return RedirectToAction(nameof(DisplayPetProfiles));
            }
            catch
            {
                return View(viewModel);
            }
        }

        public IActionResult EditPetProfile(int id)
        {
            PetProfile petProfile = _repo.PetProfile.FindByCondition(p => p.Id == id).FirstOrDefault();
            ViewData["PetType"] = new SelectList(_repo.PetType.GetAllPetTypes(), "Id", "TypeName");

            Dictionary<int, string> genderDictionary = CreateNullableBoolDictionary("N/A", "Male", "Female");
            ViewData["GenderSelection"] = new SelectList(genderDictionary, "Key", "Value");

            Dictionary<int, string> adoption = CreateNullableBoolDictionary("N/A", "Adopted", "Avaliable");
            ViewData["AdoptionStatus"] = new SelectList(adoption, "Key", "Value");

            //petProfile.PetOwner = new PetOwner();
            return View(petProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPetProfile(int id, PetProfile petProfile)
        {
            PetProfile updatedPetProfile = new PetProfile();
            updatedPetProfile.Id = id;
            updatedPetProfile.PetOwnerId = petProfile.PetOwnerId;
            updatedPetProfile.PetTypeId = petProfile.PetTypeId;
            updatedPetProfile.Name = petProfile.Name;
            updatedPetProfile.Age = petProfile.Age;
            updatedPetProfile.IsMale = petProfile.IsMale;
            updatedPetProfile.IsAdopted = petProfile.IsAdopted;
            _repo.PetProfile.Update(updatedPetProfile);
            _repo.Save();
            return RedirectToAction(nameof(DisplayPetProfiles));
        }

        public IActionResult DeletePetProfile(int id)
        {
            PetProfile petProfile = _repo.PetProfile.GetPetById(id);
            return View(petProfile);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePetProfile(PetProfile petProfile)
        {
            PetProfile petProfileToDelete = _repo.PetProfile.GetPetAndIncludeAll().FirstOrDefault(s => s.Id == petProfile.Id);
            _repo.PetProfile.Delete(_repo.PetProfile.GetPetById(petProfile.Id));
            _repo.Save();
            return RedirectToAction(nameof(DisplayPetProfiles));

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> New(PetProfileViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string uniqueFileName = UploadedPicture(model);

        //        PetProfile pet = new PetProfile
        //        {
        //            Name = model.Name,
        //            IsMale = model.IsMale,
        //            Age = model.Age,
        //            IsAdopted = model.IsAdopted,
        //            PetTypeId = model.PetTypeId,
        //            PetOwnerId = model.PetOwnerId,
        //            ProfilePicture = uniqueFileName,
        //        };
        //        dbContext.Add(pet);
        //        await dbContext.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View();
        //}

        private string UploadedPicture(PetProfileViewModel model)
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

        public async Task<IActionResult> DisplayPetBusinesses()
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

        public IActionResult ToggleFollowAndUnfollow(int? followId, int petBusinessId, int petOwnerId)
        {
            Follow follow = _repo.Follow.FindByCondition(f => f.Id == followId).FirstOrDefault();
            if (followId >= 0 && _repo.Follow.FindByCondition(f => f.PetOwnerId == petOwnerId && f.PetBusinessId == petBusinessId && f.IsFollowing == true).Any())
            {
                _repo.Follow.Unfollow(followId, petBusinessId, petOwnerId);
                _repo.Save();
            }
            else if (followId >= 0 && _repo.Follow.FindByCondition(f => f.PetOwnerId == petOwnerId && f.PetBusinessId == petBusinessId && f.IsFollowing == false).Any())
            {
                _repo.Follow.Follow(followId, petBusinessId, petBusinessId);
                _repo.Save();
            }
            else
            {
                CreateFollow(petBusinessId, petOwnerId);
            }
            return RedirectToAction(nameof(DisplayPetBusinesses));
        }

        public IActionResult CreateFollow(int petBusinessId, int petOwnerId)
        {
            Follow follow = new Follow();
            follow.PetBusinessId = petBusinessId;
            follow.PetOwnerId = petOwnerId;

            Dictionary<int, string> following = CreateNullableBoolDictionary("N/A", "Following", "Not Following");
            ViewData["Follow Status"] = new SelectList(following, "Key", "Value");

            return View(follow);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFollow(int petBusinessId, int petOwnerId, PetBusiness petBusiness, PetOwner petOwner)
        {
            Follow following = new Follow();

            if (petBusinessId == petBusiness.Id && petOwnerId == petOwner.Id)
            {
                following.PetOwnerId = petOwner.Id;
                following.PetBusinessId = petBusiness.Id;
                following.IsFollowing = true;
                _repo.Follow.CreateFollow(following);
                _repo.Save();
                return RedirectToAction(nameof(DisplayPetBusinesses));
            }
            else
            {
                following.PetOwnerId = petOwner.Id;
                following.PetBusinessId = petBusiness.Id;
                following.IsFollowing = true;
                _repo.Follow.Update(following);
                _repo.Save();
                return RedirectToAction(nameof(DisplayPetBusinesses));
            }


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
            ViewModelPetProfiles viewModel = new ViewModelPetProfiles();

            var pets = await _repo.PetProfile.GetPetIncludeAll();
            IEnumerable<PetProfile> petProfiles = pets.ToList();

            viewModel.PetProfiles = _repo.PetProfile.FindAll().ToList();
            viewModel.PetProfiles.Insert(0, (new PetProfile()));
            viewModel.PetTypes = _repo.PetType.GetAllPetTypes().ToList();
            viewModel.PetTypes.Insert(0, new PetType());
            viewModel.IsMale = new Dictionary<int, string>() { { 0, "" }, { 1, "N/A" }, { 2, "Male" }, { 3, "Female" } };
            viewModel.IsAdopted = new Dictionary<int, string>() { { 0, "" }, { 1, "N/A" }, { 2, "Adopted" }, { 3, "Avaliable" } };

            return View(viewModel);
        }

        public async Task<IActionResult> FilteredThroughPetProfiles(ViewModelPetProfiles searchResults)
        {
            ViewModelPetProfiles viewModel = new ViewModelPetProfiles();

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
            viewModel.IsMale = new Dictionary<int, string>() { { 0, "" }, { 1, "N/A" }, { 2, "Male" }, { 3, "Female" } };
            viewModel.IsAdopted = new Dictionary<int, string>() { { 0, "" }, { 1, "N/A" }, { 2, "Adopted" }, { 3, "Avaliable" } };
            return View("SearchPetProfiles", viewModel);
        }
        private bool PetOwnerExists(int id)
        {
            if (_repo.PetOwner.FindByCondition(e => e.Id == id) == null)
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

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using petOwnerOneStopShop.Data;
//using petOwnerOneStopShop.Models;

//namespace petOwnerOneStopShop.Controllers
//{
//    [Authorize(Roles = "Pet Owner")]
//    public class PetOwnersController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public PetOwnersController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: PetOwners
//        public async Task<IActionResult> Index()
//        {
//            var applicationDbContext = _context.PetOwner.Include(p => p.IdentityUser);
//            return View(await applicationDbContext.ToListAsync());
//        }

//        // GET: PetOwners/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var petOwner = await _context.PetOwner
//                .Include(p => p.IdentityUser)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (petOwner == null)
//            {
//                return NotFound();
//            }

//            return View(petOwner);
//        }

//        // GET: PetOwners/Create
//        public IActionResult Create()
//        {
//            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
//            return View();
//        }

//        // POST: PetOwners/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Name,IdentityUserId")] PetOwner petOwner)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(petOwner);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", petOwner.IdentityUserId);
//            return View(petOwner);
//        }

//        // GET: PetOwners/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var petOwner = await _context.PetOwner.FindAsync(id);
//            if (petOwner == null)
//            {
//                return NotFound();
//            }
//            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", petOwner.IdentityUserId);
//            return View(petOwner);
//        }

//        // POST: PetOwners/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IdentityUserId")] PetOwner petOwner)
//        {
//            if (id != petOwner.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(petOwner);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!PetOwnerExists(petOwner.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", petOwner.IdentityUserId);
//            return View(petOwner);
//        }

//        // GET: PetOwners/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var petOwner = await _context.PetOwner
//                .Include(p => p.IdentityUser)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (petOwner == null)
//            {
//                return NotFound();
//            }

//            return View(petOwner);
//        }

//        // POST: PetOwners/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var petOwner = await _context.PetOwner.FindAsync(id);
//            _context.PetOwner.Remove(petOwner);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool PetOwnerExists(int id)
//        {
//            return _context.PetOwner.Any(e => e.Id == id);
//        }
//    }
//}
