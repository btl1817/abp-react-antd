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
using Precise.Check.Dto;

namespace Precise.Check
{
    [AbpAuthorize]
    public class CheckService : PreciseAppServiceBase, ICheckService
    {
        private readonly IRepository<CheckLog, long> _checkLog;
        private readonly IRepository<User, long> _user;
        private readonly IRepository<ProductLineInfo, long> _productLineInfo;
        private readonly IRepository<DeviceInfo, long> _deviceInfo;
        public CheckService(IRepository<CheckLog, long> checkLog, IRepository<User, long> user
            , IRepository<ProductLineInfo, long> productLineInfo
            , IRepository<DeviceInfo, long> deviceInfo)
        {
            _checkLog = checkLog;
            _user = user;
            _productLineInfo = productLineInfo;
            _deviceInfo = deviceInfo;
        }

        public Task<CheckLogDto> Create(CheckLogDto input)
        {
            throw new NotImplementedException();
        }

        public Task Delete(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<CheckLogDto> Get(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<CheckLogDto>> GetAll(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<CheckLogDto> Update(CheckLogDto input)
        {
            throw new NotImplementedException();
        }
    }
}
