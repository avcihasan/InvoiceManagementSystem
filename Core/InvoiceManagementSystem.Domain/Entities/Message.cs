﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Domain.Entities
{
    public class Message : BaseEntity
    {
        public string Body { get; set; }
        public bool Read { get; set; }

        public AppUser User { get; set; }
    }
}
