using AutoMapper;
using Fifth.Server.Interfaces;
using Fifth.Server.Models;
using System;
using System.ServiceModel;
using System.ServiceProcess;

namespace Fifth.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, AddressFilterMode = AddressFilterMode.Any)]
    public class RemoteServiceManager : IRemoteServiceManager
    {
        private const Int32 TIMEOUT = 5000;
        private readonly IMapper _mapper;


        public RemoteServiceManager(IMapper mapper)
        {
            _mapper = mapper;
        }


        // SERVICE ////////////////////////////////////////////////////////////////////////////////
        public String ConnectionRequest()
        {
            return "Success!";
        }
        public ServiceInfo[] GetServices()
        {
            return _mapper.Map<ServiceInfo[]>(ServiceController.GetServices());
        }
        public ServiceInfo StartService(String serviceName)
        {
            var service = new ServiceController(serviceName);
            service.Start();
            service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(TIMEOUT));

            return _mapper.Map<ServiceInfo>(service);
        }
        public ServiceInfo StopService(String serviceName)
        {
            var service = new ServiceController(serviceName);
            service.Stop();
            service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds(TIMEOUT));

            return _mapper.Map<ServiceInfo>(service);
        }
    }
}