using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Precise.Check.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Precise.Device
{
    public interface IDeviceService : IAsyncCrudAppService<DeviceInfoDto, long>
    {
    }
}
