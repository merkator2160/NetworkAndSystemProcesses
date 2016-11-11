using AutoMapper;
using Fifth.Server.Models;
using System;
using System.ServiceProcess;

namespace Fifth.Server
{
    public class AutoMapperConfig
    {
        private static readonly Lazy<IMapper> _mapper = new Lazy<IMapper>(() => new MapperConfiguration(RegisterMappings).CreateMapper());


        // FUNCTIONS //////////////////////////////////////////////////////////////////////////////
        public static IMapper GetConfiguredMapper()
        {
            return _mapper.Value;
        }
        public static void RegisterMappings(IMapperConfiguration cfg)
        {
            cfg.CreateMap<ServiceController, ServiceInfo>();
        }
    }
}