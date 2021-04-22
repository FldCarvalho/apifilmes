using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using apifilmes.Models;
using Microsoft.AspNetCore.Mvc;

namespace apifilmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        apiDBContext context = new apiDBContext();

        [HttpPost]
        public TbFilme Salvar (TbFilme filme)
        {
            context.TbFilme.Add(filme);
            context.SaveChanges();

            return filme;
        }
        
        [HttpGet]
        public List<TbFilme> Listar ()
        {
           return context.TbFilme.ToList();
        }

        [HttpGet("consultar")]
        public List<TbFilme> Consultar (string genero)
        {
            return context.TbFilme.Where(x => x.DsGenero == genero).ToList();
        }

        [HttpPut]
        public void Alterar (TbFilme filme)
        {
           TbFilme atual = context.TbFilme.First(x => x.IdFilme == filme.IdFilme);
           atual.NmFilme = filme.NmFilme;
           atual.DsGenero = filme.DsGenero;
           atual.NrDuracao = filme.NrDuracao;
           atual.VlAvaliacao = filme.VlAvaliacao;
           atual.BtDisponivel = filme.BtDisponivel;
           atual.DtLancamento = filme.DtLancamento;

           context.SaveChanges();
        }

        [HttpDelete]
        public void Remover (int id)
        {
            TbFilme filme = context.TbFilme.First(x => x.IdFilme == id);
            context.TbFilme.Remove(filme);
            context.SaveChanges();
        }
    }
}