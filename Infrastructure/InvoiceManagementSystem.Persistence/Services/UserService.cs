using AutoMapper;
using InvoiceManagementSystem.Application.Abstractions.Services;
using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.DTOs.ApartmentDTOs;
using InvoiceManagementSystem.Application.DTOs.InvoiceDTOs;
using InvoiceManagementSystem.Application.DTOs.MessageDTOs;
using InvoiceManagementSystem.Application.DTOs.PaymentDTOs;
using InvoiceManagementSystem.Application.DTOs.UserDTOs;
using InvoiceManagementSystem.Application.UnitOfWorks;
using InvoiceManagementSystem.Domain.Entities;
using InvoiceManagementSystem.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Persistence.Services
{
    public class UserService : IUserService
    {

        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;
        readonly UserManager<AppUser> _userManager;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }



        public async Task<GetUserDto> GetUserByUserNameOrIdAsync(string userNameOrId)
        {
            AppUser user = await _userManager.FindByNameAsync(userNameOrId);
            user ??= await _userManager.FindByNameAsync(userNameOrId);
            if (user is null)
                throw new Exception("Hata");
            return _mapper.Map<GetUserDto>(user);
        }

        public async Task<GetUserDto> CreateUserAsync(CreateUserDto userDto)
        {
            AppUser user = _mapper.Map<AppUser>(userDto);
            user.Id = Guid.NewGuid().ToString();
            user.Apartments.Add(await _unitOfWork.ApartmentRepository.GetAsync(userDto.ApartmentId));
            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded)
                throw new Exception("hata");
            return _mapper.Map<GetUserDto>(userDto);
        }
        public async Task DeleteUserAsync(string userId)
        {
            AppUser user = await _userManager.FindByIdAsync(userId) ?? throw new Exception("hata");
            IdentityResult result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                throw new Exception("hata");
        }
        public async Task<List<GetUserDto>> GetAllUsersAsync()
            => _mapper.Map<List<GetUserDto>>(await _userManager.Users.ToListAsync());
        public async Task<GetUserDto> UpdateUserAsync(UpdateUserDto userDto)
        {
            AppUser user = await _userManager.FindByIdAsync(userDto.Id);
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
        public async Task<List<DebtDto>> GetDebtListAsync()
        {
            List<DebtDto> debtList = new();

            (await _unitOfWork.ApartmentRepository.Table.Include(x => x.User).Include(x => x.Invoices).ToListAsync()).ForEach(x =>
            {
                DebtDto debt = new()
                {
                    User = _mapper.Map<GetUserDto>(x.User),
                    TotalDebt = 0
                };
                x.Invoices.Where(x => x.Payment == false).ToList().ForEach(x => debt.TotalDebt += x.Price);
                if (debt.TotalDebt > 0)
                    debtList.Add(debt);
            });

            return debtList;
        }

    }
}
