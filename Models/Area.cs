using System;
using System.Collections.Generic;

namespace PI3.Models
{
    public partial class Area
    {
        public Area()
        {
            Curso = new HashSet<Curso>();
        }

        public int CodArea { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
    }
}
