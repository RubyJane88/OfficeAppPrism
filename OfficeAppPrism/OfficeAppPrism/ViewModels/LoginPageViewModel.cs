using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;

namespace OfficeApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase

    {
        //ToMainCommand is a button at the LoginPage Xaml
        public DelegateCommand ToMainCommand => new DelegateCommand(ToMain); 

        private void ToMain()
        {
            NavigationService.NavigateAsync("MainPage");
        }


        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
    
