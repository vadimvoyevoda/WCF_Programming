﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client_Mex_DiskInfo.DiskInfo {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MyDiskInfo", Namespace="http://schemas.datacontract.org/2004/07/Service_MyDiskInfo")]
    [System.SerializableAttribute()]
    public partial class MyDiskInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DiskNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.IO.DriveType DiskTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long FreeSpaceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long TotalSpaceField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DiskName {
            get {
                return this.DiskNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DiskNameField, value) != true)) {
                    this.DiskNameField = value;
                    this.RaisePropertyChanged("DiskName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.IO.DriveType DiskType {
            get {
                return this.DiskTypeField;
            }
            set {
                if ((this.DiskTypeField.Equals(value) != true)) {
                    this.DiskTypeField = value;
                    this.RaisePropertyChanged("DiskType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long FreeSpace {
            get {
                return this.FreeSpaceField;
            }
            set {
                if ((this.FreeSpaceField.Equals(value) != true)) {
                    this.FreeSpaceField = value;
                    this.RaisePropertyChanged("FreeSpace");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long TotalSpace {
            get {
                return this.TotalSpaceField;
            }
            set {
                if ((this.TotalSpaceField.Equals(value) != true)) {
                    this.TotalSpaceField = value;
                    this.RaisePropertyChanged("TotalSpace");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DiskInfo.IDiskInfo")]
    public interface IDiskInfo {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDiskInfo/DiskSpaces", ReplyAction="http://tempuri.org/IDiskInfo/DiskSpacesResponse")]
        Client_Mex_DiskInfo.DiskInfo.MyDiskInfo DiskSpaces(string diskName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDiskInfo/DiskSpaces", ReplyAction="http://tempuri.org/IDiskInfo/DiskSpacesResponse")]
        System.Threading.Tasks.Task<Client_Mex_DiskInfo.DiskInfo.MyDiskInfo> DiskSpacesAsync(string diskName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDiskInfo/Print", ReplyAction="http://tempuri.org/IDiskInfo/PrintResponse")]
        void Print(Client_Mex_DiskInfo.DiskInfo.MyDiskInfo mdi);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDiskInfo/Print", ReplyAction="http://tempuri.org/IDiskInfo/PrintResponse")]
        System.Threading.Tasks.Task PrintAsync(Client_Mex_DiskInfo.DiskInfo.MyDiskInfo mdi);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDiskInfoChannel : Client_Mex_DiskInfo.DiskInfo.IDiskInfo, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DiskInfoClient : System.ServiceModel.ClientBase<Client_Mex_DiskInfo.DiskInfo.IDiskInfo>, Client_Mex_DiskInfo.DiskInfo.IDiskInfo {
        
        public DiskInfoClient() {
        }
        
        public DiskInfoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DiskInfoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DiskInfoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DiskInfoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Client_Mex_DiskInfo.DiskInfo.MyDiskInfo DiskSpaces(string diskName) {
            return base.Channel.DiskSpaces(diskName);
        }
        
        public System.Threading.Tasks.Task<Client_Mex_DiskInfo.DiskInfo.MyDiskInfo> DiskSpacesAsync(string diskName) {
            return base.Channel.DiskSpacesAsync(diskName);
        }
        
        public void Print(Client_Mex_DiskInfo.DiskInfo.MyDiskInfo mdi) {
            base.Channel.Print(mdi);
        }
        
        public System.Threading.Tasks.Task PrintAsync(Client_Mex_DiskInfo.DiskInfo.MyDiskInfo mdi) {
            return base.Channel.PrintAsync(mdi);
        }
    }
}
