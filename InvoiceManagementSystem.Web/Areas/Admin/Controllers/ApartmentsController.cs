using InvoiceManagementSystem.Web.Areas.Admin.Models;
using InvoiceManagementSystem.Web.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApartmentsController : Controller
    {
        readonly IApartmentService _apartmentService;

        public ApartmentsController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        public IActionResult CreateApartment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateApartment(CreateApartmentVM apartmentVM)
        {
            await _apartmentService.CreateApartmentAsync(apartmentVM);
            return RedirectToAction(nameof(GetApartments));
        }
        public async Task<IActionResult> UpdateApartment(int apartmentId)
        {
            GetApartmentVM getApartment = await _apartmentService.GetApartmentAsync(apartmentId);
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
            await _apartmentService.UpdateApartmentAsync(apartmentVM);
            return RedirectToAction(nameof(GetApartments), "Admin");
        }
        public async Task<IActionResult> GetApartments()
            => View(await _apartmentService.GetAllApartmentsAsync());

        public async Task<IActionResult> DeleteApartment(int apartmentId)
        {
            await _apartmentService.DeleteApartmentAsync(apartmentId);
            return RedirectToAction(nameof(GetApartments));

        }

    }
}
