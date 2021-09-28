using System;
using System.Collections.Generic;

namespace PI3.Models
{
    public partial class Leciona
    {
        public int MatProfessor { get; set; }
        public int? Ano { get; set; }
        public int CodDisciplina { get; set; }

        public virtual Disciplina CodDisciplinaNavigation { get; set; }
        public virtual Professor MatProfessorNavigation { get; set; }
    }
}
