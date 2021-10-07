using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

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

        private void ImportFile(object sender, MouseButtonEventArgs eventArgs) => FileImportManager.ImportFile();

        private void ZoomCamera(object sender, RoutedPropertyChangedEventArgs<double> eventArgs)
        {
            _scene.ZoomCameraAlongLookDirection(eventArgs.NewValue);
            Viewport.InvalidateVisual();
        }
    }
}