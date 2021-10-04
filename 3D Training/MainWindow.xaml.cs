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
        public MainWindow()
        {
            InitializeComponent();
            var scene = new Scene(Viewport);
            Viewport.BeginInit();
            Viewport.EndInit();
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
    }
}