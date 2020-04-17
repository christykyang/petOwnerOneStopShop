using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using petOwnerOneStopShop.Data;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Controllers
{
    public class PetBusinessesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PetBusinessesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PetBusinesses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PetBusiness.Include(p => p.Address).Include(p => p.BusinessType).Include(p => p.identityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PetBusinesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petBusiness = await _context.PetBusiness
                .Include(p => p.Address)
                .Include(p => p.BusinessType)
                .Include(p => p.identityUser)
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
            ViewData["AddressId"] = new SelectList(_context.Set<Address>(), "Id", "City");
            ViewData["BusinessTypeId"] = new SelectList(_context.Set<BusinessType>(), "Id", "Id");
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: PetBusinesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AddressId,IdentityUserId,BusinessTypeId")] PetBusiness petBusiness)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petBusiness);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Set<Address>(), "Id", "City", petBusiness.AddressId);
            ViewData["BusinessTypeId"] = new SelectList(_context.Set<BusinessType>(), "Id", "Id", petBusiness.BusinessTypeId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", petBusiness.IdentityUserId);
            return View(petBusiness);
        }

        // GET: PetBusinesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petBusiness = await _context.PetBusiness.FindAsync(id);
            if (petBusiness == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Set<Address>(), "Id", "City", petBusiness.AddressId);
            ViewData["BusinessTypeId"] = new SelectList(_context.Set<BusinessType>(), "Id", "Id", petBusiness.BusinessTypeId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", petBusiness.IdentityUserId);
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
                    _context.Update(petBusiness);
                    await _context.SaveChangesAsync();
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
            ViewData["AddressId"] = new SelectList(_context.Set<Address>(), "Id", "City", petBusiness.AddressId);
            ViewData["BusinessTypeId"] = new SelectList(_context.Set<BusinessType>(), "Id", "Id", petBusiness.BusinessTypeId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", petBusiness.IdentityUserId);
            return View(petBusiness);
        }

        // GET: PetBusinesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petBusiness = await _context.PetBusiness
                .Include(p => p.Address)
                .Include(p => p.BusinessType)
                .Include(p => p.identityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var petBusiness = await _context.PetBusiness.FindAsync(id);
            _context.PetBusiness.Remove(petBusiness);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetBusinessExists(int id)
        {
            return _context.PetBusiness.Any(e => e.Id == id);
        }
    }
}
