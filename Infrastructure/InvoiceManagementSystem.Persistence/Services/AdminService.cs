using AutoMapper;
using InvoiceManagementSystem.Application.Abstractions.Services;
using InvoiceManagementSystem.Application.DTOs.ApartmentDTOs;
using InvoiceManagementSystem.Application.DTOs.MessageDTOs;
using InvoiceManagementSystem.Application.DTOs.PaymentDTOs;
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
            user.Apartments.Add(await _unitOfWork.ApartmentRepository.GetAsync(userDto.ApartmentId));
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
            AppUser user = await _userManager.FindByIdAsync(userId) ?? throw new Exception("hata");
            IdentityResult result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                throw new Exception("hata");
        }

        public async Task<List<GetApartmentDto>> GetAllApartentsAsync()
         => _mapper.Map<List<GetApartmentDto>>(await _unitOfWork.ApartmentRepository.GetAll().ToListAsync());

        public async Task<List<GetUserDto>> GetAllUsersAsync()
            => _mapper.Map<List<GetUserDto>>(await _userManager.Users.ToListAsync());

        public async Task<List<GetMessageDto>> GetAllMessagesAsync()
            => _mapper.Map<List<GetMessageDto>>(await _unitOfWork.MessageRepository.GetAll().ToListAsync());
        public async Task<List<GetMessageDto>> GetAllMessagesAsync(bool read)
          => _mapper.Map<List<GetMessageDto>>(await _unitOfWork.MessageRepository.GetAll(x => x.Read == read).ToListAsync());

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

        public async Task CreateInvoiceAsync(decimal invoicePrice)
        {
            (await _unitOfWork.ApartmentRepository.GetAll().ToListAsync()).ForEach(x => x.Invoices.Add(new() { Price = invoicePrice }));
            await _unitOfWork.SaveAsync();
        }

        public async Task CreateInvoiceAsync(int apartmentId, decimal invoicePrice)
        {
            Apartment apartment = await _unitOfWork.ApartmentRepository.GetAsync(apartmentId);
            apartment.Invoices.Add(new() { Price = invoicePrice });

            await _unitOfWork.SaveAsync();
        }

        public async Task<List<GetPaymentDto>> GetAllPaymentsAsync()
        {
            List<Payment> paymnets = await _unitOfWork.PaymentRepository.Table.Include(x=>x.Invoice).Include(x=>x.User).ToListAsync();
            List<GetPaymentDto> getPaymentDtos = new();
            paymnets.ForEach(x =>
            {
                getPaymentDtos.Add(new() { TotalPayment = x.Invoice.Price, User = _mapper.Map<GetUserDto>(x.User) });
            });
            return getPaymentDtos;
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
                if (debt.TotalDebt>0)
                    debtList.Add(debt);
            });

            return debtList;
        }
        public async Task<GetUserDto> GetUserByIdAsync(string userId)
            => _mapper.Map<GetUserDto>(await _userManager.FindByIdAsync(userId));

        public async Task<GetApartmentDto> GetApartmentByIdAsync(int apartmentId)
            => _mapper.Map<GetApartmentDto>(await _unitOfWork.ApartmentRepository.GetAsync(apartmentId));
    }
}
