﻿using FleetManagement.Framework.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IFuelCardDriverService
    {
        void UpdateFuelCardDriver(FuelCardDriverDto fuelCardDriverDto);
    }
}
