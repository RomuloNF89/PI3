using System;
using System.Collections.Generic;

namespace PI3.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Estudante = new HashSet<Estudante>();
            Tem = new HashSet<Tem>();
        }

        public int CodCurso { get; set; }
        public int CodCoordenador { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public string Modalidade { get; set; }
        public bool Estagio { get; set; }
        public int? CodDepartamento { get; set; }
        public int? CodTipo { get; set; }
        public int? CodArea { get; set; }

        public virtual Area CodAreaNavigation { get; set; }
        public virtual Professor CodCoordenadorNavigation { get; set; }
        public virtual Departamento CodDepartamentoNavigation { get; set; }
        public virtual Tipo CodTipoNavigation { get; set; }
        public virtual ICollection<Estudante> Estudante { get; set; }
        public virtual ICollection<Tem> Tem { get; set; }
    }
}
