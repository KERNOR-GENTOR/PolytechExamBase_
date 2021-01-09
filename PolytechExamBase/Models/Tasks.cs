using System;
using System.Collections.Generic;

namespace PolytechExamBase.Models
{
    public partial class Tasks
    {
        public Tasks()
        {
            PassedTasks = new HashSet<PassedTasks>();
        }

        public long TaskId { get; set; }
        public string Description { get; set; }
        public string CodeToTest { get; set; }
        public string UnitTest { get; set; }
        public string Difficulty { get; set; }
        public string Topic { get; set; }
        public long TeacherId { get; set; }

        public virtual Dbusers Teacher { get; set; }
        public virtual ICollection<PassedTasks> PassedTasks { get; set; }
    }
}
