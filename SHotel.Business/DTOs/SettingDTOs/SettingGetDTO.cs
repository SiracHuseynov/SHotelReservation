﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.SettingDTOs
{
    public class SettingGetDTO
    {
        public int Id { get; set; }
        public string Key { get; set; } 
        public string Value { get; set; }
        public bool IsDeleted { get; set; }         
          
    }
}
