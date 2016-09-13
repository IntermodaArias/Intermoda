using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lectura;
using Intermoda.Common;
using Intermoda.Common.Enum;
using Intermoda.Produccion.Lecturas.App.Helpers;
using Jornada = Intermoda.Client.Lectura.Jornada;
using TurnoDetalle = Intermoda.Client.Lectura.TurnoDetalle;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class TurnoDetalleEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLectura _dataService;
        private readonly IDialogService _dialogService;

        private TurnoDetalle  _turnoDetalle;
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
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(IdPropertyName);
            }
        }

        #endregion

        #region TurnoId

        /// <summary>
        /// The <see cref="TurnoId" /> property's name.
        /// </summary>
        public const string TurnoIdPropertyName = "TurnoId";

        private int _turnoId;

        /// <summary>
        /// Sets and gets the TurnoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int TurnoId
        {
            get
            {
                return _turnoId;
            }

            set
            {
                if (_turnoId == value)
                {
                    return;
                }

                _turnoId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(TurnoIdPropertyName);
            }
        }

        #endregion

        #region DiaInt

        /// <summary>
        /// The <see cref="DiaInt" /> property's name.
        /// </summary>
        public const string DiaIntPropertyName = "DiaInt";

        private int _diaInt;

        /// <summary>
        /// Sets and gets the DiaInt property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int DiaInt
        {
            get
            {
                return _diaInt;
            }

            set
            {
                if (_diaInt == value)
                {
                    return;
                }

                _diaInt = value;
                Dia = (DiaSemana) value;
                RaisePropertyChanged(DiaIntPropertyName);
            }
        }

        #endregion

        #region Dia

        /// <summary>
        /// The <see cref="Dia" /> property's name.
        /// </summary>
        public const string DiaPropertyName = "Dia";

        private DiaSemana _dia;

        /// <summary>
        /// Sets and gets the Dia property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DiaSemana Dia
        {
            get
            {
                return _dia;
            }

            set
            {
                if (_dia == value)
                {
                    return;
                }

                _dia = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(DiaPropertyName);
            }
        }

        #endregion

        #region JornadaId

        /// <summary>
        /// The <see cref="JornadaId" /> property's name.
        /// </summary>
        public const string JornadaIdPropertyName = "JornadaId";

        private int _jornadaId;

        /// <summary>
        /// Sets and gets the JornadaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int JornadaId
        {
            get
            {
                return _jornadaId;
            }

            set
            {
                if (_jornadaId == value)
                {
                    return;
                }

                _jornadaId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(JornadaIdPropertyName);
            }
        }

        #endregion

        #region JornadaList

        /// <summary>
        /// The <see cref="JornadaList" /> property's name.
        /// </summary>
        public const string JornadaListPropertyName = "JornadaList";

        private ObservableCollection<Jornada> _jornadaList;

        /// <summary>
        /// Sets and gets the JornadaList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Jornada> JornadaList
        {
            get
            {
                return _jornadaList;
            }

            set
            {
                if (_jornadaList == value)
                {
                    return;
                }

                _jornadaList = value;
                RaisePropertyChanged(JornadaListPropertyName);
            }
        }

        #endregion

        public List<EnumModel> DiaList { get; set; }

        //public List<Jornada> JornadaList { get; set; }

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public TurnoDetalleEditViewModel(IDataServiceLectura dataService, IDialogService dialogService, TurnoDetalle turnoDetalle)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _init = false;

            LoadCombos();

            if (IsInDesignMode)
            {
                Id = 1;
                TurnoId = 1000;
                Dia = DiaSemana.Miercoles;
                JornadaId = 2000;
                _turnoDetalle = new TurnoDetalle
                {
                    Id = Id,
                    TurnoId = TurnoId,
                    Dia = (ClientProxy.Lectura.TurnoDetalleServiceReference.DiaSemana) Dia,
                    JornadaId = JornadaId
                };
            }
            else
            {
                _turnoDetalle = turnoDetalle;
                Id = turnoDetalle.Id;
                TurnoId = turnoDetalle.TurnoId;
                Dia = (DiaSemana) turnoDetalle.Dia;
                JornadaId = turnoDetalle.JornadaId;
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

        private void LoadCombos()
        {
            _dataService.JornadaGetAll(
                (lista, error)=>
            {
                if (error != null)
                {
                    Tools.ExceptionMessage(error);
                    return;
                }
                JornadaList = new ObservableCollection<Jornada>(lista);
            });

            var enums = Enum.GetValues(typeof (DiaSemana));
            DiaList = (from object e in enums
                select new EnumModel
                {
                    Value = (int) e,
                    Name = e.ToString()
                }).ToList();
        }

        private void Cancel()
        {
            if (OnRequestClose != null)
                OnRequestClose(this, new EventArgs());
        }

        private void Confirm()
        {
            _turnoDetalle.TurnoId = TurnoId;
            _turnoDetalle.Dia = (ClientProxy.Lectura.TurnoDetalleServiceReference.DiaSemana) Dia;
            _turnoDetalle.JornadaId = JornadaId;

            _dataService.TurnoDetalleUpdate(_turnoDetalle,
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
            return _turnoDetalle.TurnoId != TurnoId ||
                   _turnoDetalle.Dia != (ClientProxy.Lectura.TurnoDetalleServiceReference.DiaSemana) Dia ||
                   _turnoDetalle.JornadaId != JornadaId;
        }

        #endregion
    }
}