﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
namespace SportsStore.Service.Interfaces
{
    public interface IDiscountService
    {
        List<Discount> GetDiscounts();
    }
}
