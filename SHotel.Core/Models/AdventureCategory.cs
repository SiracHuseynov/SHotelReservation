﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Core.Models
{
    public class AdventureCategory : BaseEntity
    {
        public string Name { get; set; }
        public List<Adventure> Adventures { get; set; } 

    }
}
