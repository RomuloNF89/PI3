using System;
using System.Collections.Generic;

namespace PI3.Models
{
    public partial class Concedente
    {
        public Concedente()
        {
            Possui = new HashSet<Possui>();
        }

        public int CodConcedente { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Possui> Possui { get; set; }
    }
}
