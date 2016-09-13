using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Intermoda.Client.DataService.LbDatPro;
using Intermoda.Client.LbDatPro;
using Intermoda.Common;
using Intermoda.Reports;
using Telerik.Reporting;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class ReportTestViewModel : ViewModelBase
    {
        private IDataServiceLbDatPro _dataService;

        #region Properties

        #region Report

        /// <summary>
        /// The <see cref="Report" /> property's name.
        /// </summary>
        public const string ReportPropertyName = "Report";

        private Test01 _report;

        /// <summary>
        /// Sets and gets the Report property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Test01 Report
        {
            get
            {
                return _report;
            }

            set
            {
                if (_report == value)
                {
                    return;
                }

                _report = value;
                RaisePropertyChanged(ReportPropertyName);
            }
        }

        #endregion

        #region EmpleadoList

        /// <summary>
        /// The <see cref="EmpleadoList" /> property's name.
        /// </summary>
        public const string EmpleadoListPropertyName = "EmpleadoList";

        private ObservableCollection<Empleado> _empleadoList;

        /// <summary>
        /// Sets and gets the EmpleadoList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Empleado> EmpleadoList
        {
            get
            {
                return _empleadoList;
            }

            set
            {
                if (_empleadoList == value)
                {
                    return;
                }

                _empleadoList = value;
                RaisePropertyChanged(EmpleadoListPropertyName);
            }
        }

        #endregion

        #endregion

        #region Commands

        #endregion

        #region Constructor

        public ReportTestViewModel(IDataServiceLbDatPro dataService)
        {
            _dataService = dataService;

            Load();
        }

        #endregion

        #region Methods

        private void Load()
        {
            _dataService.EmpleadoGetAllActivos(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    EmpleadoList = new ObservableCollection<Empleado>(lista);
                    Report = new Test01();
                    //{
                    //    DataSource = EmpleadoList
                    //};
                    var typeReportSource = new TypeReportSource {TypeName = GetType().AssemblyQualifiedName};
                });


        }

        #endregion
    }
}