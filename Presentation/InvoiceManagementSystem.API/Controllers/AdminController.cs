using InvoiceManagementSystem.Application.Abstractions.Services;
using InvoiceManagementSystem.Application.DTOs.ApartmentDTOs;
using InvoiceManagementSystem.Application.DTOs.UserDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("[action]/{apartmentId}")]
        public async Task<IActionResult> GetApartment([FromRoute] int apartmentId)
       => Ok(await _adminService.GetApartmentByIdAsync(apartmentId));

        [HttpGet("[action]")]
        public async Task<IActionResult> GetApartments()
          => Ok(await _adminService.GetAllApartentsAsync());
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateApartment([FromBody] CreateApartmentDto apartmentDto)
            => Ok(await _adminService.CreateApartmentAsync(apartmentDto));
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateApartment([FromBody] UpdateApartmentDto apartmentDto)
            => Ok(await _adminService.UpdateApartmentAsync(apartmentDto));
        [HttpDelete("[action]/{apartmentId}")]
        public async Task<IActionResult> DeleteApartment([FromRoute] int apartmentId)
        {
            await _adminService.DeleteApartmentAsync(apartmentId);
            return Ok();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUsers()
          => Ok(await _adminService.GetAllUsersAsync());
        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetUser([FromRoute]string userId)
        => Ok(await _adminService.GetUserByIdAsync(userId));
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
            => Ok(await _adminService.CreateUserAsync(userDto));

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto userDto)
            => Ok(await _adminService.UpdateUserAsync(userDto));

        [HttpDelete("[action]/{userId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string userId)
        {
            await _adminService.DeleteUserAsync(userId);
            return Ok();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllMessages()
         => Ok(await _adminService.GetAllMessagesAsync());

        [HttpGet("[action]")]
        public async Task<IActionResult> CreateInvoice([FromQuery]decimal invoicePrice)
        {
            await _adminService.CreateInvoiceAsync(invoicePrice);
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPayments()
            =>Ok(await _adminService.GetAllPaymentsAsync());
        [HttpGet("[action]")]
        public async Task<IActionResult> GetDebtList()
            => Ok(await _adminService.GetDebtListAsync());
    }
}
