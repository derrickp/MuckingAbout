using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Auth;

namespace MuckingAbout
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        void SignIn_Clicked(object sender, EventArgs e)
        {
            string clientId;
            string redirectUrl;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    clientId = "325303047770-2845no3n20drtirug7p7s41cvgm6ikmj.apps.googleusercontent.com";
                    redirectUrl = "com.googleusercontent.apps.325303047770-2845no3n20drtirug7p7s41cvgm6ikmj:/oauth2redirect";
                    break;
                default:
                    clientId = "325303047770-jk1ig8n8vr6vc0rplsibtakkihcc73hg.apps.googleusercontent.com";
                    redirectUrl = "com.googleusercontent.apps.325303047770-jk1ig8n8vr6vc0rplsibtakkihcc73hg:/oauth2redirect";
                    break;
            }

            var authenticator = new OAuth2Authenticator(
                clientId,
                null,
                "https://www.googleapis.com/auth/userinfo.email",
                new Uri("https://accounts.google.com/o/oauth2/auth"),
                new Uri(redirectUrl),
                new Uri("https://www.googleapis.com/oauth2/v4/token"),
                null,
                true);

            authenticator.Completed += (authSender, authE) => {
                Console.WriteLine("Authenticated");
                Console.WriteLine(authE.IsAuthenticated);
                Console.WriteLine("End Authenticated");
            };

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
