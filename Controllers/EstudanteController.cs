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
    public class EstudanteController: ControllerBase
    {
        private BDContexto contexto;

        public EstudanteController(BDContexto bdContexto)
        {
            contexto = bdContexto;
        }

        [HttpGet]
        public List<Estudante> Listar()
        {
            return contexto.Estudante.ToList();
        }
    }
}