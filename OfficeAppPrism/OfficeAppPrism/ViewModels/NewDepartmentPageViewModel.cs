using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using OfficeAppPrism.Models;
using Prism.Mvvm;
using Prism.Navigation;

namespace OfficeAppPrism.ViewModels
{
    public class NewDepartmentPageViewModel : ViewModelBase
    {
        private const string Url = "http://localhost:3000/departments/";
        private readonly HttpClient _client = new HttpClient();

        public string NewName { get; set; }
        public string NewDescription { get; set; }
        public string NewHead { get; set; }
        public string NewCode { get; set; }


        public NewDepartmentPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private async void Save() //Binding SaveCommand Button at XAML 
        {
            var newDepartment = new Department();
            {
             
                        // Name = NewName 
            }
            
            //And then serialize the objects before passing to to the http client 



        }
    }
}
