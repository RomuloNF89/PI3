using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using PI3.Models;

namespace PI3.AddControllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EstudanteController : ControllerBase
    {
        private BDContexto contexto;

        public EstudanteController(BDContexto bdContexto)
        {
            contexto = bdContexto;
        }
        [HttpPost]
        public Estudante Store([FromBody] Estudante model)
        {
            contexto.Estudante.Add(model);
            contexto.SaveChanges();

            return this.GetById(model.MatEstudante);
        }
        [HttpPut]
        public Estudante Update([FromBody] Estudante model)
        {
            contexto.Estudante.Update(model);
            contexto.SaveChanges();

            return this.GetById(model.MatEstudante);
        }
        [HttpDelete]
        public string Delete([FromBody] int id)
        {
            Estudante dados = contexto.Estudante.FirstOrDefault(c => c.MatEstudante == id);
            if (dados == null)
            {
                return "Registro não encontrado!";
            }

            contexto.Remove(dados);
            contexto.SaveChanges();
            return "Registo Apagado com sucesso!";
        }
        [HttpDelete]
        public string DeleteLogic([FromBody] int id)
        {
            Estudante dados = contexto.Estudante.FirstOrDefault(c => c.MatEstudante == id);
            if (dados == null)
            {
                return "Registro não encontrado!";
            }
            DateTime localDate = DateTime.Now;
            dados.Deleted = localDate.ToString(new CultureInfo("pt-BR"));

            contexto.Update(dados);
            contexto.SaveChanges();
            return "Registo Apagado com sucesso!";
        }

        public Estudante GetById(int id)
        {
            return selecteQuery().FirstOrDefault(c => c.MatEstudante == id);
        }

        [HttpGet]
        public List<Estudante> Listar()
        {
            return this.selecteQuery().ToList();
        }

        [HttpGet]
        public List<Estudante> ListarInativos()
        {
            return contexto.Estudante.Where(c => c.Deleted != null).Include(c => c.CodCursoNavigation).OrderBy(c => c.MatEstudante).Select
        (
            c => new Estudante
            {
                MatEstudante = c.MatEstudante,
                Nome = c.Nome,
                Idade = c.Idade,
                Telefone = c.Telefone,
                Email = c.Email,
                Endereco = c.Endereco,
                Graduado = c.Graduado,
                CodCursoNavigation = new Curso
                {
                    CodCurso = c.CodCursoNavigation.CodCurso,
                    Nome = c.CodCursoNavigation.Nome,
                    CargaHoraria = c.CodCursoNavigation.CargaHoraria,
                }
            }
         ).ToList();
        }

        private IQueryable<Estudante> selecteQuery()
        {
            return contexto.Estudante.Where(c => c.Deleted == null).Include(c => c.CodCursoNavigation).OrderBy(c => c.MatEstudante).Select
           (
               c => new Estudante
               {
                   MatEstudante = c.MatEstudante,
                   Nome = c.Nome,
                   Idade = c.Idade,
                   Telefone = c.Telefone,
                   Email = c.Email,
                   Endereco = c.Endereco,
                   Graduado = c.Graduado,
                   CodCursoNavigation = new Curso
                   {
                       CodCurso = c.CodCursoNavigation.CodCurso,
                       Nome = c.CodCursoNavigation.Nome,
                       CargaHoraria = c.CodCursoNavigation.CargaHoraria,
                   }
               }
            );
        }

    }
}