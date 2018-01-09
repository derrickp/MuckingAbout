using System;

namespace MuckingAbout
{
    public class UserDetailViewModel : BaseViewModel
    {
        public User User { get; set; }
        public UserDetailViewModel(User item = null)
        {
            Title = item?.Display;
            User = item;
        }
    }
}
