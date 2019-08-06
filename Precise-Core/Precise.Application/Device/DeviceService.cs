using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using Precise.Technology.Dto;
using Abp;
using Abp.Auditing;
using Abp.RealTime;
using Abp.Runtime.Session;
using Abp.Timing;
using System.Linq.Dynamic.Core;
using System.Linq;
using Abp.Authorization;
using Precise.Authorization.Users;
using Precise.Device.Dto;

namespace Precise.Device
{
    [AbpAuthorize]
    public class DeviceService : PreciseAppServiceBase, IDeviceService
    {
        private readonly IRepository<DeviceInfo, long> _checkLog;
        private readonly IRepository<User, long> _user;
        public DeviceService(IRepository<DeviceInfo, long> checkLog, IRepository<User, long> user)
        {
            _checkLog = checkLog;
            _user = user;
        }

        public Task<DeviceInfoDto> Create(DeviceInfoDto input)
        {
            throw new NotImplementedException();
        }

        public Task Delete(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<DeviceInfoDto> Get(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<DeviceInfoDto>> GetAll(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<DeviceInfoDto> Update(DeviceInfoDto input)
        {
            throw new NotImplementedException();
        }
    }
}
