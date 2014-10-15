using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public enum UserLevel
    {
        Admin = 1,
        Seller = 2,
        Client = 3
    }
    public class User
    {
        public string UserName { get; set; }
        public UserLevel UserLevel { get; set; }
    }
}