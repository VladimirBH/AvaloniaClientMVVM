using System;
using System.Reactive;
using System.Windows.Input;
using AvaloniaClientMetal.Models;
using AvaloniaClientMVVM.Models;
using AvaloniaClientMVVM.Views;
using MessageBox.Avalonia.Enums;
using ReactiveUI;

namespace AvaloniaClientMVVM.ViewModels;

public class SplashScreenViewModel : ViewModelBase
{
    private DelegateCommand _openedWindowEvent;
    public SplashScreenViewModel()
    {
        _openedWindowEvent = new DelegateCommand(x => LoadingApplication());
    }

    public DelegateCommand OpenedWindowEvent
    {
        get => _openedWindowEvent;
        set
        {
            if (value == _openedWindowEvent) return;
            _openedWindowEvent = value;
            OnPropertyChanged(nameof(OpenedWindowEvent));
        }
    }


    private static async void LoadingApplication()
    {
        try
        {
            PreparedLocalStorage.LoadLocalStorage();
            TokenPair tokenPair = PreparedLocalStorage.GetTokenPairFromLocalStorage();
            tokenPair = await UserImplementation.RefreshTokenPair(tokenPair.RefreshToken);
            PreparedLocalStorage.PutTokenPairFromLocalStorage(tokenPair);
            KeepRoleId.RoleId = tokenPair.IdRole;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        catch (Exception ex)
        {
            var messageBox = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Успех",
                ex.Message+"\t", ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Success);
            await messageBox.Show();
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
        }
    }
    
}