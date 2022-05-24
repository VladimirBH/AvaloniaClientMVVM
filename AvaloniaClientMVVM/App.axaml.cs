using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaClientMVVM.ViewModels;
using AvaloniaClientMVVM.Views;

namespace AvaloniaClientMVVM
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new SplashScreen()
                {
                    DataContext = new SplashScreenViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}