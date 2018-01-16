using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace WebServicesCidades.Controllers
{
    [Route("api/[controller]")]
    public class PrimeiraController:Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string [] {"Curitiba", "Porto Alegre", "Santa Catarina", "Belo Horizonte"};
        } 
    }
}