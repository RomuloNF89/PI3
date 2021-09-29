using System;
using System.Collections.Generic;

namespace PI3.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Curso = new HashSet<Curso>();
            Trabalha = new HashSet<Trabalha>();
        }

        public int CodDepartamento { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
        public virtual ICollection<Trabalha> Trabalha { get; set; }
    }
}
