using CarreersFinder.Models;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Plugin.FirebaseAuth;
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
    public partial class Register : ContentPage
    {
        string FirebaseApiKey = "AIzaSyDqRsewAiDXQsqGGKQuhkBTs9mzLg7w9Dw";
        FirebaseAuthProvider auth;

        public Register()
        {

            InitializeComponent();
            auth = new FirebaseAuthProvider(new FirebaseConfig(FirebaseApiKey));

           
        
        }


     

        async Task<FirebaseAuthProvider> Login(string email, string password)
        {
            var myAuth = new FirebaseAuthProvider(new FirebaseConfig(FirebaseApiKey));

            await myAuth.CreateUserWithEmailAndPasswordAsync(email.ToString(), password.ToString(),"",false);

            return myAuth;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {


            try
            {
             var rr = await auth.CreateUserWithEmailAndPasswordAsync(etEmail.Text.ToString(), etPassword.Text.ToString(), "test", true);
             
                
                if(rr.FirebaseToken !="" && string.IsNullOrEmpty(etEmail.Text.ToString()) && string.IsNullOrEmpty(etPassword.Text.ToString()))
        
                {
                   await Navigation.PushAsync(new Views.Home());
                }
                else
                {
                    await DisplayAlert("Sorry", "Somthong Error", "ok");

                }
            }
            catch(Exception)
            {
                await DisplayAlert("Sorry", "Somthong Error", "ok");

            }

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
         
        }
    }
}