using InvoiceManagementSystem.Application.DTOs.MessageDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Abstractions.Services
{
    public interface  IMessageService
    {
        Task<List<GetMessageDto>> GetAllMessagesAsync();
        Task<List<GetMessageDto>> GetUnReadAllMessagesAsync();
        Task SendMessageAsync(CreateMessageDto messageDto);

    }
}
