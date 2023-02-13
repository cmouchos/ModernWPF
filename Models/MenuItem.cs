﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWPF.Models
{
    public class MenuItem
    {
        public string Food { get; set; }
        public decimal Price { get; set; }

        public string Display
        {
            get { return $"{Food} - {Price}"; }
        }
    }
}
