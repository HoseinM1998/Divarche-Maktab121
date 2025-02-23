using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divarcheh.Domain.Core.Dto.Advertisement;
using Divarcheh.Domain.Core.Entities.Advertisement;

namespace Divarcheh.Domain.Core.Contracts.Repository
{
    public interface IAdvertisementRepository
    {
        Task<int> Create(CreateAdvertisementDto model,CancellationToken cancellationToken);
        Task<IEnumerable<GetAdvertisementDto>> GetMostVisited(CancellationToken cancellationToken);
        Task<IEnumerable<GetAdvertisementDto>> GetMostPopular(CancellationToken cancellationToken);
        Task<IEnumerable<GetAdvertisementDto>> GetNewest(CancellationToken cancellationToken);
    }
}
