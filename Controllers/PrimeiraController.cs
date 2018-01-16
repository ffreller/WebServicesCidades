using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebServicesCidades.Models;

namespace WebServicesCidades.Controllers
{
    [Route("api/[controller]")]
    public class PrimeiraController:Controller
    {
        Cidades cidade = new Cidades();
        [HttpGet]
        public IEnumerable<Cidades> Get()
        {
            return cidade.Listar();
        } 
    }
}