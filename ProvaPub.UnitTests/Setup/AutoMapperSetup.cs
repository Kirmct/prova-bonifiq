using AutoMapper;
using ProvaPub.Application.Mappings;

namespace ProvaPub.UnitTests.Setup;
public class AutoMapperSetup
{
    public static IMapper GetMapper()
    {
        MapperConfiguration config = new(cfg => cfg.AddProfile(new DomainToDTOMapping()));
        return config.CreateMapper();
    }
}
