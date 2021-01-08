using BlazorTest.Services;
using Microsoft.AspNetCore.Components;
using ModelsStandard;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorTest.Pages
{
    public partial class DriverList
    {
		public IEnumerable<Driver> Drivers { get; set; }

		[Inject]
		public IDriverDataReadService DriverDataReadService { get; set; }

		//Can be used here due to adding builder.Services.AddScoped in program.cs
		//Indicates that the associated property should have a value injected from the service provider during initialization.
		[Inject]
		public HttpClient HttpClient { get; set; }

		//executed when the component is initialized, lifecycle hook
        protected override async Task OnInitializedAsync()
        {
			//most basic way for getting the data
			//var data = await HttpClient.GetFromJsonAsync<List<Driver>>("https://localhost:44334/api/chauffeur");

			Drivers = (await DriverDataReadService.GetAllDrivers()).ToList();
		
        }

	}
}
