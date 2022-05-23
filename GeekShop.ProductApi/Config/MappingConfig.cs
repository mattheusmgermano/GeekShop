using AutoMapper;
using GeekShop.ProductApi.Data.ValueObjects;
using GeekShop.ProductApi.Model;

namespace GeekShop.ProductApi.Config;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(
            config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });
        return mappingConfig;
    }
}