using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Diagnostics;

namespace OpenTKWithAvalonia
{
    public partial class MainWindow : Window
    {
        private OpenGlUserControl _openGlControl;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _openGlControl = this.FindControl<OpenGlUserControl>("OpenGlControlHost");
            Debug.WriteLine("MainWindow Initialized");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            Debug.WriteLine("XAML Loaded");
        }

        private void OnButtonClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Debug.WriteLine("Button Clicked!");
            _openGlControl.ChangeBackgroundColor();
        }
    }
}
