using BlazorTest.Services;
using Microsoft.AspNetCore.Components;
using ModelsStandard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Pages
{
    public partial class DriverDetail
    {
        //needed to be able to use driverid as parameter is the component razor page (@page "/driverdetail/{Id}")
        [Parameter]
        public string Id { get; set; }

        public Driver Driver { get; set; }

        [Inject]
        public IDriverDataReadService DriverDataReadService { get; set; }

        //executed when the component is initialized, lifecycle hook
        protected override async Task OnInitializedAsync()
        {

            Driver = await DriverDataReadService.GetDriverDetails(int.Parse(Id));
        }
    }
}
