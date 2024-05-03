using Module06MVVM.ViewModel;
using Module06MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Module06MVVM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeView : ContentPage
    {

        EmployeeViewModel _viewModel;
        bool _isUpdate;
        int employeeID;
        public EmployeeView()
        {
            InitializeComponent();

            //BindingContext = new EmployeeViewModel();

            _viewModel = new EmployeeViewModel();
            _isUpdate = false;
        }

        public EmployeeView(EmployeeModel obj)
        {
            InitializeComponent();
            _viewModel = new EmployeeViewModel();
            if (obj != null ) 
            {

                employeeID = obj.Id;
                txtName.Text = obj.Name;
                txtEmail.Text = obj.Email;
                txtAddress.Text = obj.Address;
                         
            }
        }

        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            EmployeeModel obj = new EmployeeModel();
            obj.Name = txtName.Text;
            obj.Email = txtEmail.Text;
            obj.Address = txtAddress.Text;

            _viewModel.InsertEmployee(obj);

            await this.Navigation.PopAsync();
        }
    }
}