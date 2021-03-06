﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Intermoda.ClientProxy.LbDatPro.LecturaServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LecturaCuponBusiness", Namespace="http://schemas.datacontract.org/2004/07/Intermoda.Business.LbDatPro")]
    [System.SerializableAttribute()]
    public partial class LecturaCuponBusiness : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ErrorIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorNameField;
        
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
        public int ErrorId {
            get {
                return this.ErrorIdField;
            }
            set {
                if ((this.ErrorIdField.Equals(value) != true)) {
                    this.ErrorIdField = value;
                    this.RaisePropertyChanged("ErrorId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorName {
            get {
                return this.ErrorNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorNameField, value) != true)) {
                    this.ErrorNameField = value;
                    this.RaisePropertyChanged("ErrorName");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LecturaServiceReference.ILecturas")]
    public interface ILecturas {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILecturas/ValidaUsuario", ReplyAction="http://tempuri.org/ILecturas/ValidaUsuarioResponse")]
        Intermoda.ClientProxy.LbDatPro.LecturaServiceReference.LecturaCuponBusiness ValidaUsuario(string usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILecturas/ValidaUsuario", ReplyAction="http://tempuri.org/ILecturas/ValidaUsuarioResponse")]
        System.Threading.Tasks.Task<Intermoda.ClientProxy.LbDatPro.LecturaServiceReference.LecturaCuponBusiness> ValidaUsuarioAsync(string usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILecturas/ProcesaCupon", ReplyAction="http://tempuri.org/ILecturas/ProcesaCuponResponse")]
        Intermoda.ClientProxy.LbDatPro.LecturaServiceReference.LecturaCuponBusiness ProcesaCupon(string usuario, string cupon);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILecturas/ProcesaCupon", ReplyAction="http://tempuri.org/ILecturas/ProcesaCuponResponse")]
        System.Threading.Tasks.Task<Intermoda.ClientProxy.LbDatPro.LecturaServiceReference.LecturaCuponBusiness> ProcesaCuponAsync(string usuario, string cupon);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILecturasChannel : Intermoda.ClientProxy.LbDatPro.LecturaServiceReference.ILecturas, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LecturasClient : System.ServiceModel.ClientBase<Intermoda.ClientProxy.LbDatPro.LecturaServiceReference.ILecturas>, Intermoda.ClientProxy.LbDatPro.LecturaServiceReference.ILecturas {
        
        public LecturasClient() {
        }
        
        public LecturasClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LecturasClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LecturasClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LecturasClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Intermoda.ClientProxy.LbDatPro.LecturaServiceReference.LecturaCuponBusiness ValidaUsuario(string usuario) {
            return base.Channel.ValidaUsuario(usuario);
        }
        
        public System.Threading.Tasks.Task<Intermoda.ClientProxy.LbDatPro.LecturaServiceReference.LecturaCuponBusiness> ValidaUsuarioAsync(string usuario) {
            return base.Channel.ValidaUsuarioAsync(usuario);
        }
        
        public Intermoda.ClientProxy.LbDatPro.LecturaServiceReference.LecturaCuponBusiness ProcesaCupon(string usuario, string cupon) {
            return base.Channel.ProcesaCupon(usuario, cupon);
        }
        
        public System.Threading.Tasks.Task<Intermoda.ClientProxy.LbDatPro.LecturaServiceReference.LecturaCuponBusiness> ProcesaCuponAsync(string usuario, string cupon) {
            return base.Channel.ProcesaCuponAsync(usuario, cupon);
        }
    }
}
