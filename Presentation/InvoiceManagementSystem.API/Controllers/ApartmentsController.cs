using InvoiceManagementSystem.Application.Abstractions.Services;
using InvoiceManagementSystem.Application.DTOs.ApartmentDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        readonly IApartmentService _apartmentService;

        public ApartmentsController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetApartments()
           => Ok(await _apartmentService.GetAllApartentsAsync());

        [HttpGet("{apartmentId}")]
        public async Task<IActionResult> GetApartment([FromRoute] int apartmentId)
             => Ok(await _apartmentService.GetApartmentByIdAsync(apartmentId));

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetApartment([FromRoute] string userId)
            => Ok(await _apartmentService.GetApartmentByUserNameAsync(userId));

        [HttpPost]
        public async Task<IActionResult> CreateApartment([FromBody] CreateApartmentDto apartmentDto)
            => Ok(await _apartmentService.CreateApartmentAsync(apartmentDto));
        [HttpPut]
        public async Task<IActionResult> UpdateApartment([FromBody] UpdateApartmentDto apartmentDto)
            => Ok(await _apartmentService.UpdateApartmentAsync(apartmentDto));
        [HttpDelete("{apartmentId}")]
        public async Task<IActionResult> DeleteApartment([FromRoute] int apartmentId)
        {
            await _apartmentService.DeleteApartmentAsync(apartmentId);
            return Ok();
        }

       
    }
}
