using CarreersFinder.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarreersFinder.Views
{
    public partial class Home : ContentPage
    {
        public ObservableCollection<AddNewModel> AllItems { get; set; } = new ObservableCollection<AddNewModel>();

        AddNewModel modell = new AddNewModel();
        public Home()
        {
            InitializeComponent();

          
            BindingContext = this;



            var firebase = new FirebaseClient("https://careersfinderapp-default-rtdb.firebaseio.com/");
            var observable = firebase.Child("dinosaurs").AsObservable<AddNewModel>();

            observable.Subscribe((ma) =>
            {
                if(ma.Object != null)
                {
                    AllItems.Add(ma.Object);
                 

                }


              //  ma.Object.CompanyEmail.ToString();
            });


            foreach (var Lst in AllItems.ToList())
            {
                if (Lst.Type == "trainning")
                {
                    
                        }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.AddNew());
        }

     
            private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                modell = e.CurrentSelection.FirstOrDefault() as AddNewModel;

            Navigation.PushAsync(new Views.Details(modell));
            Console.WriteLine(modell.CompanyName);
            }
      
    }
}
