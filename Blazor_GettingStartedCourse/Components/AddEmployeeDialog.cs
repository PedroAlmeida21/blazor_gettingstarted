using BethanysPieShopHRM.Shared;
using Blazor_GettingStartedCourse.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Blazor_GettingStartedCourse.Components
{
    public partial class AddEmployeeDialog
    {
        [Inject]
        private IEmployeeDataService EmployeeDataService { get; set; }
        public Employee Employee { get; set; } = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
        public bool ShowDialog { get; set; } = false;
        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
        }

        public async Task HandleValidSubmit()
        {
            await EmployeeDataService.AddEmployee(Employee);
            Close();

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}
