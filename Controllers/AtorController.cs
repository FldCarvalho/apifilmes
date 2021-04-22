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
    public class AtorController : ControllerBase
    {
        apiDBContext context = new apiDBContext();

        [HttpPost]
        public TbAtor Salvar (TbAtor ator)
        {
            context.TbAtor.Add(ator);
            context.SaveChanges();

            return ator;
        }

        [HttpGet]
        public List<TbAtor> Listar ()
        {
           return context.TbAtor.ToList();
        }

        [HttpGet("consultar")]
        public List<TbAtor> Consultar (string ator)
        {
            return context.TbAtor.Where(x => x.NmAtor == ator).ToList();
        }
    

    }
}