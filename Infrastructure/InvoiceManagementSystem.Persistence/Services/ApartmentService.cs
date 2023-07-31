using AutoMapper;
using InvoiceManagementSystem.Application.Abstractions.Services;
using InvoiceManagementSystem.Application.DTOs.ApartmentDTOs;
using InvoiceManagementSystem.Application.UnitOfWorks;
using InvoiceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementSystem.Persistence.Services
{
    public class ApartmentService : IApartmentService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public ApartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetApartmentDto> CreateApartmentAsync(CreateApartmentDto apartmentDto)
        {
            bool result = await _unitOfWork.ApartmentRepository.CreateAsync(_mapper.Map<Apartment>(apartmentDto));
            if (!result)
                throw new Exception("hata");
            await _unitOfWork.SaveAsync();
            return _mapper.Map<GetApartmentDto>(apartmentDto);
        }
        public async Task DeleteApartmentAsync(int apartmentId)
        {
            bool result = await _unitOfWork.ApartmentRepository.Deleteasync(apartmentId);
            if (!result)
                throw new Exception("hata");
            await _unitOfWork.SaveAsync();
        }
        public async Task<List<GetApartmentDto>> GetAllApartentsAsync()
             => _mapper.Map<List<GetApartmentDto>>(await _unitOfWork.ApartmentRepository.GetAll().ToListAsync());

        public async Task<GetApartmentDto> UpdateApartmentAsync(UpdateApartmentDto apartmentDto)
        {
            bool result = _unitOfWork.ApartmentRepository.Update(_mapper.Map<Apartment>(apartmentDto));
            if (!result)
                throw new Exception("hata");
            await _unitOfWork.SaveAsync();
            return _mapper.Map<GetApartmentDto>(apartmentDto);
        }
        public async Task<GetApartmentDto> GetApartmentByIdAsync(int apartmentId)
           => _mapper.Map<GetApartmentDto>(await _unitOfWork.ApartmentRepository.GetAsync(apartmentId));

        public async Task<List<GetApartmentDto>> GetApartmentByUserNameAsync(string userName)
            => _mapper.Map<List<GetApartmentDto>>(await _unitOfWork.ApartmentRepository
                .Table
                .Include(x => x.Invoices)
                .Include(x => x.User)
                .Where(x => x.User.UserName == userName)
                .ToListAsync());
    }
}
