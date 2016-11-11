using System;
using System.Runtime.Serialization;

namespace Fifth.Server.Models
{
    [DataContract]
    public class ServiceInfo
    {
        [DataMember]
        public String DisplayName { get; set; }

        [DataMember]
        public String ServiceName { get; set; }

        [DataMember]
        public String Status { get; set; }

        [DataMember]
        public Boolean CanStop { get; set; }
    }
}