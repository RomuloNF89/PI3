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
    public class PossuiController: ControllerBase
    {
        private BDContexto contexto;

        public PossuiController(BDContexto bdContexto)
        {
            contexto = bdContexto;
        }

        [HttpGet]
        public List<Possui> Listar()
        {
            return contexto.Possui.ToList();
        }
    }
}