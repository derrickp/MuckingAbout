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
        public User Author { get; set; } 
    } 
}
