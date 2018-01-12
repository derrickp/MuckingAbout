using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MuckingAbout
{
    /// <summary>
    /// Wrapper for a web view to display HTML, while limiting hyperlinking to the use the device's browser.
    /// </summary>
    class AppWebView : WebView
    {
        public AppWebView()
        {
            Navigating += _OnNavigation;
        }

        private void _OnNavigation(object sender, WebNavigatingEventArgs args)
        {
            args.Cancel = true;
            Device.OpenUri(new Uri(args.Url));
        }

        public void SetHtml(string html)
        {
            Source = new HtmlWebViewSource()
            {
                Html = html
            };
        }

        public void SetUrl(Uri Url)
        {
            Source = new UrlWebViewSource()
            {
                Url = Url.ToString()
            };
        }
        public void SetUrl(string Url)
        {
            Source = new UrlWebViewSource()
            {
                Url = Url
            };
        }
    }
}
