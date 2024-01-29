using System;
using System.Collections.Generic;

#nullable disable

namespace BlockBuster.Models
{
    public partial class AuditLog
    {
        public int AuditId { get; set; }
        public string Description { get; set; }
    }
}
