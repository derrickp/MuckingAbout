using System;
using System.Collections.Generic;
using System.Text;

namespace MuckingAbout
{
    public class BlogPost
    {
        public string Title { get; set; }
        public string ID { get; set; }
        public string PostDate { get; set; }
        public string Message { get; set; }

        public BlogListEntry GetListItem()
        {
            BlogListEntry ble = new BlogListEntry(Title,ID);
            return ble;
        }
    }

    public class BlogListEntry
    {
        public string Title { get; set; }
        public string ID { get; set; }

        public BlogListEntry(string inTitle, string inID)
        {
            Title = inTitle;
            ID = inID;
        }
    }
}
