using System;

using Xamarin.Forms;

namespace MuckingAbout
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page itemsPage, aboutPage, usersPage, blogPage = null;

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

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
