using AutoMapper;
using InvoiceManagementSystem.Application.DTOs.ApartmentDTOs;
using InvoiceManagementSystem.Application.DTOs.InvoiceDTOs;
using InvoiceManagementSystem.Application.DTOs.MessageDTOs;
using InvoiceManagementSystem.Application.DTOs.PaymentDTOs;
using InvoiceManagementSystem.Application.DTOs.UserDTOs;
using InvoiceManagementSystem.Domain.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<CreateApartmentDto,Apartment>();
            CreateMap<CreateApartmentDto, GetApartmentDto>();
            CreateMap<UpdateApartmentDto, Apartment>();
            CreateMap<UpdateApartmentDto, GetApartmentDto>();
            CreateMap<Apartment, GetApartmentDto>();


            CreateMap<CreateUserDto,AppUser>();
            CreateMap<CreateUserDto, GetUserDto>();
            CreateMap<UpdateUserDto, AppUser>();
            CreateMap<UpdateUserDto, GetUserDto>();
            CreateMap<AppUser, GetUserDto>(); 

            CreateMap<Payment, GetPaymentDto>(); 
            CreateMap<Message, GetMessageDto>(); 
            CreateMap<CreateMessageDto, Message>(); 

            CreateMap<Invoice, GetInvoiceDto>(); 
        }
    }
}
