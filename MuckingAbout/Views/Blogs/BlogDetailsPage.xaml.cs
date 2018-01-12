using System;

using Xamarin.Forms;

namespace MuckingAbout
{
    public partial class BlogDetailsPage : ContentPage
    {
        BlogDetailsViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public BlogDetailsPage()
        {
            InitializeComponent();

            var item = new BlogPost
            {
                Title = "Item 1",
                Message = "This is an item description.",
                PostDate = "10/10/10"
            };

            viewModel = new BlogDetailsViewModel(item);
            BindingContext = viewModel;
        }

        public BlogDetailsPage(BlogDetailsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            Content = new StackLayout()
            {
                Children =
                {
                    _GetHeader(),
                    _GetPostView()
                }
            };
        }

        private StackLayout _GetHeader()
        { 

            var author = new Label()
            {
                Text = viewModel.BlogPost.Author.Display,
                FontSize = 14,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start
            };

            var date = new Label()
            {
                Text = viewModel.BlogPost.PostDate,
                FontSize = 10,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start
            };

            var header = new StackLayout
            {
                Children =
                { 
                    author,
                    date
                }
            };
            return header;
        }

        private WebView _GetPostView()
        {
            var webView = new AppWebView()
            { 
                HeightRequest = 400,
                WidthRequest = 100
            };

            webView.SetHtml(viewModel.BlogPost.Message);  
            return webView;
        }

        private void _Navigating(object sender, WebNavigatingEventArgs args)
        {
            args.Cancel = true;
            Device.OpenUri(new Uri(args.Url));
        }
    } 
}
