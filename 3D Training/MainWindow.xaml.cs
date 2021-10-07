using _3D_Training.FileImporter;
using System.Windows;
using System.Windows.Input;

namespace _3D_Training
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Scene _scene;

        public MainWindow()
        {
            InitializeComponent();
            _scene = new Scene(Viewport);
            _scene.CreateDefaultScene();
            Viewport.InvalidateVisual();
        }

        private void DragWindow(object sender, MouseButtonEventArgs eventArgs)
        {
            if (eventArgs.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void CloseWindow(object sender, MouseButtonEventArgs eventArgs)
        {
            if (eventArgs.ChangedButton == MouseButton.Left)
                Close();
        }

        private void ImportFile(object sender, MouseButtonEventArgs eventArgs)
        {
            var stream = FileImportManager.ImportFile();
            if (stream != null)
                _scene.AddToScene(ObjParser.ParseIntoGeometryModel(stream));
        }

        private void ZoomCamera(object sender, RoutedPropertyChangedEventArgs<double> eventArgs)
        {
            _scene.ZoomCameraAlongLookDirection(eventArgs.NewValue);
            Viewport.InvalidateVisual();
        }

        private void HorizontalRotateCamera(object sender, RoutedPropertyChangedEventArgs<double> eventArgs)
        {
            _scene.PanCameraHorizontal(eventArgs.NewValue);
            Viewport.InvalidateVisual();
        }

        private void VerticalRotateCamera(object sender, RoutedPropertyChangedEventArgs<double> eventArgs)
        {
            _scene.PanCameraVertical(eventArgs.NewValue);
            Viewport.InvalidateVisual();
        }
    }
}