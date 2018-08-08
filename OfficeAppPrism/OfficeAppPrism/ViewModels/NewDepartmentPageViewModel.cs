using System.Net.Http;
using OfficeApp.Models;
using Prism.Commands;
using System.Text;
using Java.Util.Jar;
using Prism.Navigation;
using Newtonsoft.Json;

namespace OfficeApp.ViewModels
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
            var newDepartment = new Department()
            {
                Name = NewName,
                Description = NewDescription,
                Head = NewHead,
                Code = NewCode
                
            };

            //And then serialize the objects before passing to to the http client 
            var content = JsonConvert.SerializeObject(newDepartment);
            await _client.PostAsync(Url, new StringContent(content, Encoding.UTF8, "application/json"));
            await NavigationService.GoBackAsync();


        }
    }
}
