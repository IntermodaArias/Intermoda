using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight;
using Intermoda.Business.Crm.Entities;
using Intermoda.Client.DataService.Crm;
using Intermoda.Common;

namespace Intermoda.Crm.ViewModel
{
    public class TestViewModel : ViewModelBase
    {
        private IAcuerdoComercialDataService _acuerdoComercialDataService;

        #region Properties

        #region AcuerdoComercialList

        /// <summary>
        /// The <see cref="AcuerdoComercialList" /> property's name.
        /// </summary>
        public const string AcuerdoComercialListPropertyName = "AcuerdoComercialList";

        private ObservableCollection<AcuerdoComercial> _acuerdoComercialList;

        /// <summary>
        /// Sets and gets the AcuerdoComercialList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<AcuerdoComercial> AcuerdoComercialList
        {
            get
            {
                return _acuerdoComercialList;
            }

            set
            {
                if (_acuerdoComercialList == value)
                {
                    return;
                }

                _acuerdoComercialList = value;
                RaisePropertyChanged(AcuerdoComercialListPropertyName);
            }
        }

        #endregion

        #endregion

        #region Commands

        #endregion

        #region Constructor

        public TestViewModel(IAcuerdoComercialDataService acuerdoComercialDataService)
        {
            _acuerdoComercialDataService = acuerdoComercialDataService;
            LoadData();
        }

        #endregion

        #region Private Methods

        private void LoadData()
        {
            _acuerdoComercialDataService.GetAll(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        MessageBox.Show(Tools.ExceptionMessage(error));
                        return;
                    }
                    AcuerdoComercialList = new ObservableCollection<AcuerdoComercial>(lista);
                });
        }

        #endregion
    }
}