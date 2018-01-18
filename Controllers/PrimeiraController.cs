using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesCidades.Models;

namespace WebServicesCidades.Controllers
{
    [Route("api/[controller]")]
    public class PrimeiraController:Controller
    {
        Cidades cidade = new Cidades();
        DAOCidades dao = new DAOCidades();
        [HttpGet]
        public IEnumerable<Cidades> Get()
        {
            return cidade.Listar();
        } 
    }
}