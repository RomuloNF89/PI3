using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PI3.Models;

namespace PI3.AddControllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ContagemEstudantesGraduadosController: ControllerBase
    {
        private BDContexto contexto;

        public ContagemEstudantesGraduadosController(BDContexto bdContexto)
        {
            contexto = bdContexto;
        }

        [HttpGet]
        public List<ContagemEstudantesGraduados> Listar()
        {
            return contexto.ContagemEstudantesGraduados.ToList();
        }
    }
}