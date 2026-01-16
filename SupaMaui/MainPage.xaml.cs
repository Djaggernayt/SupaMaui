

using Supabase;

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
        

        private void add_Clicked(object sender, EventArgs e)
        {

        }

        private void del_Clicked(object sender, EventArgs e)
        {

        }
    }

}
