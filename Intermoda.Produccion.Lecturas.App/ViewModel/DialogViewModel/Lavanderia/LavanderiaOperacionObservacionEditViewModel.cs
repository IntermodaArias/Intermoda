using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaOperacionObservacionEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private ObservacionPredefinida _observacionPredefinida;
        private readonly bool _init;

        #region Properties

        #region Id

        /// <summary>
        /// The <see cref="Id" /> property's name.
        /// </summary>
        public const string IdPropertyName = "Id";

        private int _id;

        /// <summary>
        /// Sets and gets the Id property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                RaisePropertyChanged(IdPropertyName);
            }
        }

        #endregion

        #region Descripcion

        /// <summary>
        /// The <see cref="Descripcion" /> property's name.
        /// </summary>
        public const string DescripcionPropertyName = "Descripcion";

        private string _descripcion;

        /// <summary>
        /// Sets and gets the Descripcion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                if (_descripcion == value)
                {
                    return;
                }

                _descripcion = value;
                RaisePropertyChanged(DescripcionPropertyName);
            }
        }

        #endregion

        #region OperacionId

        /// <summary>
        /// The <see cref="OperacionId" /> property's name.
        /// </summary>
        public const string OperacionIdPropertyName = "OperacionId";

        private int _operacionId;

        /// <summary>
        /// Sets and gets the OperacionId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OperacionId
        {
            get
            {
                return _operacionId;
            }

            set
            {
                if (_operacionId == value)
                {
                    return;
                }

                _operacionId = value;
                RaisePropertyChanged(OperacionIdPropertyName);
            }
        }

        #endregion

        #region Orden

        /// <summary>
        /// The <see cref="Orden" /> property's name.
        /// </summary>
        public const string OrdenPropertyName = "Orden";

        private int _orden;

        /// <summary>
        /// Sets and gets the Orden property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Orden
        {
            get
            {
                return _orden;
            }

            set
            {
                if (_orden == value)
                {
                    return;
                }

                _orden = value;
                RaisePropertyChanged(OrdenPropertyName);
            }
        }

        #endregion

        #region Posicion

        /// <summary>
        /// The <see cref="Posicion" /> property's name.
        /// </summary>
        public const string PosicionPropertyName = "Posicion";

        private int? _posicion;

        /// <summary>
        /// Sets and gets the Posicion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? Posicion
        {
            get
            {
                return _posicion;
            }

            set
            {
                if (_posicion == value)
                {
                    return;
                }

                _posicion = value;
                RaisePropertyChanged(PosicionPropertyName);
            }
        }

        #endregion

        //

        public Operacion Operacion { get; set; }

        //

        public List<Operacion> OperacionList { get; set; }

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public LavanderiaOperacionObservacionEditViewModel(IDataServiceLavanderia dataService,
            IDialogService dialogService, ObservacionPredefinida observacionPredefinida)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            
            _init = false;

            if (IsInDesignMode)
            {
                Id = 1;
                Descripcion = "Descripción de la Observación No. 000001";
                OperacionId = 1000;
                Orden = 10;
                Posicion = 10;
            }
            else
            {
                _observacionPredefinida = observacionPredefinida;
                Id = _observacionPredefinida.Id;
                Descripcion = _observacionPredefinida.Descripcion;
                OperacionId = _observacionPredefinida.OperacionId;
                Orden = _observacionPredefinida.Orden;
                Posicion = _observacionPredefinida.Posicion;
            }

            RegisterCommands();

            _init = true;
        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            CancelCommand = new RelayCommand(Cancel);
            ConfirmCommand = new RelayCommand(Confirm, CanConfirm);
        }

        private void Cancel()
        {
            if (OnRequestClose != null)
                OnRequestClose(this, new EventArgs());
        }

        private void Confirm()
        {
            _observacionPredefinida.Descripcion = Descripcion;
            _observacionPredefinida.OperacionId = OperacionId;
            _observacionPredefinida.Orden = Orden;
            _observacionPredefinida.Posicion = Posicion;

            _dataService.ObservacionPredefinidaUpdate(_observacionPredefinida,
                (updated, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    if (OnRequestClose != null)
                        OnRequestClose(this, new EventArgs());
                });
        }

        private bool CanConfirm()
        {
            return _observacionPredefinida.Descripcion != Descripcion ||
                   _observacionPredefinida.OperacionId != OperacionId ||
                   _observacionPredefinida.Orden != Orden ||
                   _observacionPredefinida.Posicion != Posicion;
        }

        #endregion
    }
}