using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Intermoda.Produccion.Lecturas.App.Messages;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class TabItemHeaderViewModel : ViewModelBase
    {
        public int Id { get; set; }

        #region Properties
        
        #region HeaderText

        /// <summary>
        /// The <see cref="HeaderText" /> property's name.
        /// </summary>
        public const string HeaderTextPropertyName = "HeaderText";

        private string _headerText;

        /// <summary>
        /// Sets and gets the HeaderText property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string HeaderText
        {
            get
            {
                return _headerText;
            }

            set
            {
                if (_headerText == value)
                {
                    return;
                }

                _headerText = value;
                RaisePropertyChanged(HeaderTextPropertyName);
            }
        }

        #endregion

        #endregion

        #region Commands

        public RelayCommand CloseTabItemCommand { get; set; }

        #endregion

        #region Constructor

        public TabItemHeaderViewModel()
        {
            RegisterCommands();
        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            CloseTabItemCommand = new RelayCommand(CloseTabItem);
        }

        private void CloseTabItem()
        {
            Messenger.Default.Send((new TablItemCloseMessage(Id)));
        }

        #endregion
    }
}