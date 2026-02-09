using Supabase;
using Supabase.Realtime.PostgresChanges;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;


namespace SupaMaui;

public partial class ChatPage : ContentPage
{

    ObservableCollection<Messages> MessagesV { get; set; } = new();
    Client _supabase;
    public ChatPage(Client supabase)
    {
        InitializeComponent();
        _supabase = supabase;

        SubscribeRealtime();
        loadMessage();
        
        //Servies initualizate()

        //await _supabase.Realtime.ConnectAsync();

        //this.Title = _supabase.Auth.CurrentUser.Id;

    }

    async void loadMessage()
    {
        var result = await _supabase.From<Messages>()
            .Get();
        foreach (var msg in result.Models)
            MessagesV.Add(msg);

        MessagesView.ItemsSource = MessagesV;

    }



    private async Task SubscribeRealtime()
    {

        await _supabase.From<Messages>().On(ListenType.All, async (sender, change) =>
        {
            MainThread.BeginInvokeOnMainThread(() => {

                loadMessage();

            });

            
        });
        //var channel = _supabase.Realtime.Channel("public:messages");


        //channel.AddPostgresChangeHandler(PostgresChangesOptions.ListenType.Inserts, async (sender, change) =>
        //{

            
        //    MainThread.BeginInvokeOnMainThread(() =>
        //    {



        //        MessagesView.ScrollTo(MessagesV.Last(), position: ScrollToPosition.End, animate: true);
        //    });
        //});

        //await channel.Subscribe();


    }


    private async void Button_Clicked(object sender, EventArgs e)
    {
        var idS = Guid.Parse(_supabase.Auth.CurrentUser.Id);
        
        var messege = new Messages
        {
            Message = enterM.Text,
            RecipientId = idS,
            SenderId = idS
            
        };
        await _supabase.From<Messages>().Insert(messege);
        

        
        

    }
}
