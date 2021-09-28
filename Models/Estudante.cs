using System;
using System.Collections.Generic;

namespace PI3.Models
{
    public partial class Estudante
    {
        public Estudante()
        {
            PodeSer = new HashSet<PodeSer>();
        }

        public int MatEstudante { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public bool Graduado { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public bool RespFinanceiro { get; set; }
        public int? CodCurso { get; set; }

        public virtual Curso CodCursoNavigation { get; set; }
        public virtual ICollection<PodeSer> PodeSer { get; set; }
    }
}
