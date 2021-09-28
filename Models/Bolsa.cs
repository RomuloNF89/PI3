using System;
using System.Collections.Generic;

namespace PI3.Models
{
    public partial class Bolsa
    {
        public Bolsa()
        {
            PodeSer = new HashSet<PodeSer>();
            Possui = new HashSet<Possui>();
        }

        public int CodBolsa { get; set; }
        public short Ano { get; set; }
        public string Edital { get; set; }
        public float Percentual { get; set; }

        public virtual ICollection<PodeSer> PodeSer { get; set; }
        public virtual ICollection<Possui> Possui { get; set; }
    }
}
