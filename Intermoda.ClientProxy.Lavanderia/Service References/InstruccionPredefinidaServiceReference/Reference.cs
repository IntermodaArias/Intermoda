﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InstruccionPredefinidaBusiness", Namespace="http://schemas.datacontract.org/2004/07/Intermoda.Business.Lavanderia")]
    [System.SerializableAttribute()]
    public partial class InstruccionPredefinidaBusiness : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescripcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.OperacionPredefinidaBusiness OpeacionPredefinidaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OperacionPredefinidaIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OrdenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> TemperaturaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal TiempoMaximoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal TiempoMinimoField;
        
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
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.OperacionPredefinidaBusiness OpeacionPredefinida {
            get {
                return this.OpeacionPredefinidaField;
            }
            set {
                if ((object.ReferenceEquals(this.OpeacionPredefinidaField, value) != true)) {
                    this.OpeacionPredefinidaField = value;
                    this.RaisePropertyChanged("OpeacionPredefinida");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OperacionPredefinidaId {
            get {
                return this.OperacionPredefinidaIdField;
            }
            set {
                if ((this.OperacionPredefinidaIdField.Equals(value) != true)) {
                    this.OperacionPredefinidaIdField = value;
                    this.RaisePropertyChanged("OperacionPredefinidaId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Orden {
            get {
                return this.OrdenField;
            }
            set {
                if ((this.OrdenField.Equals(value) != true)) {
                    this.OrdenField = value;
                    this.RaisePropertyChanged("Orden");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Temperatura {
            get {
                return this.TemperaturaField;
            }
            set {
                if ((this.TemperaturaField.Equals(value) != true)) {
                    this.TemperaturaField = value;
                    this.RaisePropertyChanged("Temperatura");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal TiempoMaximo {
            get {
                return this.TiempoMaximoField;
            }
            set {
                if ((this.TiempoMaximoField.Equals(value) != true)) {
                    this.TiempoMaximoField = value;
                    this.RaisePropertyChanged("TiempoMaximo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal TiempoMinimo {
            get {
                return this.TiempoMinimoField;
            }
            set {
                if ((this.TiempoMinimoField.Equals(value) != true)) {
                    this.TiempoMinimoField = value;
                    this.RaisePropertyChanged("TiempoMinimo");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OperacionPredefinidaBusiness", Namespace="http://schemas.datacontract.org/2004/07/Intermoda.Business.Lavanderia")]
    [System.SerializableAttribute()]
    public partial class OperacionPredefinidaBusiness : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.OperacionBusiness OperacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OperacionIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RelacionBanoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SecuenciaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TemperaturaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal TiempoMaximoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal TiempoMinimoField;
        
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.OperacionBusiness Operacion {
            get {
                return this.OperacionField;
            }
            set {
                if ((object.ReferenceEquals(this.OperacionField, value) != true)) {
                    this.OperacionField = value;
                    this.RaisePropertyChanged("Operacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OperacionId {
            get {
                return this.OperacionIdField;
            }
            set {
                if ((this.OperacionIdField.Equals(value) != true)) {
                    this.OperacionIdField = value;
                    this.RaisePropertyChanged("OperacionId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Ph {
            get {
                return this.PhField;
            }
            set {
                if ((object.ReferenceEquals(this.PhField, value) != true)) {
                    this.PhField = value;
                    this.RaisePropertyChanged("Ph");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RelacionBano {
            get {
                return this.RelacionBanoField;
            }
            set {
                if ((this.RelacionBanoField.Equals(value) != true)) {
                    this.RelacionBanoField = value;
                    this.RaisePropertyChanged("RelacionBano");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Secuencia {
            get {
                return this.SecuenciaField;
            }
            set {
                if ((this.SecuenciaField.Equals(value) != true)) {
                    this.SecuenciaField = value;
                    this.RaisePropertyChanged("Secuencia");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Temperatura {
            get {
                return this.TemperaturaField;
            }
            set {
                if ((this.TemperaturaField.Equals(value) != true)) {
                    this.TemperaturaField = value;
                    this.RaisePropertyChanged("Temperatura");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal TiempoMaximo {
            get {
                return this.TiempoMaximoField;
            }
            set {
                if ((this.TiempoMaximoField.Equals(value) != true)) {
                    this.TiempoMaximoField = value;
                    this.RaisePropertyChanged("TiempoMaximo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal TiempoMinimo {
            get {
                return this.TiempoMinimoField;
            }
            set {
                if ((this.TiempoMinimoField.Equals(value) != true)) {
                    this.TiempoMinimoField = value;
                    this.RaisePropertyChanged("TiempoMinimo");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OperacionBusiness", Namespace="http://schemas.datacontract.org/2004/07/Intermoda.Business.Lavanderia")]
    [System.SerializableAttribute()]
    public partial class OperacionBusiness : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescripcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short GrupoIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LineaProduccionIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.OperacionPredefinidaBusiness OperacionPredefinidaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short OperacionTipoIdField;
        
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
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short GrupoId {
            get {
                return this.GrupoIdField;
            }
            set {
                if ((this.GrupoIdField.Equals(value) != true)) {
                    this.GrupoIdField = value;
                    this.RaisePropertyChanged("GrupoId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LineaProduccionId {
            get {
                return this.LineaProduccionIdField;
            }
            set {
                if ((this.LineaProduccionIdField.Equals(value) != true)) {
                    this.LineaProduccionIdField = value;
                    this.RaisePropertyChanged("LineaProduccionId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.OperacionPredefinidaBusiness OperacionPredefinida {
            get {
                return this.OperacionPredefinidaField;
            }
            set {
                if ((object.ReferenceEquals(this.OperacionPredefinidaField, value) != true)) {
                    this.OperacionPredefinidaField = value;
                    this.RaisePropertyChanged("OperacionPredefinida");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short OperacionTipoId {
            get {
                return this.OperacionTipoIdField;
            }
            set {
                if ((this.OperacionTipoIdField.Equals(value) != true)) {
                    this.OperacionTipoIdField = value;
                    this.RaisePropertyChanged("OperacionTipoId");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="InstruccionPredefinidaServiceReference.IInstruccionPredefinida")]
    public interface IInstruccionPredefinida {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInstruccionPredefinida/Update", ReplyAction="http://tempuri.org/IInstruccionPredefinida/UpdateResponse")]
        Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness Update(Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInstruccionPredefinida/Update", ReplyAction="http://tempuri.org/IInstruccionPredefinida/UpdateResponse")]
        System.Threading.Tasks.Task<Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness> UpdateAsync(Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInstruccionPredefinida/Delete", ReplyAction="http://tempuri.org/IInstruccionPredefinida/DeleteResponse")]
        void Delete(int instruccionPredefinidaId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInstruccionPredefinida/Delete", ReplyAction="http://tempuri.org/IInstruccionPredefinida/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(int instruccionPredefinidaId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInstruccionPredefinida/Get", ReplyAction="http://tempuri.org/IInstruccionPredefinida/GetResponse")]
        Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness Get(int instruccionPredefinidaId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInstruccionPredefinida/Get", ReplyAction="http://tempuri.org/IInstruccionPredefinida/GetResponse")]
        System.Threading.Tasks.Task<Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness> GetAsync(int instruccionPredefinidaId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInstruccionPredefinida/GetAll", ReplyAction="http://tempuri.org/IInstruccionPredefinida/GetAllResponse")]
        Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInstruccionPredefinida/GetAll", ReplyAction="http://tempuri.org/IInstruccionPredefinida/GetAllResponse")]
        System.Threading.Tasks.Task<Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInstruccionPredefinida/GetByOperacionPredefinida", ReplyAction="http://tempuri.org/IInstruccionPredefinida/GetByOperacionPredefinidaResponse")]
        Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness[] GetByOperacionPredefinida(int operacionPredefinidaId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInstruccionPredefinida/GetByOperacionPredefinida", ReplyAction="http://tempuri.org/IInstruccionPredefinida/GetByOperacionPredefinidaResponse")]
        System.Threading.Tasks.Task<Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness[]> GetByOperacionPredefinidaAsync(int operacionPredefinidaId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IInstruccionPredefinidaChannel : Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.IInstruccionPredefinida, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class InstruccionPredefinidaClient : System.ServiceModel.ClientBase<Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.IInstruccionPredefinida>, Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.IInstruccionPredefinida {
        
        public InstruccionPredefinidaClient() {
        }
        
        public InstruccionPredefinidaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public InstruccionPredefinidaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public InstruccionPredefinidaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public InstruccionPredefinidaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness Update(Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness model) {
            return base.Channel.Update(model);
        }
        
        public System.Threading.Tasks.Task<Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness> UpdateAsync(Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness model) {
            return base.Channel.UpdateAsync(model);
        }
        
        public void Delete(int instruccionPredefinidaId) {
            base.Channel.Delete(instruccionPredefinidaId);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(int instruccionPredefinidaId) {
            return base.Channel.DeleteAsync(instruccionPredefinidaId);
        }
        
        public Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness Get(int instruccionPredefinidaId) {
            return base.Channel.Get(instruccionPredefinidaId);
        }
        
        public System.Threading.Tasks.Task<Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness> GetAsync(int instruccionPredefinidaId) {
            return base.Channel.GetAsync(instruccionPredefinidaId);
        }
        
        public Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness[] GetByOperacionPredefinida(int operacionPredefinidaId) {
            return base.Channel.GetByOperacionPredefinida(operacionPredefinidaId);
        }
        
        public System.Threading.Tasks.Task<Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference.InstruccionPredefinidaBusiness[]> GetByOperacionPredefinidaAsync(int operacionPredefinidaId) {
            return base.Channel.GetByOperacionPredefinidaAsync(operacionPredefinidaId);
        }
    }
}