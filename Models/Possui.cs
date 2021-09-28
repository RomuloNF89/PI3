using System;
using System.Collections.Generic;

namespace PI3.Models
{
    public partial class Possui
    {
        public int CodBolsa { get; set; }
        public int CodConcedente { get; set; }

        public virtual Bolsa CodBolsaNavigation { get; set; }
        public virtual Concedente CodConcedenteNavigation { get; set; }
    }
}
