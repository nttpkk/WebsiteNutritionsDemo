using System;
using System.Collections.Generic;

namespace AspNetCoreWebAppBackend.Database
{
    public partial class Users
    {
        public Users()
        {
            Events = new HashSet<Events>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public int? UserBmi { get; set; }

        public virtual ICollection<Events> Events { get; set; }
    }
}
