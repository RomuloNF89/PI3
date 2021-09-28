using System;
using System.Collections.Generic;

namespace PI3.Models
{
    public partial class Tem
    {
        public int CodDisciplina { get; set; }
        public int CodCurso { get; set; }

        public virtual Curso CodCursoNavigation { get; set; }
        public virtual Disciplina CodDisciplinaNavigation { get; set; }
    }
}
