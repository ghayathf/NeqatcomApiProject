using System;
using System.Collections.Generic;

#nullable disable

namespace Neqatcom.Core.Data
{
    public partial class Gplenderstore
    {
        public Gplenderstore()
        {
            Gpmeetings = new HashSet<Gpmeeting>();
            Gpoffers = new HashSet<Gpoffer>();
        }

        public decimal Lenderid { get; set; }
        public string Commercialregister { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Registerstatus { get; set; }
        public decimal? Shadowstatus { get; set; }
        public string Companysize { get; set; }
        public string Siteurl { get; set; }

        public virtual Gpuser User { get; set; }
        public virtual ICollection<Gpmeeting> Gpmeetings { get; set; }
        public virtual ICollection<Gpoffer> Gpoffers { get; set; }
    }
}
