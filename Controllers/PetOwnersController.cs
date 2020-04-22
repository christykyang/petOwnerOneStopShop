﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        public IdentityUser IdentityUser { get; private set; }

        public PetOwnersController(IRepositoryWrapper repo, IGetCoordinatesRequest getCoordinates)
        {
            _repo = repo;
            _getCoordinates = getCoordinates;
        }

        // GET: PetOwners
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applicationDbContext = _repo.PetOwner.FindByCondition(o => o.IdentityUserId == userId);
            return View(await applicationDbContext.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Id,Name")] PetOwner petOwner)
        {
            if (ModelState.IsValid)
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
                return RedirectToAction(nameof(Index));
            }
            
            return View(petOwner);
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

        public IActionResult DisplayPetProfiles()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            int petOwnerId = _repo.PetOwner.GetPetOwnerById(userId).Id;
            var petProfiles = _repo.PetProfile.GetPetsTiedToOwner(petOwnerId);
            return View(petProfiles);
        }

        public IActionResult CreatePetProfile()
        {
            PetProfile petProfile = new PetProfile();
            _repo.PetType.GetAllPetTypes();

            ViewData["PetType"] = new SelectList(_repo.PetType.GetAllPetTypes(), "Id", "TypeName");
            return View(petProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePetProfile(PetProfile petProfile)
        {
            try
            {
                //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _repo.PetProfile.CreatePetProfile(petProfile.PetOwner, petProfile.PetType, petProfile.Name, petProfile.Age, petProfile.IsMale, petProfile.IsAdopted);
                _repo.Save();

                return RedirectToAction(nameof(DisplayPetProfiles));
            }
            catch
            {
                return View(petProfile);
            }
        }

        public IActionResult EditPetProfile(int id)
        {
            PetProfile petProfile = _repo.PetProfile.FindByCondition(p => p.Id == id).FirstOrDefault();
            ViewData["PetType"] = new SelectList(_repo.PetType.GetAllPetTypes(), "Id", "TypeName");
            petProfile.PetOwner = new PetOwner();
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

        public async Task<IActionResult> FilteredSearch(ViewModelServiceOffered searchResults)
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

        public IActionResult Follow(int petBusinessId, int petOwnerId)
        {
            Follow follow = new Follow();
            follow.PetBusinessId = petBusinessId;
            follow.PetOwnerId = petOwnerId;

            return View(follow);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Follow(int petBusinessId, int petOwnerId, PetBusiness petBusiness, PetOwner petOwner)
        {
            Follow following = new Follow();

            if (petBusinessId == petBusiness.Id && petOwnerId == petOwner.Id)
            {
                following.PetOwnerId = petOwner.Id;
                following.PetBusinessId = petBusiness.Id;
                following.IsFollowing = true;
                _repo.Follow.CreateFollow(following);
                _repo.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                following.PetOwnerId = petOwner.Id;
                following.PetBusinessId = petBusiness.Id;
                following.IsFollowing = true;
                _repo.Follow.Update(following);
                _repo.Save();
                return RedirectToAction(nameof(Index));
            }

            
        }

        public IActionResult Unfollow(int id)
        {
            Follow follow = _repo.Follow.FindByCondition(f => f.Id == id).FirstOrDefault();
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
    }
}
