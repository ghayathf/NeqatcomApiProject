using System;
using System.Collections.Generic;

#nullable disable

namespace Neqatcom.Core.Data
{
    public partial class Gploanee
    {
        public Gploanee()
        {
            Gploans = new HashSet<Gploan>();
            Gpmeetings = new HashSet<Gpmeeting>();
        }

        public decimal Id { get; set; }
        public string Nationalnumber { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public decimal? Salary { get; set; }
        public decimal? Numoffamily { get; set; }
        public decimal? Creditscore { get; set; }
        public decimal? Userid { get; set; }

        public virtual Gpuser User { get; set; }
        public virtual ICollection<Gploan> Gploans { get; set; }
        public virtual ICollection<Gpmeeting> Gpmeetings { get; set; }
    }
}
