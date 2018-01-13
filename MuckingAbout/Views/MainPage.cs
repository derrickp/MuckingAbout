using System;

using Xamarin.Forms;
using Xamarin.Auth;

namespace MuckingAbout
{
    public class MainPage : TabbedPage
    {
        AccountStore store;

        public MainPage()
        {
            Page itemsPage, aboutPage, usersPage, blogPage = null;
            store = AccountStore.Create();


            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    itemsPage = new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse"
                    };

                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };
                    usersPage = new NavigationPage(new UsersPage())
                    {
                        Title = "Users"
                    };
                    blogPage = new BlogPage()
                    {
                        Title = "Blog"
                    };
                    break;
                    itemsPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    usersPage.Icon = "tab_about.png";
                    blogPage.Icon = "tab_about.png";
                    break;
                default:
                    itemsPage = new ItemsPage()
                    {
                        Title = "Browse"
                    };

                    aboutPage = new AboutPage()
                    {
                        Title = "About"
                    };
                    usersPage = new UsersPage()
                    {
                        Title = "Users"
                    };
                    blogPage = new BlogPage()
                    {
                        Title = "Blog"
                    };
                    break;
            }

            Children.Add(itemsPage);
            Children.Add(aboutPage);
            Children.Add(usersPage);
            Children.Add(blogPage);

            //var authenticator = new OAuth2Authenticator(
            //    clientId,
            //    null,
            //    "https://www.googleapis.com/auth/userinfo.email",
            //    new Uri("https://accounts.google.com/o/oauth2/auth"),
            //    new Uri(redirectUrl),
            //    new Uri("https://www.googleapis.com/oauth2/v4/token"),
            //    null,
            //    true);

            //authenticator.Completed += (sender, e) => {
            //    Console.WriteLine("Authenticated");
            //    Console.WriteLine(e.IsAuthenticated);
            //    Console.WriteLine("End Authenticated");
            //};

            //AuthenticationState.Authenticator = authenticator;

            //var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            //presenter.Login(authenticator);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
