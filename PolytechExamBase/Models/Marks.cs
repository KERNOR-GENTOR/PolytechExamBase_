using System;
using System.Collections.Generic;

namespace PolytechExamBase.Models
{
    public partial class Marks
    {
        public long MarkId { get; set; }
        public long PassedTaskId { get; set; }
        public int? Mark { get; set; }

        public virtual PassedTasks PassedTask { get; set; }
    }
}
