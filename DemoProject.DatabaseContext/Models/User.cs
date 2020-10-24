using System;
using System.Collections.Generic;

namespace DemoProject.DatabaseContext
{
    public partial class User
    {
        public User()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Organization { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Location { get; set; }
        public byte[] Photopath { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
