using AutoMapper;
using Business.Abstractions.IO.Product;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.Supplier;
using Business.Abstractions.IO.User;
using Business.Abstractions.IO.UserStore;
using Entities.Entities;

namespace Presentation.Api.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductUpdateInput, ProductEntity>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ConvertIFormFileToByte()));
            CreateMap<ProductInsertInput, ProductEntity>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ConvertIFormFileToByte()));
            CreateMap<ProductEntity, ProductOutput>();

            CreateMap<UserEntity, UserOutput>();
            CreateMap<UserInsertInput, UserEntity>();
            CreateMap<UserUpdateInput, UserEntity>();

            CreateMap<StoreUpdateInput, StoreEntity>()
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ConvertIFormFileToByte()));
            CreateMap<StoreInsertInput, StoreEntity>()
             .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ConvertIFormFileToByte()));
            CreateMap<StoreEntity, StoreOutput>();

            CreateMap<SuppliersEntity, SupplierOutput>();
            CreateMap<SupplierInsertInput, SuppliersEntity>();
            CreateMap<SupplierUpdateInput, SuppliersEntity>();


            CreateMap<UserStoreInsertInput, UserStoreEntity>();
            CreateMap<UserStoreEntity, UserStoreOutput>();


        }
    }
}
