using System;
using System.Collections.Generic;

namespace PI3.Models
{
    public partial class Professor
    {
        public Professor()
        {
            Curso = new HashSet<Curso>();
            Leciona = new HashSet<Leciona>();
            Trabalha = new HashSet<Trabalha>();
        }

        public int MatProfessor { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
        public virtual ICollection<Leciona> Leciona { get; set; }
        public virtual ICollection<Trabalha> Trabalha { get; set; }
    }
}
