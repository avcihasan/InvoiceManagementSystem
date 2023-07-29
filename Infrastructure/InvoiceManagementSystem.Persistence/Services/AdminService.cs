using AutoMapper;
using InvoiceManagementSystem.Application.Abstractions.Services;
using InvoiceManagementSystem.Application.DTOs.ApartmentDTOs;
using InvoiceManagementSystem.Application.DTOs.UserDTOs;
using InvoiceManagementSystem.Application.UnitOfWorks;
using InvoiceManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementSystem.Persistence.Services
{
    public class AdminService : IAdminService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;
        readonly UserManager<AppUser> _userManager;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<GetApartmentDto> CreateApartmentAsync(CreateApartmentDto apartmentDto)
        {
            bool result = await _unitOfWork.ApartmentRepository.CreateAsync(_mapper.Map<Apartment>(apartmentDto));
            if (!result)
                throw new Exception("hata");
            await _unitOfWork.SaveAsync();
            return _mapper.Map<GetApartmentDto>(apartmentDto);
        }

        public async Task<GetUserDto> CreateUserAsync(CreateUserDto userDto)
        {
            AppUser user = _mapper.Map<AppUser>(userDto);
            user.Id = Guid.NewGuid().ToString();
            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded)
                throw new Exception("hata");
            return _mapper.Map<GetUserDto>(userDto);
        }

        public async Task DeleteApartmentAsync(int apartmentId)
        {
            bool result = await _unitOfWork.ApartmentRepository.Deleteasync(apartmentId);
            if (!result)
                throw new Exception("hata");
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteUserAsync(string userId)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new Exception("hata");
            IdentityResult result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                throw new Exception("hata");
        }

        public async Task<List<GetApartmentDto>> GetAllApartentsAsync()
         => _mapper.Map<List<GetApartmentDto>>(await _unitOfWork.ApartmentRepository.GetAll().ToListAsync());

        public async Task<List<GetUserDto>> GetAllUsersAsync()
            => _mapper.Map<List<GetUserDto>>(await _userManager.Users.ToListAsync());

        public async Task<GetApartmentDto> UpdateApartmentAsync(UpdateApartmentDto apartmentDto)
        {
            bool result = _unitOfWork.ApartmentRepository.Update(_mapper.Map<Apartment>(apartmentDto));
            if (!result)
                throw new Exception("hata");
            await _unitOfWork.SaveAsync();
            return _mapper.Map<GetApartmentDto>(apartmentDto);
        }

        public async Task<GetUserDto> UpdateUserAsync(UpdateUserDto userDto)
        {
            AppUser user =await _userManager.FindByIdAsync(userDto.Id);
            user.TCNo = userDto.TCNo;
            user.Name = userDto.Name;
            user.Surname = userDto.Surname;
            user.CarPlateNumber = userDto.CarPlateNumber;
            user.PhoneNumber = userDto.PhoneNumber;
            user.Email = userDto.Email;
            user.UserName = userDto.UserName;

            IdentityResult result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                throw new Exception("hata");

            await _userManager.UpdateSecurityStampAsync(user);
            return _mapper.Map<GetUserDto>(userDto);
        }
    }
}
