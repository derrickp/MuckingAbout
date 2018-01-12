using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MuckingAbout
{
    public class BlogViewModel : BaseViewModel
    {
        public ObservableCollection<BlogPost> BlogPosts { get; set; }
        public Command LoadItemsCommand { get; set; }

        public BlogViewModel()
        {
            Title = "DL Blogs";
            BlogPosts = new ObservableCollection<BlogPost>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                BlogPosts.Clear();
                var items = await BlogStore.GetItemsAsync();
                foreach (var item in items)
                {
                    BlogPosts.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
