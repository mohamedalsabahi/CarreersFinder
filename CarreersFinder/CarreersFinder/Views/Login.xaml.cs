using Firebase.Auth;
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
    public partial class Login : ContentPage
    {
        string FirebaseApiKey = "AIzaSyDqRsewAiDXQsqGGKQuhkBTs9mzLg7w9Dw";

        FirebaseAuthProvider auth;

        public Login()
        {
            InitializeComponent();
            auth = new FirebaseAuthProvider(new FirebaseConfig(FirebaseApiKey));

        }



        private async void Button_Clicked(object sender, EventArgs e)
        {
        await  LoginFun(etEmail.Text.ToString(), etPassword.Text.ToString());
          //  var result = await CrossFirebaseAuth.Current.Instance.SignInWithEmailAndPasswordAsync(etEmail.Text.ToString(), etPassword.Text.ToString());

          
        }

        async Task<string> LoginFun(string email,string pass)
        {
            try
            {

            var ma = await auth.SignInWithEmailAndPasswordAsync(email,pass);
            if(ma.FirebaseToken !="" )
            {
              await  Navigation.PushAsync(new Views.Home());

            }
            else
            {
              await  DisplayAlert("Error", "Email Or Password Not Correct", "ok");
            }
            }
            catch(Exception e)
            {
                await DisplayAlert("Error", "Email Or Password Not Correct", "ok");

            }

            return "";
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Register());
        }
    }
}