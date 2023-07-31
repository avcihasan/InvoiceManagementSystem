using InvoiceManagementSystem.Application.Abstractions.Services;
using InvoiceManagementSystem.Application.DTOs.MessageDTOs;
using InvoiceManagementSystem.Application.DTOs.PaymentDTOs;
using InvoiceManagementSystem.Application.DTOs.UserDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
          => Ok(await _userService.GetAllUsersAsync());

        [HttpGet("{userIdOrUserName}")]
        public async Task<IActionResult> GetUser([FromRoute] string userIdOrUserName)
           => Ok(await _userService.GetUserByUserNameOrIdAsync(userIdOrUserName));

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
           => Ok(await _userService.CreateUserAsync(userDto));

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto userDto)
            => Ok(await _userService.UpdateUserAsync(userDto));

        [HttpDelete("{userName}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string userName)
        {
            await _userService.DeleteUserAsync(userName);
            return Ok();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetDebtList()
            => Ok(await _userService.GetDebtListAsync());
    }
}
