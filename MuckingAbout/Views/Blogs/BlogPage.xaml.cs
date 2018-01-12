using System;
using Xamarin.Forms;

namespace MuckingAbout
{
    public partial class BlogPage : ContentPage
    {
        BlogViewModel viewModel;

        public BlogPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new BlogViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as BlogPost;
            if (item == null)
            {
                return;
            }

            await Navigation.PushAsync(new BlogDetailsPage(new BlogDetailsViewModel(item)));

            BlogPosts.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.BlogPosts.Count == 0)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
        }
    }
}