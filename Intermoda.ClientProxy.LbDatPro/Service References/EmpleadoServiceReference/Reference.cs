﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Intermoda.ClientProxy.LbDatPro.EmpleadoServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EmpleadoBusiness", Namespace="http://schemas.datacontract.org/2004/07/Intermoda.Business.LbDatPro")]
    [System.SerializableAttribute()]
    public partial class EmpleadoBusiness : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AliasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApellidosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CodigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short CompaniaCodigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EstadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombresField;
        
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
        public string Alias {
            get {
                return this.AliasField;
            }
            set {
                if ((object.ReferenceEquals(this.AliasField, value) != true)) {
                    this.AliasField = value;
                    this.RaisePropertyChanged("Alias");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Apellidos {
            get {
                return this.ApellidosField;
            }
            set {
                if ((object.ReferenceEquals(this.ApellidosField, value) != true)) {
                    this.ApellidosField = value;
                    this.RaisePropertyChanged("Apellidos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Codigo {
            get {
                return this.CodigoField;
            }
            set {
                if ((this.CodigoField.Equals(value) != true)) {
                    this.CodigoField = value;
                    this.RaisePropertyChanged("Codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short CompaniaCodigo {
            get {
                return this.CompaniaCodigoField;
            }
            set {
                if ((this.CompaniaCodigoField.Equals(value) != true)) {
                    this.CompaniaCodigoField = value;
                    this.RaisePropertyChanged("CompaniaCodigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Estado {
            get {
                return this.EstadoField;
            }
            set {
                if ((object.ReferenceEquals(this.EstadoField, value) != true)) {
                    this.EstadoField = value;
                    this.RaisePropertyChanged("Estado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombres {
            get {
                return this.NombresField;
            }
            set {
                if ((object.ReferenceEquals(this.NombresField, value) != true)) {
                    this.NombresField = value;
                    this.RaisePropertyChanged("Nombres");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmpleadoServiceReference.IEmpleado")]
    public interface IEmpleado {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmpleado/Get", ReplyAction="http://tempuri.org/IEmpleado/GetResponse")]
        Intermoda.ClientProxy.LbDatPro.EmpleadoServiceReference.EmpleadoBusiness Get(short companiaCodigo, int empleadoId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmpleado/Get", ReplyAction="http://tempuri.org/IEmpleado/GetResponse")]
        System.Threading.Tasks.Task<Intermoda.ClientProxy.LbDatPro.EmpleadoServiceReference.EmpleadoBusiness> GetAsync(short companiaCodigo, int empleadoId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmpleado/GetAllActivos", ReplyAction="http://tempuri.org/IEmpleado/GetAllActivosResponse")]
        Intermoda.ClientProxy.LbDatPro.EmpleadoServiceReference.EmpleadoBusiness[] GetAllActivos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmpleado/GetAllActivos", ReplyAction="http://tempuri.org/IEmpleado/GetAllActivosResponse")]
        System.Threading.Tasks.Task<Intermoda.ClientProxy.LbDatPro.EmpleadoServiceReference.EmpleadoBusiness[]> GetAllActivosAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmpleadoChannel : Intermoda.ClientProxy.LbDatPro.EmpleadoServiceReference.IEmpleado, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmpleadoClient : System.ServiceModel.ClientBase<Intermoda.ClientProxy.LbDatPro.EmpleadoServiceReference.IEmpleado>, Intermoda.ClientProxy.LbDatPro.EmpleadoServiceReference.IEmpleado {
        
        public EmpleadoClient() {
        }
        
        public EmpleadoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmpleadoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmpleadoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmpleadoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Intermoda.ClientProxy.LbDatPro.EmpleadoServiceReference.EmpleadoBusiness Get(short companiaCodigo, int empleadoId) {
            return base.Channel.Get(companiaCodigo, empleadoId);
        }
        
        public System.Threading.Tasks.Task<Intermoda.ClientProxy.LbDatPro.EmpleadoServiceReference.EmpleadoBusiness> GetAsync(short companiaCodigo, int empleadoId) {
            return base.Channel.GetAsync(companiaCodigo, empleadoId);
        }
        
        public Intermoda.ClientProxy.LbDatPro.EmpleadoServiceReference.EmpleadoBusiness[] GetAllActivos() {
            return base.Channel.GetAllActivos();
        }
        
        public System.Threading.Tasks.Task<Intermoda.ClientProxy.LbDatPro.EmpleadoServiceReference.EmpleadoBusiness[]> GetAllActivosAsync() {
            return base.Channel.GetAllActivosAsync();
        }
    }
}