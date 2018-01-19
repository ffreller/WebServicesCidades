using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesCidades.Models;

namespace WebServicesCidades.Controllers
{
    //Definindo a rota para a requisição do serviço
    [Route("api/[controller]")]
    public class PrimeiraController : Controller
    {
        Cidades cidade = new Cidades();
        DAOCidades dao = new DAOCidades();
        
        [HttpGet]
        public IEnumerable<Cidades> GetCidades(){
            return dao.Listar();
        }
        [HttpGet("{id}", Name = "CidadeAtual")]
        public Cidades GetCidades(int id){
            return dao.Listar().Where(x => x.id == id).FirstOrDefault();
        }
        [HttpPost]
        public IActionResult CadastrarCidade([FromBody] Cidades cidade){
            dao.Cadastrar(cidade);
            return CreatedAtRoute("CidadeAtual", new{id = cidade.id}, cidade); //redireciona a rota para o Get para mostrar o que foi cadastrado
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarCidade([FromBody] Cidades cidade, int id){
            cidade.id = id;
            dao.Atualizar(cidade);
            return CreatedAtRoute("CidadeAtual", new{id = cidade.id}, cidade);
        }
        [HttpDelete("{id}")]
        public IActionResult ExcluirCidade(int id){
            dao.Excluir(id);
            return Ok(id);
        }

        // // [HttpGet]
            // // /// <summary>
            // //     /// Mostrar todas as cidades.  
            // //     /// </summary>
            // //     /// <returns>todas as cidades do array</returns>
            // // public IEnumerable<string> GetPrimeira(){
            // //     return new string[]{
            // //         "Curitiba",
            // //         "Porto Alegre",
            // //         "Salvador",
            // //         "Belo Horizonte"
            // //     };
            // // }

            // //HttpGet com {id} do array fornecido para sobrecarga de método
            // [HttpGet("{id}")]
            // // /// <summary>
            //     //     /// Mostrar cidade de acordo com o id
            //     //     /// </summary>
            //     //     /// <param name="id">id da cidade no array</param>
            //     //     /// <returns>cidade</returns>
            //     // // public string GetPrimeira(int id){
            //     // //     return new string[]{
            //     // //         "Curitiba",
            //     // //         "Porto Alegre",
            //     // //         "Salvador",
            //     // //         "Belo Horizonte"
            //     // //     }[id];
            //     // // }

            // /// <summary>
            //     /// Selecionar uma cidade por id
            //     /// </summary>
            //     /// <param name="id">id da cidade na lista</param>
            //     /// <returns>cidade escolhida e dados</returns>
            // public IEnumerable<Cidades> GetPrimeira(int id){
            //     var lst = new Cidades().Listar().GetRange(id,1);
            //     return lst;
            // }
            
            // //retornar as cidades com objeto Cidades
            // [HttpGet]
            // public IEnumerable<Cidades> GetPrimeira(){
            //     return cidade.Listar();
            // }
    }
}