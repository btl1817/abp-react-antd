using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Precise.Check.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Precise.Check
{
    public interface ICheckService : IAsyncCrudAppService<CheckLogDto, long>
    {
    }
}
