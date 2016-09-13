using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Common;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class MessageWindowViewModel : ViewModelBase
    {
        #region Properties
        
        #region Title

        /// <summary>
        /// The <see cref="Title" /> property's name.
        /// </summary>
        public const string TitlePropertyName = "Title";

        private string _title;

        /// <summary>
        /// Sets and gets the Title property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (_title == value)
                {
                    return;
                }

                _title = value;
                RaisePropertyChanged(TitlePropertyName);
            }
        }

        #endregion

        #region Message

        /// <summary>
        /// The <see cref="Message" /> property's name.
        /// </summary>
        public const string MessagePropertyName = "Message";

        private string _message;

        /// <summary>
        /// Sets and gets the Message property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Message
        {
            get
            {
                return _message;
            }

            set
            {
                if (_message == value)
                {
                    return;
                }

                _message = value;
                RaisePropertyChanged(MessagePropertyName);
            }
        }

        #endregion

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public MessageWindowViewModel(string title, string message)
        {
            if (IsInDesignMode)
            {
                Title = "Título del Mensaje";
                Message = Tools.LoremIpsun();
            }
            else
            {
                Title = title;
                Message = message;
            }

            RegisterCommands();
        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            ConfirmCommand = new RelayCommand(Confirm);
        }

        private void Confirm()
        {
            if (OnRequestClose != null)
                OnRequestClose(this, new EventArgs());
        }

        #endregion
    }
}