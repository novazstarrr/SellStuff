﻿using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.DeviceTypes
{
    public interface IDeviceTypesRepository
    {
        Task<IEnumerable<DeviceType>> GetDeviceTypesByBrandId(byte brandId);
    }
}
