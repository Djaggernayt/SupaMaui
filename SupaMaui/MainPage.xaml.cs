

using Microsoft.Maui.Controls.Platform;
using Supabase;
using static Supabase.Gotrue.Constants;



namespace SupaMaui
{
    public partial class MainPage : ContentPage
    {
        private readonly Client _supabase;



        public MainPage(Client supabase)
        {
            InitializeComponent();
            _supabase = supabase;
            LoadProduct();
            //AddUser();

        }

        async void AddUser()
        {
            var session = await _supabase.Auth.SignUp("test@localhost.com","admin1234");
        }

        async void LoadProduct()
        {
            try
            {
                var result = await _supabase.From<Product>().Get();

                listproduct.ItemsSource = result.Models;
            }
            catch
            {

            }
        }
        

        private async void add_Clicked(object sender, EventArgs e)
        {
            await _supabase.Auth.VerifyOTP(email.Text, otp.Text, EmailOtpType.Email);
        }

        private void del_Clicked(object sender, EventArgs e)
        {

        }

        private async void enter_Clicked(object sender, EventArgs e)
        {

                await _supabase.Auth.SignIn(email.Text, password.Text);
            // где то тут должна быть проверка
                var option = new Supabase.Gotrue.SignInWithPasswordlessEmailOptions(email.Text);
                await _supabase.Auth.SignInWithOtp(option);


            
        }
    }

}
