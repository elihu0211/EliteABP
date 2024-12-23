using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.Testing;
using Volo.Abp.Uow;

namespace EliteABP.Develop.TestBase;
public abstract class DevelopTestBase<TStartupModule> : AbpIntegratedTest<TStartupModule> where TStartupModule : IAbpModule
{
    protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
    {
        options.UseAutofac();
    }

    // 開啟工作單元(無返回值)
    protected virtual async Task WithUnitOfWorkAsync(AbpUnitOfWorkOptions options, Func<Task> action)
    {
        using var scop = ServiceProvider.CreateScope();
        var uowManager = scop.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();

        using var uow = uowManager.Begin(options);
        await action();
        await uow.CompleteAsync();
    }

    // 開啟工作單元(有返回值)
    protected virtual async Task<TResult> WithUnitOfWorkAsync<TResult>(AbpUnitOfWorkOptions options, Func<Task<TResult>> func)
    {
        using var scop = ServiceProvider.CreateScope();
        var uowManager = scop.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();

        using var uow = uowManager.Begin(options);
        var result = await func();
        await uow.CompleteAsync();
        return result;
    }

    protected virtual Task WithUnitOfWorkAsync(Func<Task> action)
    {
        return WithUnitOfWorkAsync(new AbpUnitOfWorkOptions(), action);
    }
    protected virtual Task<TResult> WithUnitOfWorkAsync<TResult>(Func<Task<TResult>> func)
    {
        return WithUnitOfWorkAsync(new AbpUnitOfWorkOptions(), func);
    }
}