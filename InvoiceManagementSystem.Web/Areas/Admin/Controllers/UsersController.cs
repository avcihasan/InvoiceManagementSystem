using InvoiceManagementSystem.Web.Areas.Admin.Models;
using InvoiceManagementSystem.Web.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserVM userVM)
        {
            await _userService.CreateUserAsync(userVM);
            return RedirectToAction(nameof(GetUsers), "Admin");
        }
        public async Task<IActionResult> UpdateUser(string userId)
        {
            GetUserVM getUser = await _userService.GetUserAsync(userId);
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
            await _userService.UpdateUserAsync(userVM);
            return RedirectToAction(nameof(GetUsers), "Admin");
        }
        public async Task<IActionResult> GetUsers()
            => View(await _userService.GetAllUsersAsync());

        public async Task<IActionResult> DeleteUser(string userId)
        {
            await _userService.DeleteUserAsync(userId);
            return RedirectToAction(nameof(GetUsers));

        }

        public async Task<IActionResult> GetDebtList()
           => View(await _userService.GetDebtListAsync());
    }
}
