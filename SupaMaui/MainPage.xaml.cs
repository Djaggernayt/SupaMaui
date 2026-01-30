

using Microsoft.Maui.Controls.Platform;
using Supabase;

using System.Windows;
using static Supabase.Gotrue.Constants;



namespace SupaMaui
{
    public partial class MainPage : ContentPage
    {
        private readonly Client _supabase;
        Supabase.Gotrue.Session _session;


        public MainPage(Client supabase)
        {
            InitializeComponent();
            _supabase = supabase;
           // AddUser();
            LoadProduct();
            
            

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
                _session =  await _supabase.Auth.SignIn("test@localhost.com", "admin1234");
                email.Text = _supabase.Auth.CurrentUser.Id;
            }
            catch
            {

            }
        }
        

        private async void add_Clicked(object sender, EventArgs e)
        {
            await _supabase.Auth.VerifyOTP(email.Text, otp.Text, EmailOtpType.Email);
        }

        private async void del_Clicked(object sender, EventArgs e)
        {
            var fileBytes = await File.ReadAllBytesAsync("imgs.jpg");
            var path = $"{Guid.NewGuid()}.jpg";

            

            await _supabase.Storage.From("products").Upload(fileBytes, path);

            var product = new Product
            {
                Name = "ABOBA",
                Img = path
                
            };
            await _supabase.From<Product>().Insert(product);
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
