using Divarcheh.Domain.Core.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divarcheh.Domain.Core.Entities.Advertisement;
using Divarcheh.Domain.Core.Entities.BaseEntities;
using Divarcheh.Domain.Core.Entities.User;
using Divarcheh.Infrastructure.EfCore.Common;
using Microsoft.EntityFrameworkCore;

namespace Divarcheh.Infrastructure.EfCore.Repositories
{
    public class BaseDataRepository : IBaseDataRepository
    {
        private readonly AppDbContext _dbContext;

        public BaseDataRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<City>> GetCities(CancellationToken cancellationToken)
            => await _dbContext.Cities.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<List<Brand>> GetBrands(CancellationToken cancellationToken)
            => await _dbContext.Brands.AsNoTracking().ToListAsync(cancellationToken);

        public async Task AddAdvImages(List<string> imgAddress, int advId,CancellationToken cancellationToken)
        {
            var images = imgAddress.Select(x => new Image()
            {
                Path = x,
                AdvertisementId = advId
            });

            await _dbContext.Images.AddRangeAsync(images, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}