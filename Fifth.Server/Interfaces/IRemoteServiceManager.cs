using Fifth.Server.Models;
using System;
using System.ServiceModel;

namespace Fifth.Server.Interfaces
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    [ServiceKnownType(typeof(ServiceInfo))]
    public interface IRemoteServiceManager
    {
        [OperationContract]
        String ConnectionRequest();

        [OperationContract]
        ServiceInfo[] GetServices();

        [OperationContract]
        ServiceInfo StartService(String serviceName);

        [OperationContract]
        ServiceInfo StopService(String serviceName);
    }
}