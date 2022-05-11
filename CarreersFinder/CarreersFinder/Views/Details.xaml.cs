using CarreersFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarreersFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Details : ContentPage
    {
        AddNewModel model = new AddNewModel();


        public object MyPropertyy { get; set; }

        public Details(AddNewModel modelll)
        {
            model = modelll;

            InitializeComponent();
            lblName.Text = model.CompanyName;

            lblPhone.Text = model.CompanyPhone.ToString();
            lblEmail.Text = model.CompanyEmail;
            lblType.Text = model.Type;
            lblLocation.Text = model.Location;
            lblDescription.Text = model.Description;
            lblSpecilization.Text = model.specilaization;
        }




    }
}