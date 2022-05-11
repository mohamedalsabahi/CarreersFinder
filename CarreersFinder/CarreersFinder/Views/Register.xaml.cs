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

        public Command MyRegister { get; set; }
        public Register()
        {

            InitializeComponent();
            BindingContext = this;
            auth = new FirebaseAuthProvider(new FirebaseConfig(FirebaseApiKey));


            MyRegister = new Command(OnRegister);
        }

        private async void OnRegister()
        {
            try
            {

                if (etEmail.Text.ToString() != null && etPassword.Text.ToString() != null)
                {

                    var rr = await auth.CreateUserWithEmailAndPasswordAsync(etEmail.Text.ToString(), etPassword.Text.ToString(), "test", true);





                    if (rr.FirebaseToken != "")
                    {
                        await Navigation.PushAsync(new Views.Home());
                    }
                    else
                    {
                        await DisplayAlert("Sorry", "Somthong Wrong Not Register New Account", "ok");

                    }
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Sorry", "Somthong Error", "ok");

            }
        }

        async Task<FirebaseAuthProvider> Login(string email, string password)
        {
            var myAuth = new FirebaseAuthProvider(new FirebaseConfig(FirebaseApiKey));

            await myAuth.CreateUserWithEmailAndPasswordAsync(email.ToString(), password.ToString(),"",false);

            return myAuth;
        }

       

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Check();
        }


        public async  void Check()
        {
            ////try
            ////{
            ///


            FirebaseAuthProvider hauth= new FirebaseAuthProvider(new FirebaseConfig(FirebaseApiKey));



            if (string.IsNullOrEmpty(etEmail.Text))
                {
                   await  DisplayAlert("Sorry", "Please Enter Email", "ok");


                }
                else if (string.IsNullOrWhiteSpace(etPassword.Text))
                {
                   await  DisplayAlert("Sorry", "Please Enter Password", "ok");

                }
                else
                {
                    var rr = await  hauth.CreateUserWithEmailAndPasswordAsync(etEmail.Text.ToString(), etPassword.Text.ToString(), "test", true);





                    if (rr.FirebaseToken != "")
                    {
                        await Navigation.PushAsync(new Views.Home());
                    }
                   else
                    {
                       await DisplayAlert("Sorry", "Somthong Wrong Not Register New Account", "ok");

                    }
                }

            //}
            //catch (Exception ex)
            //{
            //    await DisplayAlert("Sorry", "Somthong Erroree", "ok");

            //}
        }

      
    }
}