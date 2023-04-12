using System;
using System.Collections.Generic;

#nullable disable

namespace Neqatcom.Core.Data
{
    public partial class Gpcategory
    {
        public Gpcategory()
        {
            Gpoffers = new HashSet<Gpoffer>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Gpoffer> Gpoffers { get; set; }
    }
}
