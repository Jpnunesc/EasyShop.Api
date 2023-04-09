using AutoMapper;
using Business.Abstractions.IO.StoreProduct;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.Supplier;
using Business.Abstractions.IO.User;
using Business.Abstractions.IO.UserStore;
using Entities.Entities;
using Business.Abstractions.IO.Inventory;

namespace Presentation.Api.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StoreProductUpdateInput, StoreProductEntity>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ConvertIFormFileToByte()));
            CreateMap<StoreProductInsertInput, StoreProductEntity>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ConvertIFormFileToByte()));

            CreateMap<StoreProductEntity, StoreProductOutput>();

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

            CreateMap<InventoryMovementEntity, InventoryMovementOutput>();
            CreateMap<InventoryMovementInsertInput, InventoryMovementEntity>();

            CreateMap<StoreProductMovementInput, StoreProductMovementEntity>();
            CreateMap<StoreProductMovementEntity, StoreProductMovementOutput>();
        }
    }
}
