using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Precise.Technology.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Precise.Technology
{
    public interface ITechnologyService : IAsyncCrudAppService<TechnologyInfoDto, long, GetTechnologyInfoInput>
    {
        Task<TechnologyInfoDto> GetById(EntityDto<long> input);
        Task<IEnumerable<TechnologyInfoDto>> getTechnologyList(string input);

    }
}
