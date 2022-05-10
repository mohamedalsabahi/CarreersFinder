using CarreersFinder.Models;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace CarreersFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNew : ContentPage
    {
                        FirebaseClient firebaseClient = new FirebaseClient("TODO");


        private string _selSubCategories;
        public string selSubCategories
        {
            get { return _selSubCategories; }
            set
            {
                _selSubCategories = value;
                OnPropertyChanged(nameof(selSubCategories));
            }
        }
        public ObservableCollection<TypesModel> AllTypesLst { get; set; }


        public AddNew()
        {
            InitializeComponent();
            AllTypesLst = new ObservableCollection<TypesModel>
            {
                new TypesModel
                {
                    TypeName="Training"
                },

                 new TypesModel
                {
                    TypeName="Employment"
                },

                  new TypesModel
                {
                    TypeName=" Training & Employment"
                },
            };

            AllTypes();
            BindingContext = this;

            //  Firebase.IHttpClientFactory.
            // firebaseClient.Child("Careers").PostAsync(new AddNewModel { });
    
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
           
        //    var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync("", "");
         //   FirebaseAuthProvider firebaseAuth = firebaseAuth.SignInWithEmailAndPasswordAsync("", "","");

          

        }


       async Task<FirebaseAuthProvider> Login(string email, string password)
        {
            string FirebaseApiKey = "AIzaSyDqRsewAiDXQsqGGKQuhkBTs9mzLg7w9Dw";
            var myAuth = new FirebaseAuthProvider(new FirebaseConfig(FirebaseApiKey));

          await myAuth.SignInWithEmailAndPasswordAsync(email, password);

            return myAuth;
        }

         void  Button_Clicked(object sender, EventArgs e)
        {
            AddNewModel mode = new AddNewModel();

            string myBook = "c";
            mode.CompanyEmail = etEmail.Text.ToString();
            mode.CompanyName = etName.Text.ToString();
            mode.CompanyPhone = Convert.ToInt32(etPhone.Text);
            mode.Description = edDescription.Text.ToString();
            mode.Location = etLocation.Text.ToString();
          
            mode.Type =  selSubCategories;
            mode.specilaization = etspecilaization.Text.ToString();
            var firebase = new FirebaseClient("https://careersfinderapp-default-rtdb.firebaseio.com/");
            var observable = firebase
              .Child("AllDb").PostAsync(mode);

            Navigation.PopAsync();
        }


        void AllTypes()
        {
        }
    }
}