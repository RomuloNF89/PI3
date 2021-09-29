using System;
using System.Collections.Generic;

namespace PI3.Models
{
    public partial class PodeSer
    {
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public int MatEstudante { get; set; }
        public int CodBolsa { get; set; }
        public bool BolsaAtiva { get; set; }

        public virtual Bolsa CodBolsaNavigation { get; set; }
        public virtual Estudante MatEstudanteNavigation { get; set; }
    }
}
