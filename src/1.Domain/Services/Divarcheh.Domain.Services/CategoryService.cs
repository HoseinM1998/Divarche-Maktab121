using Divarcheh.Domain.Core.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divarcheh.Domain.Core.Contracts.Repository;
using Divarcheh.Domain.Core.Dto.Advertisement;
using Divarcheh.Domain.Core.Dto.HomePage;

namespace Divarcheh.Domain.Services
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        public List<GetCategoryForHomePageDto> GetCategoriesForHomePage()
             => categoryRepository.GetCategoriesForHomePage();

        public List<CategoryDto> GetParentCategories()
             => categoryRepository.GetParentCategories();

        public List<CategoryDto> GetChildCategories(int parentId)
            => categoryRepository.GetChildCategories(parentId);

        public async Task<GetDataForCreateAdvDto> GetDataForCreateAdv(int childId, CancellationToken cancellationToken)
        {
           return await categoryRepository.GetDataForCreateAdv(childId, cancellationToken);
        }
    }
}
