using System;
using System.Collections.Generic;

namespace PI3.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Curso = new HashSet<Curso>();
        }

        public int CodTipo { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
    }
}
