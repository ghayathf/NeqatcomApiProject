﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Neqatcom.Core.Data
{
    public partial class Gploanee
    {
        public Gploanee()
        {
            Gpcomplaints = new HashSet<Gpcomplaint>();
            Gploans = new HashSet<Gploan>();
            Gpmeetings = new HashSet<Gpmeeting>();
        }

        public decimal Loaneeid { get; set; }
        public string Nationalnumber { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public decimal? Salary { get; set; }
        public decimal? Numoffamily { get; set; }
        public decimal? Creditscore { get; set; }
        public decimal? Loaneeuserid { get; set; }
        public decimal? Warncounter { get; set; }

        public virtual Gpuser Loaneeuser { get; set; }
        public virtual ICollection<Gpcomplaint> Gpcomplaints { get; set; }
        public virtual ICollection<Gploan> Gploans { get; set; }
        public virtual ICollection<Gpmeeting> Gpmeetings { get; set; }
    }
}
