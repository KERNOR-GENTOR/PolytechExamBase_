using System;
using System.Collections.Generic;

namespace PolytechExamBase.Models
{
    public partial class Dbusers
    {
        public Dbusers()
        {
            PassedTasks = new HashSet<PassedTasks>();
            Tasks = new HashSet<Tasks>();
        }

        public long FuckingUserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<PassedTasks> PassedTasks { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
