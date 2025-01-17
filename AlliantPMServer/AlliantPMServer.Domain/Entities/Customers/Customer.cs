﻿using AlliantPMServer.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantPMServer.Domain.Entities.Customers
{
    public class Customer : CoreEntity
    {
        public string Name { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string Phone { get; set; } = null!;

    }
}
