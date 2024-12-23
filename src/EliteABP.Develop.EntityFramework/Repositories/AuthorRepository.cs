using EliteABP.Develop.Authors;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EliteABP.Develop.Repositories;
public class AuthorRepository(IDbContextProvider<DevelopDbContext> dbContextProvider) : EfCoreRepository<DevelopDbContext, Author, Guid>(dbContextProvider), IAuthorRepository
{

}