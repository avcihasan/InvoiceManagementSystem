using InvoiceManagementSystem.Web.Areas.Admin.Models;
using InvoiceManagementSystem.Web.Areas.Admin.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace InvoiceManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserVM userVM)
        {
            await _adminService.CreateUserAsync(userVM);
            return RedirectToAction(nameof(GetUsers), "Admin");
        }
        public async Task<IActionResult> UpdateUser(string userId)
        {
            GetUserVM getUser = await _adminService.GetUserAsync(userId);
            UpdateUserVM updateUser = new()
            {
                CarPlateNumber = getUser.CarPlateNumber,
                Email = getUser.Email,
                Id = getUser.Id,
                Name = getUser.Name,
                PhoneNumber = getUser.PhoneNumber,
                Surname = getUser.Surname,
                TCNo = getUser.TCNo,
                UserName = getUser.UserName
            };
            return View(updateUser);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserVM userVM)
        {
            await _adminService.UpdateUserAsync(userVM);
            return RedirectToAction(nameof(GetUsers), "Admin");
        }
        public async Task<IActionResult> GetUsers()
            => View(await _adminService.GetAllUsersAsync());

        public async Task<IActionResult> DeleteUser(string userId)
        {
            await _adminService.DeleteUserAsync(userId);
            return RedirectToAction(nameof(GetUsers));

        }


        public IActionResult CreateApartment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateApartment(CreateApartmentVM apartmentVM)
        {
            await _adminService.CreateApartmentAsync(apartmentVM);
            return RedirectToAction(nameof(GetUsers), "Admin");
        }
        public async Task<IActionResult> UpdateApartment(int apartmentId)
        {
            GetApartmentVM getApartment = await _adminService.GetApartmentAsync(apartmentId);
            UpdateApartmentVM updateApartment = new()
            {
                ApartmentNumber = getApartment.ApartmentNumber,
                BlockNumber = getApartment.BlockNumber,
                FloorLocation = getApartment.FloorLocation,
                Id = getApartment.Id,
                Situation = getApartment.Situation,
                Tenant = getApartment.Tenant,
                Type = getApartment.Type
            };
            return View(updateApartment);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateApartment(UpdateApartmentVM apartmentVM)
        {
            await _adminService.UpdateApartmentAsync(apartmentVM);
            return RedirectToAction(nameof(GetApartments), "Admin");
        }
        public async Task<IActionResult> GetApartments()
            => View(await _adminService.GetAllApartmentsAsync());

        public async Task<IActionResult> DeleteApartment(int apartmentId)
        {
            await _adminService.DeleteApartmentAsync(apartmentId);
            return RedirectToAction(nameof(GetApartments));

        }


        public IActionResult CreateInvoice()
        {
            ViewBag.date = DateTime.Now.ToString("dd MMMM yyyy", new System.Globalization.CultureInfo("tr-TR", true));
            ViewBag.month = DateTime.Now.ToString("MMMM", new System.Globalization.CultureInfo("tr-TR", true));
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateInvoice(decimal invoicePrice)
        {
            await _adminService.CreateInvoiceAsync(invoicePrice);
            return RedirectToAction(nameof(GetApartments)); 
        }

        public async Task<IActionResult> GetPayments()
            => View(await _adminService.GetPaymentsAsync());

        public async Task<IActionResult> GetDebtList()
            => View(await _adminService.GetDebtListAsync());

        public async Task<IActionResult> GetMessages()
            => View(await _adminService.GetMessagesAsync());
    }
}
