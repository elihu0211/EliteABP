using EliteABP.Develop.Categories;
using EliteABP.Develop.Categories.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EliteABP.Develop.Repositories;
public class CategoryRepository(IDbContextProvider<DevelopDbContext> dbContextProvider) : EfCoreRepository<DevelopDbContext, Category, Guid>(dbContextProvider), ICategoryRepository
{

}