using System;
using System.Collections.Generic;

#nullable disable

namespace Neqatcom.Core.Data
{
    public partial class Notification
    {
        public decimal Notificationid { get; set; }
        public decimal? Userid { get; set; }
        public string Notificationmessage { get; set; }
        public DateTime? Notificationsdates { get; set; }

        public virtual Gpuser User { get; set; }
    }
}
