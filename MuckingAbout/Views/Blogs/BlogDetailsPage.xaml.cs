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
        }
    }
}
