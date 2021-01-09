using System;
using System.Collections.Generic;

namespace PolytechExamBase.Models
{
    public partial class PassedTasks
    {
        public PassedTasks()
        {
            Marks = new HashSet<Marks>();
        }

        public long PassedTaskId { get; set; }
        public long UserId { get; set; }
        public long TaskId { get; set; }
        public string CodeAnswer { get; set; }
        public bool? Successful { get; set; }

        public virtual Tasks Task { get; set; }
        public virtual Dbusers User { get; set; }
        public virtual ICollection<Marks> Marks { get; set; }
    }
}
