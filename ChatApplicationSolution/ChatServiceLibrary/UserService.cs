using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ChatServiceLibrary.Models;

namespace ChatServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in both code and config file together.
    public class UserService : IUserService
    {
       
        public string DoWork()
        {
            return "Inside dowork of User service";
        }

        public User Login(User user)
        {
            return new User();
        }

        public User Register(User user)
        {
            return new User();
        }
    }
}
