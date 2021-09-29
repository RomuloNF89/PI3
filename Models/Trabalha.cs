using System;
using System.Collections.Generic;

namespace PI3.Models
{
    public partial class Trabalha
    {
        public int CodDepartamento { get; set; }
        public int MatProfessor { get; set; }

        public virtual Departamento CodDepartamentoNavigation { get; set; }
        public virtual Professor MatProfessorNavigation { get; set; }
    }
}
