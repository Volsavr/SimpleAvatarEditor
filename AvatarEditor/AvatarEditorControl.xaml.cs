using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AvatarEditor
{
    /// <summary>
    /// Interaction logic for AvatarEditorControl.xaml
    /// </summary>
    public partial class AvatarEditorControl : UserControl
    {
        #region Fields
        private Point _pressedMouse;
        private int _currentScaleIndex = 1;

        private const int MaxScaleIndex = 20;
        private const int MinScaleIndex = 1;
        private const int ResultImageSize = 370; // size of image after rendering (size of crop visual element) 

        //variables to store the offset values
        double relX;
        double relY;
        #endregion

        #region Constructor
        public AvatarEditorControl()
        {
            DataContextChanged += AvatarEditorControl_DataContextChanged;
            InitializeComponent();
        }

        private void AvatarEditorControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            InitAction();
        }

        #endregion

        #region Properties
        public Action InitAction { get; set; }
        #endregion

        #region EventHandlers
        private void Image_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + e.DeltaManipulation.Translation.Y * (-1));
            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + e.DeltaManipulation.Translation.X * (-1));
        }

        private void Image_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            // Set our container to this image which will allow
            // us to apply the transforms to the image in the other 
            // Manipulation Events
            e.ManipulationContainer = this.image;
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point mouse = matrixTransform.Inverse.Transform(e.GetPosition(this));
                Vector delta = Point.Subtract(mouse, _pressedMouse); // delta from old mouse to current mouse
                _pressedMouse = mouse;
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + delta.Y * (-1));
                scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + delta.X * (-1));
            }
        }

        private void Image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;

            if (e.Delta < 0 && _currentScaleIndex == MinScaleIndex)
                return;

            if (e.Delta > 0 && _currentScaleIndex == MaxScaleIndex)
                return;

            Point mouse = matrixTransform.Inverse.Transform(e.GetPosition(this));

            if (e.Delta < 0)
            {
                ScaleDown(mouse.X, mouse.Y);
            }
            else
            {
                ScaleUp(mouse.X, mouse.Y);
            }

            slider.Value = _currentScaleIndex;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Cursor = Cursors.ScrollAll;
            _pressedMouse = matrixTransform.Inverse.Transform(e.GetPosition(this));
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var oldValue = (int)e.OldValue;
            var newValue = (int)e.NewValue;

            if (newValue == _currentScaleIndex)
                return;

            if (newValue == oldValue)
                return;

            if (newValue < oldValue && _currentScaleIndex == MinScaleIndex)
                return;

            if (newValue > oldValue && _currentScaleIndex == MaxScaleIndex)
                return;

            Point center = new Point(
             image.RenderSize.Width / 2.0,
             image.RenderSize.Height / 2.0);

            if (newValue < oldValue)
            {
                ScaleDown(center.X, center.Y);
            }
            else
            {
                ScaleUp(center.X, center.Y);
            }
        }

        private void scrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollViewer scroll = sender as ScrollViewer;
            //see if the content size is changed
            if (e.ExtentWidthChange != 0 || e.ExtentHeightChange != 0)
            {
                //calculate and set accordingly
                scroll.ScrollToHorizontalOffset(CalculateOffset(e.ExtentWidth, e.ViewportWidth, scroll.ScrollableWidth, relX));
                scroll.ScrollToVerticalOffset(CalculateOffset(e.ExtentHeight, e.ViewportHeight, scroll.ScrollableHeight, relY));
            }
            else
            {
                //store the relative values if normal scroll
                relX = (e.HorizontalOffset + 0.5 * e.ViewportWidth) / e.ExtentWidth;
                relY = (e.VerticalOffset + 0.5 * e.ViewportHeight) / e.ExtentHeight;
            }
        }
        #endregion

        #region Private Methods
        private void InitialScale(ImageSource imageSource)
        {
            if (imageSource == null)
                return;

            //NOTE: Initial scale
            /*double viewBoxWidth, viewboxHeight = 0;

            if (imageSource.Width >= imageSource.Height)
            {
                viewBoxWidth = 370;
                viewboxHeight = imageSource.Height * 370 / imageSource.Width;
            }
            else
            {
                viewboxHeight = 370;
                viewBoxWidth = imageSource.Width * 370 / imageSource.Height;
            }

            Matrix matrix = new Matrix();
            matrix.ScaleAt(1.61051, 1.61051, viewBoxWidth / 2, viewboxHeight / 2);
            matrixTransform.Matrix = matrix;*/
            _currentScaleIndex = 1;
            slider.Value = 1;
        }

        private void ResetScale()
        {
            Matrix matrix = matrixTransform.Matrix;
            matrix.M11 = 1;
            matrix.M12 = 0;
            matrix.M21 = 0;
            matrix.M22 = 1;
            matrix.OffsetX = 0;
            matrix.OffsetY = 0;
            Canvas.SetLeft(image, 0);
            Canvas.SetTop(image, 0);
            matrixTransform.Matrix = matrix;
            slider.Value = 1;
            _currentScaleIndex = 1;
        }

        private void ScaleUp(double x, double y)
        {
            _currentScaleIndex++;

            float scale = 1.05f;
            Matrix matrix = matrixTransform.Matrix;
            matrix.ScaleAt(scale, scale, x, y);
            matrixTransform.Matrix = matrix;

            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset * scale);
            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset * scale);
        }

        private void ScaleDown(double x, double y)
        {
            _currentScaleIndex--;

            float scale = 1f / 1.05f;

            Matrix matrix = matrixTransform.Matrix;
            matrix.ScaleAt(scale, scale, x, y);
            matrixTransform.Matrix = matrix;

            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset * scale);
            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset * scale);
        }

        #endregion

        #region Static functions
        private static BitmapFrame CreateResizedImage(ImageSource source, int width, int height, int margin)
        {
            var rect = new Rect(margin, margin, width - margin * 2, height - margin * 2);

            var group = new DrawingGroup();
            RenderOptions.SetBitmapScalingMode(group, BitmapScalingMode.HighQuality);
            group.Children.Add(new ImageDrawing(source, rect));

            var drawingVisual = new DrawingVisual();
            using (var drawingContext = drawingVisual.RenderOpen())
                drawingContext.DrawDrawing(group);

            var resizedImage = new RenderTargetBitmap(
                width, height,         // Resized dimensions
                96, 96,                // Default DPI values
                PixelFormats.Default); // Default pixel format
            resizedImage.Render(drawingVisual);

            return BitmapFrame.Create(resizedImage);
        }

        private static double CalculateOffset(double extent, double viewPort, double scrollWidth, double relBefore)
        {
            //calculate the new offset
            double offset = relBefore * extent - 0.5 * viewPort;
            //see if it is negative because of initial values
            if (offset < 0)
            {
                //center the content
                //this can be set to 0 if center by default is not needed
                offset = 0.5 * scrollWidth;
            }
            return offset;
        }
        #endregion

        #region Public Methods
        public byte[] GetPngImage(int size)
        {
            //render
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)scrollViewer.ActualWidth, (int)scrollViewer.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(scrollViewer);

            //resize
            var scaleFactor = (float)size / (float)ResultImageSize;
            var resizedBitmap = new TransformedBitmap(rtb, new ScaleTransform(scaleFactor, scaleFactor));

            // Encoding the RenderBitmapTarget as a PNG file
            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(resizedBitmap));

            // Save it to memory
            MemoryStream stream = new MemoryStream();
            png.Save(stream);

            //Convert to array
            var data = stream.ToArray();
            stream.Close();

            return data;
        }

        public void ScaleUpInCenter()
        {
            if (_currentScaleIndex == MaxScaleIndex)
                return;

            Point center = new Point(
            image.RenderSize.Width / 2.0,
            image.RenderSize.Height / 2.0);

            ScaleUp(center.X, center.Y);

            slider.Value = _currentScaleIndex;
        }

        public void ScaleDownInCenter()
        {
            if (_currentScaleIndex == MinScaleIndex)
                return;

            Point center = new Point(
            image.RenderSize.Width / 2.0,
            image.RenderSize.Height / 2.0);

            ScaleDown(center.X, center.Y);

            slider.Value = _currentScaleIndex;
        }
        #endregion

        #region DependencyProperty Source
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // A dependency property definition
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register(
                "Source", // Name of the dependency property
                typeof(ImageSource), // Type of the dependency property
                typeof(AvatarEditorControl), // Type of the owner
                new PropertyMetadata(
                   null, // The default value of the dependency property
                   new PropertyChangedCallback(OnSourceChanged))); // Callback when the property changes


        // The value changed callback 
        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            /* Called every time the dependency property value changes */
            AvatarEditorControl control = d as AvatarEditorControl;

            if (control == null)
                return;

            var imageSource = (ImageSource)e.NewValue;

            var containerWidth = control.scrollViewer.ActualWidth;
            var containerHeight = control.scrollViewer.ActualHeight;

            ImageSource newSource;
            if (imageSource.Width <= imageSource.Height)
            {
                var newHeight = imageSource.Height * containerWidth / imageSource.Width;
                newSource = CreateResizedImage(imageSource, (int)containerWidth, (int)newHeight, 0);
            }
            else
            {
                var newWidth = imageSource.Width * containerHeight / imageSource.Height;
                newSource = CreateResizedImage(imageSource, (int)newWidth, (int)containerHeight, 0);
            }

            control.ResetScale();
            control.image.Source = newSource;
            control.InitialScale(newSource);
        }
        #endregion
    }
}
