using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using OfficeApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace OfficeApp.ViewModels
{
    public class EditDeleteDepartmentPageViewModel : ViewModelBase
    {
        private const string Url = "http://localhost:3000/departments/";
        private readonly HttpClient _client = new HttpClient();

        private Department _currentDepartment;

        public Department CurrentDepartment
        {
            get { return _currentDepartment; }
            set
            {
                _currentDepartment = value;
                RaisePropertyChanged();
            }
        }
        
        //constuctor 
        //<param name ="navigationService" 
        public EditDeleteDepartmentPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        //this loads/runs before the application is shown on the screen 
        //param name="parameters"

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("(^_^) keyAko"))
            {
                CurrentDepartment = (Department) parameters["(^_^) keyAko"]; 
            }
            base.OnNavigatingTo(parameters);
        }

        public DelegateCommand UpdateCommand => new DelegateCommand(Update);

        private  async void Update()
        {

            // json convert serialize the object before sending it to the web service 
           var content  = JsonConvert.SerializeObject(CurrentDepartment);
            await _client.PutAsync(Url + CurrentDepartment.Id,
                new StringContent(content, Encoding.UTF8, "application/json"));

            await NavigationService.GoBackAsync(); 

        }

        public DelegateCommand DeleteCommand => new DelegateCommand(Delete);

        private async void Delete()
        {
            await _client.DeleteAsync(Url + CurrentDepartment.Id);
            await NavigationService.GoBackAsync(); 
        }
    }




}
