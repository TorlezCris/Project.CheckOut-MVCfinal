using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.CheckOut.Models
{
    public class UserWeb
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public bool State { get; set; }
        public string ImageRoute { get; set; }
    }
}