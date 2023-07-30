using InvoiceManagementSystem.Web.Areas.Admin.Models;
using InvoiceManagementSystem.Web.Areas.Admin.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

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
            return RedirectToAction(nameof(CreateUser), "Admin");
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
            return RedirectToAction(nameof(UpdateUser), "Admin", await _adminService.UpdateUserAsync(userVM));
        }
        public async Task<IActionResult> GetUsers()
            => View(await _adminService.GetAllUsersAsync());

        public async Task<IActionResult> DeleteUser(string userId)
        {
            await _adminService.DeleteUserAsync(userId);
            return RedirectToAction(nameof(GetUsers));

        }
    }
}
