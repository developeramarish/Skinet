using API.Helper;
using AutoMapper;
using Core.Interface;
using Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ExtensionConfigureServices  
    {
        public static void ApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>),(typeof(GenericRepository<>)));
            services.AddScoped<IBasketRepository,BasketRepository>();

            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}