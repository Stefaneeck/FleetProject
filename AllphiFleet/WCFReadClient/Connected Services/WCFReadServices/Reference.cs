﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFReadClient.WCFReadServices {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCFReadServices.IReadService")]
    public interface IReadService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadService/GetAddresses", ReplyAction="http://tempuri.org/IReadService/GetAddressesResponse")]
        System.Collections.Generic.List<WCFReadEntities.Address> GetAddresses();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadService/GetAddresses", ReplyAction="http://tempuri.org/IReadService/GetAddressesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<WCFReadEntities.Address>> GetAddressesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IReadServiceChannel : WCFReadClient.WCFReadServices.IReadService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReadServiceClient : System.ServiceModel.ClientBase<WCFReadClient.WCFReadServices.IReadService>, WCFReadClient.WCFReadServices.IReadService {
        
        public ReadServiceClient() {
        }
        
        public ReadServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ReadServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReadServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReadServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<WCFReadEntities.Address> GetAddresses() {
            return base.Channel.GetAddresses();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<WCFReadEntities.Address>> GetAddressesAsync() {
            return base.Channel.GetAddressesAsync();
        }
    }
}
