using System;
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
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applicationDbContext = _repo.PetBusiness.FindByCondition(p => p.IdentityUserId == userId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PetBusinesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petBusiness = await _repo.PetBusiness.FindByCondition(p => p.Id == id)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (petBusiness == null)
            {
                return NotFound();
            }

            return View(petBusiness);
        }

        // GET: PetBusinesses/Create
        public IActionResult Create()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            PetBusiness petBusiness = new PetBusiness();

            petBusiness.IdentityUserId = userId;

            ViewData["BusinessType"] = new SelectList(_repo.Set<BusinessType>(), "Id", "TypeOfBusiness");
            return View(petBusiness);
        }

        // POST: PetBusinesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,BusinessTypeId")] PetBusiness petBusiness)
        {
            if (ModelState.IsValid)
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusinessType"] = new SelectList(_repo.Set<BusinessType>(), "Id", "TypeOfBusiness", petBusiness.BusinessType);
            return View(petBusiness);
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
            ViewData["BusinessType"] = new SelectList(_repo.Set<BusinessType>(), "Id", "TypeOfBusiness");
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
            ViewData["BusinessType"] = new SelectList(_repo.Set<BusinessType>(), "Id", "TypeOfBusiness", petBusiness.BusinessType);
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
            //var petBusiness = await _repo.PetBusiness
            //    .Include(p => p.Address)
            //    .Include(p => p.BusinessType)
            //    .Include(p => p.identityUser)
            //    .FirstOrDefaultAsync(m => m.Id == id);
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
            
            ServiceOffered serviceOffered = new ServiceOffered();
            _repo.Service.GetAllServices();

            ViewData["Services"] = new SelectList(_repo.Service.GetAllServices(), "Id", "ServiceName");

            return View(serviceOffered);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateServiceOffered(ServiceOffered serviceOffered)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _repo.ServiceOffered.CreateServiceOffered(serviceOffered.Cost, serviceOffered.PetBusiness, serviceOffered.Service);
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
            //ServiceOfferedViewModel serviceOfferedViewModel = new ServiceOfferedViewModel();
            //serviceOfferedViewModel.ServiceOfferedId = serviceOffered.Id;
            //serviceOfferedViewModel.Address = serviceOffered.Address;
            //serviceOfferedViewModel.Category = serviceOffered.Category;
            //serviceOfferedViewModel.Demographic = serviceOffered.Demographic;
            //serviceOfferedViewModel.Service = serviceOffered.Service;
            //serviceOfferedViewModel.AgeSensitive = ConvertNullableBoolToInt(serviceOffered.Demographic.IsAgeSensitive);
            //serviceOfferedViewModel.FamilySelection = ConvertNullableBoolToInt(serviceOffered.Demographic.FamilyFriendly);
            //serviceOfferedViewModel.GenderSelection = ConvertNullableBoolToInt(serviceOffered.Demographic.IsMale);
            //serviceOfferedViewModel.SmokingSelection = ConvertNullableBoolToInt(serviceOffered.Demographic.SmokingIsAllowed);
            //serviceOfferedViewModel.Cost = serviceOffered.Cost;
            //ViewData["Categories"] = new SelectList(_repo.Category.GetAllCategories(), "Id", "Name");
            //Dictionary<int, string> genderDictionary = CreateNullableBoolDictionary("Co-ed", "Male", "Female");
            //ViewData["Genders"] = new SelectList(genderDictionary, "Key", "Value");
            //Dictionary<int, string> familyFriendly = CreateNullableBoolDictionary("Not Applicable", "Family Friendly", "Individual");
            //ViewData["FamilySize"] = new SelectList(familyFriendly, "Key", "Value");
            //Dictionary<int, string> smokingAllowed = CreateNullableBoolDictionary("Not Applicable", "Smoking Allowed", "No Smoking");
            //ViewData["Smoking"] = new SelectList(smokingAllowed, "Key", "Value");
            //Dictionary<int, string> ageSensitive = CreateNullableBoolDictionary("Not Applicable", "Above 60", "18 and up");
            //ViewData["AgeSensitive"] = new SelectList(ageSensitive, "Key", "Value");
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
            updatedServiceOffered.Service = _repo.Service.FindByCondition(s => s.Id == serviceOffered.Service.Id).FirstOrDefault();
            _repo.ServiceOffered.Update(serviceOffered);
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
