using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeApp.Models;
using OfficeApp.Views;

namespace OfficeApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private const string Url = "http://localhost:3000/departments/"; //for Android emulators

        private readonly HttpClient _client = new HttpClient();

        private ObservableCollection<Department> _observableDepartments;

        public ObservableCollection<Department> ObservableDepartments
        {
            get { return _observableDepartments; }
            set
            {
                _observableDepartments = value;
                RaisePropertyChanged();
            }
        }   

        
        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
          
        }

        public DelegateCommand ToNewDepPageCommand => new DelegateCommand(ToNewDep);

        private void ToNewDep()
        {
            NavigationService.NavigateAsync("NewDepartmentPage");
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            //Microsoft.Net.Http from Nuget 
            var content = await _client.GetStringAsync(Url); //get the string content from webservice 
            var departments  = JsonConvert.DeserializeObject<List<Department>>(content);
            ObservableDepartments   = new ObservableCollection<Department>(departments); 

            base.OnNavigatedTo(parameters);
        }

        public DelegateCommand<Department> EditDeleteCommand => new DelegateCommand<Department>(EditDelete);

        private void EditDelete(Department objectToBePassed)
        {
            var tappedCell = objectToBePassed; 
            var variableToPass = new NavigationParameters();
            variableToPass.Add("(^_^) keyAko", tappedCell);

            NavigationService.NavigateAsync("EditDeleteDepartmentPage", variableToPass); 
        }

    }
}
