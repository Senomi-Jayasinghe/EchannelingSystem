using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EchannelingSystem.Model
{
    public class UserLogin
    {
        public int loginID {  get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
        public int referenceID { get; set; }
        public int userRole { get; set; }
    }
}