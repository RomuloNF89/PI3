using System;
using System.Collections.Generic;

namespace PI3.Models
{
    public partial class Disciplina
    {
        public Disciplina()
        {
            Leciona = new HashSet<Leciona>();
            Tem = new HashSet<Tem>();
        }

        public int CodDisciplina { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Leciona> Leciona { get; set; }
        public virtual ICollection<Tem> Tem { get; set; }
    }
}
