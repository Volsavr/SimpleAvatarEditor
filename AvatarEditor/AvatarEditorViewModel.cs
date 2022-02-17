using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace AvatarEditor
{
    public class AvatarEditorViewModel
    {
        #region Fields
        private UserControl _control;
        private int _resultSizeOfAvatar;
        private AvatarEditCompletedPostAction _avatarEditCompletedPostAction;

        /// <summary>
        /// Action that will be executed after successful avatar editing.
        /// avatarData: byte array which represent data of png image 
        /// </summary>
        /// <param name="avatarData"></param>
        public delegate void AvatarEditCompletedPostAction(byte[] avatarData);
        #endregion

        #region Constructor
        public AvatarEditorViewModel(BitmapImage avatarData, UserControl control, int resultSizeOfAvatar, AvatarEditCompletedPostAction avatarEditCompletedPostAction)
        {
            _control = control;
            _resultSizeOfAvatar = resultSizeOfAvatar;
            _avatarEditCompletedPostAction = avatarEditCompletedPostAction;
            LoadAvatar(avatarData);
            CreateCommands();
        }
        #endregion

        #region Properties
        public BitmapImage Avatar { get; private set; }
        #endregion

        #region Commands
        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public ICommand ScaleUpCommand { get; private set; }
        public ICommand ScaleDownCommand { get; private set; }
        #endregion

        #region Private Methods
        private void CreateCommands()
        {
            SaveCommand = new RelayCommand((obj) =>
            {
                var avatarData = (_control as AvatarEditorControl).GetPngImage(_resultSizeOfAvatar);
                _avatarEditCompletedPostAction(avatarData);
            });

            ScaleUpCommand = new RelayCommand((obj) =>
            {
                (_control as AvatarEditorControl).ScaleUpInCenter();
            });

            ScaleDownCommand = new RelayCommand((obj) =>
            {
                (_control as AvatarEditorControl).ScaleDownInCenter();
            });

            CancelCommand = new RelayCommand((obj) =>
            {
            });
        }

        private void LoadAvatar(BitmapImage avatarData)
        {
            /*BitmapImage bitmapImage = null;

            if (avatarData != null)
            {
                //decode image
                try
                {
                    var strmImg = new MemoryStream(avatarData);
                    bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = strmImg;
                    bitmapImage.DecodePixelWidth = 600;
                    bitmapImage.EndInit();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            */
            Avatar = avatarData;
            OnPropertyChanged(nameof(Avatar));
        }
        #endregion

        #region INotifyPropertyChanged
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
