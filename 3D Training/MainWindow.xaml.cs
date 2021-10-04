using System.Windows;
using System.Windows.Input;

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
        }

        private bool _isMaximzed = false;
        private double _currentWidth = 1650;
        private double _currentHeight = 1050;
        private double _topPosition = 400;
        private double _leftPosition = 400;

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

        private void MinimizeWindow(object sender, MouseButtonEventArgs eventArgs)
        {
            if (!_isMaximzed)
            {
                _topPosition = Top;
                _leftPosition = Left;
                _currentWidth = Width;
                _currentHeight = Height;
                WindowState = WindowState.Maximized;
                Width = SystemParameters.WorkArea.Width;
                Height = SystemParameters.WorkArea.Height;
                return;
            }
            WindowState = WindowState.Minimized;    
            Width = _currentWidth;
            Height = _currentHeight;
            Top = _topPosition;
            Left = _leftPosition;
        }

        private void Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("yeehaw");
        }
    }
}