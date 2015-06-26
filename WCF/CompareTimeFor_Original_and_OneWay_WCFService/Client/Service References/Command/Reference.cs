﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.Command {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Command.ICommand")]
    public interface ICommand {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICommand/SaveCommandOneWay")]
        void SaveCommandOneWay(string commandName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICommand/SaveCommandOneWay")]
        System.Threading.Tasks.Task SaveCommandOneWayAsync(string commandName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommand/SaveCommand", ReplyAction="http://tempuri.org/ICommand/SaveCommandResponse")]
        void SaveCommand(string commandName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommand/SaveCommand", ReplyAction="http://tempuri.org/ICommand/SaveCommandResponse")]
        System.Threading.Tasks.Task SaveCommandAsync(string commandName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICommandChannel : Client.Command.ICommand, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CommandClient : System.ServiceModel.ClientBase<Client.Command.ICommand>, Client.Command.ICommand {
        
        public CommandClient() {
        }
        
        public CommandClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CommandClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommandClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommandClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void SaveCommandOneWay(string commandName) {
            base.Channel.SaveCommandOneWay(commandName);
        }
        
        public System.Threading.Tasks.Task SaveCommandOneWayAsync(string commandName) {
            return base.Channel.SaveCommandOneWayAsync(commandName);
        }
        
        public void SaveCommand(string commandName) {
            base.Channel.SaveCommand(commandName);
        }
        
        public System.Threading.Tasks.Task SaveCommandAsync(string commandName) {
            return base.Channel.SaveCommandAsync(commandName);
        }
    }
}
