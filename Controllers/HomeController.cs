//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using petOwnerOneStopShop.Data;
//using petOwnerOneStopShop.Models;
//using petOwnerOneStopShop.ViewModels;
//using System;
//using System.IO;
//using System.Threading.Tasks;

//namespace petOwnerOneStopShop.Controllers
//{
//    public class HomeController : Controller
//    {

//        private readonly ApplicationDbContext dbContext;
//        private readonly IWebHostEnvironment webHostEnvironment;
//        public HomeController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
//        {
//            dbContext = context;
//            webHostEnvironment = hostEnvironment;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var employee = await dbContext.Employees.ToListAsync();
//            return View(employee);
//        }

//        public IActionResult New()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> New(EmployeeViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                string uniqueFileName = UploadedFile(model);

//                Employee employee = new Employee
//                {
//                    FirstName = model.FirstName,
//                    LastName = model.LastName,
//                    FullName = model.FirstName + " " + model.LastName,
//                    Gender = model.Gender,
//                    Age = model.Age,
//                    Office = model.Office,
//                    Position = model.Position,
//                    Salary = model.Salary,
//                    ProfilePicture = uniqueFileName,
//                };
//                dbContext.Add(employee);
//                await dbContext.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View();
//        }

//        private string UploadedFile(EmployeeViewModel model)
//        {
//            string uniqueFileName = null;

//            if (model.ProfileImage != null)
//            {
//                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
//                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
//                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
//                using (var fileStream = new FileStream(filePath, FileMode.Create))
//                {
//                    model.ProfileImage.CopyTo(fileStream);
//                }
//            }
//            return uniqueFileName;
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}