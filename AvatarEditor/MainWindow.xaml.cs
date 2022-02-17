using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace AvatarEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                avatarEditor1.Source = bitmap;

                AvatarEditorViewModel vm = new AvatarEditorViewModel(bitmap, avatarEditor1, 350, (im) =>
                {
                    //save avatar in vm
                    File.WriteAllBytes("avatar.png", im);
                    MessageBox.Show("Image saved");
                });
                avatarEditor1.InitAction = () => avatarEditor1.Source = vm.Avatar;

                //setup
                avatarEditor1.DataContext = vm;    
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            //save avatar
            var image = avatarEditor1.GetPngImage(350);
            File.WriteAllBytes("avatar.png", image);
            MessageBox.Show("Image saved");
        }
    }
}
