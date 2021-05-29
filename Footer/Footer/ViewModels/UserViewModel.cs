using System;
using System.Collections.Generic;
using System.Text;
using Footer.Interfaces;
using Footer.Models;

namespace Footer.ViewModels
{
    class UserViewModel
    {
        public IUser userProfile;

        public UserViewModel()
        {
            userProfile = new User();
        }
    }
}
