using System;

namespace MuckingAbout
{
    public class BlogDetailsViewModel : BaseViewModel
    {
        public BlogPost BlogPost { get; set; }
        public BlogDetailsViewModel(BlogPost item = null)
        {
            if (item != null)
            {
                Title = item.Title;
                BlogPost = item;
            }
        }
    }
}
