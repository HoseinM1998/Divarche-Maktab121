using Divarcheh.Domain.Core.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divarcheh.Domain.Core.Dto.Advertisement;
using Divarcheh.Domain.Core.Entities.Advertisement;
using Divarcheh.Domain.Core.Entities.Configs;
using Divarcheh.Domain.Core.Enum;
using Divarcheh.Infrastructure.EfCore.Common;
using Microsoft.EntityFrameworkCore;

namespace Divarcheh.Infrastructure.EfCore.Repositories
{
    public class AdvertisementRepository(AppDbContext dbContext, SiteSettings siteSettings) : IAdvertisementRepository
    {
        public async Task<int> Create(CreateAdvertisementDto model, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Advertisement()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Price = model.Price,
                    Model = model.Model,
                    BrandId = model.BrandId,
                    CategoryId = model.CategoryId,
                    CityId = model.CityId,
                    UserId = model.UserId,
                    CreateAt = DateTime.Now,
                    AdvertisementType = model.AdvertisementType,
                    AdvertisementStatus = model.AdvertisementStatus,
                    AdvertisementFinalStatus = AdvertisementFinalStatusEnum.Pending
                };

                await dbContext.Advertisements.AddAsync(entity, cancellationToken);
                await dbContext.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
            catch (Exception e)
            {

                throw new Exception("Exception");
            }

        }

        public Task<IEnumerable<GetAdvertisementDto>> GetMostVisited(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAdvertisementDto>> GetMostPopular(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetAdvertisementDto>> GetNewest(CancellationToken cancellationToken)
        {
            var ads = await dbContext.Advertisements
                .OrderByDescending(x => x.CreateAt)
                .Take(siteSettings.AdvConfig.CountInHomePage)
                .Select(x => new GetAdvertisementDto()
                {
                    Title = x.Title,
                    Category = x.Category.ParentCategory.Title,
                    SubCategory = x.Category.Title,
                    Price = x.Price,
                    ImagePath = x.Images.FirstOrDefault().Path,
                    CreateAt = x.CreateAt,
                    Status = x.AdvertisementStatus
                }).ToListAsync(cancellationToken);

            return ads;
        }
    }
}
