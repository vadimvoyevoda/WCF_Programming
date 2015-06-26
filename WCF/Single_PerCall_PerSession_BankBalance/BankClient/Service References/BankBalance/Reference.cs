﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankClient.BankBalance {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BankBalance.IBankBalance")]
    public interface IBankBalance {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankBalance/ToBalance", ReplyAction="http://tempuri.org/IBankBalance/ToBalanceResponse")]
        void ToBalance(double sum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankBalance/ToBalance", ReplyAction="http://tempuri.org/IBankBalance/ToBalanceResponse")]
        System.Threading.Tasks.Task ToBalanceAsync(double sum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankBalance/getBalance", ReplyAction="http://tempuri.org/IBankBalance/getBalanceResponse")]
        double getBalance();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankBalance/getBalance", ReplyAction="http://tempuri.org/IBankBalance/getBalanceResponse")]
        System.Threading.Tasks.Task<double> getBalanceAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBankBalanceChannel : BankClient.BankBalance.IBankBalance, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BankBalanceClient : System.ServiceModel.ClientBase<BankClient.BankBalance.IBankBalance>, BankClient.BankBalance.IBankBalance {
        
        public BankBalanceClient() {
        }
        
        public BankBalanceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BankBalanceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BankBalanceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BankBalanceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void ToBalance(double sum) {
            base.Channel.ToBalance(sum);
        }
        
        public System.Threading.Tasks.Task ToBalanceAsync(double sum) {
            return base.Channel.ToBalanceAsync(sum);
        }
        
        public double getBalance() {
            return base.Channel.getBalance();
        }
        
        public System.Threading.Tasks.Task<double> getBalanceAsync() {
            return base.Channel.getBalanceAsync();
        }
    }
}
