﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Neqatcom.Core.Data
{
    public partial class Gptestimonial
    {
        public decimal Id { get; set; }
        public string Message { get; set; }
        public decimal? Testimonialstatus { get; set; }
        public decimal? Userid { get; set; }

        public virtual Gpuser User { get; set; }
    }
}
