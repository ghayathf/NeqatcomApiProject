using System;
using System.Collections.Generic;

#nullable disable

namespace Neqatcom.Core.Data
{
    public partial class Gpuser
    {
        public Gpuser()
        {
            Gplenderstores = new HashSet<Gplenderstore>();
            Gploanees = new HashSet<Gploanee>();
            Gptestimonials = new HashSet<Gptestimonial>();
        }

        public decimal Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phonenum { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Gplenderstore> Gplenderstores { get; set; }
        public virtual ICollection<Gploanee> Gploanees { get; set; }
        public virtual ICollection<Gptestimonial> Gptestimonials { get; set; }
    }
}
