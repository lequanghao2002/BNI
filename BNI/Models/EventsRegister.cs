using System;
using System.Collections.Generic;

namespace BNI.Models
{
    public partial class EventsRegister
    {
        public int? EventId { get; set; }
        public int? UserId { get; set; }
        public DateTime? AddDate { get; set; }
        public bool? Cancel { get; set; }

        public virtual Event? Event { get; set; }
        public virtual User? User { get; set; }
    }
}
