using AutoMapper;
using InvoiceManagementSystem.Application.Abstractions.Services;
using InvoiceManagementSystem.Application.DTOs.MessageDTOs;
using InvoiceManagementSystem.Application.UnitOfWorks;
using InvoiceManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Persistence.Services
{
    public class MessageService:IMessageService
    {
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;
        readonly IUserService _userService;

        public MessageService(IMapper mapper, IUnitOfWork unitOfWork, IUserService userService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<List<GetMessageDto>> GetAllMessagesAsync()
            => _mapper.Map<List<GetMessageDto>>(await _unitOfWork.MessageRepository.GetAll().ToListAsync());
        public async Task<List<GetMessageDto>> GetUnReadAllMessagesAsync()
          => _mapper.Map<List<GetMessageDto>>(await _unitOfWork.MessageRepository.GetAll(x => x.Read == false).ToListAsync());

        public async Task SendMessageAsync(CreateMessageDto messageDto)
        {
            Message message = _mapper.Map<Message>(messageDto);
            message.User = _mapper.Map<AppUser>(await _userService.GetUserByUserNameOrIdAsync(messageDto.UserName));
            await _unitOfWork.MessageRepository.CreateAsync(message);
            await _unitOfWork.SaveAsync();
        }
    }
}
