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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadService/GetDrivers", ReplyAction="http://tempuri.org/IReadService/GetDriversResponse")]
        System.Collections.Generic.List<WCFReadEntities.Driver> GetDrivers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadService/GetDrivers", ReplyAction="http://tempuri.org/IReadService/GetDriversResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<WCFReadEntities.Driver>> GetDriversAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadService/GetDriverById", ReplyAction="http://tempuri.org/IReadService/GetDriverByIdResponse")]
        WCFReadEntities.Driver GetDriverById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadService/GetDriverById", ReplyAction="http://tempuri.org/IReadService/GetDriverByIdResponse")]
        System.Threading.Tasks.Task<WCFReadEntities.Driver> GetDriverByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadService/GetAddresses", ReplyAction="http://tempuri.org/IReadService/GetAddressesResponse")]
        System.Collections.Generic.List<WCFReadEntities.Address> GetAddresses();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadService/GetAddresses", ReplyAction="http://tempuri.org/IReadService/GetAddressesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<WCFReadEntities.Address>> GetAddressesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadService/GetAddressById", ReplyAction="http://tempuri.org/IReadService/GetAddressByIdResponse")]
        WCFReadEntities.Address GetAddressById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadService/GetAddressById", ReplyAction="http://tempuri.org/IReadService/GetAddressByIdResponse")]
        System.Threading.Tasks.Task<WCFReadEntities.Address> GetAddressByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadService/GetFuelCards", ReplyAction="http://tempuri.org/IReadService/GetFuelCardsResponse")]
        System.Collections.Generic.List<WCFReadEntities.FuelCard> GetFuelCards();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadService/GetFuelCards", ReplyAction="http://tempuri.org/IReadService/GetFuelCardsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<WCFReadEntities.FuelCard>> GetFuelCardsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadService/GetFuelCardById", ReplyAction="http://tempuri.org/IReadService/GetFuelCardByIdResponse")]
        WCFReadEntities.FuelCard GetFuelCardById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadService/GetFuelCardById", ReplyAction="http://tempuri.org/IReadService/GetFuelCardByIdResponse")]
        System.Threading.Tasks.Task<WCFReadEntities.FuelCard> GetFuelCardByIdAsync(int id);
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
        
        public System.Collections.Generic.List<WCFReadEntities.Driver> GetDrivers() {
            return base.Channel.GetDrivers();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<WCFReadEntities.Driver>> GetDriversAsync() {
            return base.Channel.GetDriversAsync();
        }
        
        public WCFReadEntities.Driver GetDriverById(int id) {
            return base.Channel.GetDriverById(id);
        }
        
        public System.Threading.Tasks.Task<WCFReadEntities.Driver> GetDriverByIdAsync(int id) {
            return base.Channel.GetDriverByIdAsync(id);
        }
        
        public System.Collections.Generic.List<WCFReadEntities.Address> GetAddresses() {
            return base.Channel.GetAddresses();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<WCFReadEntities.Address>> GetAddressesAsync() {
            return base.Channel.GetAddressesAsync();
        }
        
        public WCFReadEntities.Address GetAddressById(int id) {
            return base.Channel.GetAddressById(id);
        }
        
        public System.Threading.Tasks.Task<WCFReadEntities.Address> GetAddressByIdAsync(int id) {
            return base.Channel.GetAddressByIdAsync(id);
        }
        
        public System.Collections.Generic.List<WCFReadEntities.FuelCard> GetFuelCards() {
            return base.Channel.GetFuelCards();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<WCFReadEntities.FuelCard>> GetFuelCardsAsync() {
            return base.Channel.GetFuelCardsAsync();
        }
        
        public WCFReadEntities.FuelCard GetFuelCardById(int id) {
            return base.Channel.GetFuelCardById(id);
        }
        
        public System.Threading.Tasks.Task<WCFReadEntities.FuelCard> GetFuelCardByIdAsync(int id) {
            return base.Channel.GetFuelCardByIdAsync(id);
        }
    }
}
