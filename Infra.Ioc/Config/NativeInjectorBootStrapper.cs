using Infra.Storage.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Business.Abstractions.Interfaces.DapperRepository;
using FluentValidation;
using Infra.Storage.Dapper;
using Infra.Storage.Repositories.Dapper;
using Business.Abstractions.Interfaces.EFRepository;
using Infra.Storage.Repositories.EF;
using MediatR;
using Business.AutoMapper;
using Business.Abstractions.Interfaces.IO;
using Business.Abstractions.IO.CoreResult;
using Business.Abstractions.IO.StoreProduct;
using Business.Abstractions.Interfaces.Services;
using Business.Services;
using Business.Validations.User;
using Business.Validations.StoreProduct;
using Business.Abstractions.IO.User;
using FluentValidation.AspNetCore;
using Business.Validations.Store;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.Supplier;
using Business.Validations.Supplier;
using Business.Validations.UserStore;
using Business.Abstractions.IO.UserStore;

namespace Infra.Ioc.Config
{
    public static class NativeInjectorBootstrapper
    {

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped(typeof(IResultOutput<>), typeof(ResultOutput<>));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserEFRepository, UserEFRepository>();
            services.AddScoped<IUserDapperRepository, UserDapperRepository>();

            services.AddScoped<IStoreProductService, StoreProductService>();
            services.AddScoped<IProductDapperRepository, ProductDapperRepository>();
            services.AddScoped<IProductEFRepository, ProductEFRepository>();

            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IStoreEFRepository, StoreEFRepository>();
            services.AddScoped<IStoreDapperRepository, StoreDapperRepository>();

            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ISupplierEFRepository, SupplierEFRepository>();
            services.AddScoped<ISupplierDapperRepository, SupplierDapperRepository>();

        }
        public static void RegisterFluentValidationAction(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddTransient<IValidator<StoreProductInsertInput>, StoreProductInsertValidation>();
            services.AddTransient<IValidator<StoreProductUpdateInput>, StoreProductUpdateValidation>();

            services.AddTransient<IValidator<UserInsertInput>, UserInsertInputValidator>();
            services.AddTransient<IValidator<UserUpdateInput>, UserUpdateInputValidator>();

            services.AddTransient<IValidator<StoreUpdateInput>, StoreUpdateValidation>();
           // services.AddTransient<IValidator<StoreInsertInput>, StoreInsertValidation>();

            services.AddTransient<IValidator<SupplierUpdateInput>, SupplierUpdateValidation>();
            services.AddTransient<IValidator<SupplierInsertInput>, SupplierInsertValidation>();

        }
        public static void RegisterContexts(this IServiceCollection services)
        {
            services.AddScoped<MarketplaceDapperContext>();
            services.AddDbContext<MarketplaceEFContext>();

        }
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            AutoMapperConfig.RegisterMappings();
        }
    }
}