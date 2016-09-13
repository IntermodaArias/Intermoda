using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaTelaColorIntermodaEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private TelaColorIntermoda _telaColorIntermoda;
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

        #region ColorIntermodaId

        /// <summary>
        /// The <see cref="ColorIntermodaId" /> property's name.
        /// </summary>
        public const string ColorIntermodaIdPropertyName = "ColorIntermodaId";

        private int _colorIntermodaId;

        /// <summary>
        /// Sets and gets the ColorIntermodaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ColorIntermodaId
        {
            get
            {
                return _colorIntermodaId;
            }

            set
            {
                if (_colorIntermodaId == value)
                {
                    return;
                }

                _colorIntermodaId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(ColorIntermodaIdPropertyName);
            }
        }

        #endregion

        #region TelaId

        /// <summary>
        /// The <see cref="TelaId" /> property's name.
        /// </summary>
        public const string TelaIdPropertyName = "TelaId";

        private string _telaId;

        /// <summary>
        /// Sets and gets the TelaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TelaId
        {
            get
            {
                return _telaId;
            }

            set
            {
                if (_telaId == value)
                {
                    return;
                }

                _telaId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                GetCatalogo();
                RaisePropertyChanged(TelaIdPropertyName);
            }
        }

        #endregion

        #region CatalogoId

        /// <summary>
        /// The <see cref="CatalogoId" /> property's name.
        /// </summary>
        public const string CatalogoIdPropertyName = "CatalogoId";

        private int? catalogoId;

        /// <summary>
        /// Sets and gets the CatalogoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? CatalogoId
        {
            get
            {
                return catalogoId;
            }

            set
            {
                if (catalogoId == value)
                {
                    return;
                }

                catalogoId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(CatalogoIdPropertyName);
            }
        }

        #endregion

        #region ColorIntermodaList

        /// <summary>
        /// The <see cref="ColorIntermodaList" /> property's name.
        /// </summary>
        public const string ColorIntermodaListPropertyName = "ColorIntermodaList";

        private ObservableCollection<ColorIntermoda> _colorIntermodaList;

        /// <summary>
        /// Sets and gets the ColorIntermodaList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<ColorIntermoda> ColorIntermodaList
        {
            get
            {
                return _colorIntermodaList;
            }

            set
            {
                if (_colorIntermodaList == value)
                {
                    return;
                }

                _colorIntermodaList = value;
                RaisePropertyChanged(ColorIntermodaListPropertyName);
            }
        }

        #endregion

        #region TelaList

        /// <summary>
        /// The <see cref="TelaList" /> property's name.
        /// </summary>
        public const string TelaListPropertyName = "TelaList";

        private ObservableCollection<Tela> _telaList;

        /// <summary>
        /// Sets and gets the TelaList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Tela> TelaList
        {
            get
            {
                return _telaList;
            }

            set
            {
                if (_telaList == value)
                {
                    return;
                }

                _telaList = value;
                RaisePropertyChanged(TelaListPropertyName);
            }
        }

        #endregion

        #region CatalogoList

        /// <summary>
        /// The <see cref="CatalogoList" /> property's name.
        /// </summary>
        public const string CatalogoListPropertyName = "CatalogoList";

        private ObservableCollection<Catalogo> _catalogoListCatalogos;

        /// <summary>
        /// Sets and gets the CatalogoList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Catalogo> CatalogoList
        {
            get
            {
                return _catalogoListCatalogos;
            }

            set
            {
                if (_catalogoListCatalogos == value)
                {
                    return;
                }

                _catalogoListCatalogos = value;
                RaisePropertyChanged(CatalogoListPropertyName);
            }
        }

        #endregion

        #region Catalogo

        /// <summary>
        /// The <see cref="Catalogo" /> property's name.
        /// </summary>
        public const string CatalogoPropertyName = "Catalogo";

        private Catalogo _catalogo;

        /// <summary>
        /// Sets and gets the Catalogo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Catalogo Catalogo
        {
            get
            {
                return _catalogo;
            }

            set
            {
                if (_catalogo == value)
                {
                    return;
                }

                _catalogo = value;
                RaisePropertyChanged(CatalogoPropertyName);
            }
        }

        #endregion

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructior

        public LavanderiaTelaColorIntermodaEditViewModel(IDataServiceLavanderia dataService, IDialogService dialogService, TelaColorIntermoda telaColorIntermoda)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                _dataService.TelaColorIntermodaGet(1,
                    (reg, error) =>
                    {
                        if (error != null)
                        {
                            _dialogService.ShowException(error);
                            return;
                        }
                        _telaColorIntermoda = reg;
                    });
            }
            else
            {
                _telaColorIntermoda = telaColorIntermoda;
            }

            Id = _telaColorIntermoda.Id;
            ColorIntermodaId = _telaColorIntermoda.ColorIntermodaId;
            TelaId = _telaColorIntermoda.TelaId;
            CatalogoId = _telaColorIntermoda.MaterialId;
            
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
            _telaColorIntermoda.ColorIntermodaId = ColorIntermodaId;
            _telaColorIntermoda.TelaId = TelaId;
            _telaColorIntermoda.MaterialId = CatalogoId;

            _dataService.TelaColorIntermodaUpdate(_telaColorIntermoda,
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
            return _telaColorIntermoda.ColorIntermodaId != ColorIntermodaId ||
                   _telaColorIntermoda.TelaId != TelaId ||
                   _telaColorIntermoda.MaterialId != CatalogoId;
        }

        private void GetCatalogo()
        {
            _dataService.CatalogoGetByTela(TelaId,
                (reg, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    Catalogo = reg;
                });
        }

        #endregion
    }
}