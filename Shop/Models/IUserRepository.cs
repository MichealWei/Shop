﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class IUserRepository
    {
        IQueryable<Customer> Users { get; }
    }
}
