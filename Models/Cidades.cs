using System.Collections.Generic;

namespace WebServicesCidades.Models
{
    public class Cidades
    {
        public int id { get; set; }
        public int habitantes { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }

        public List<Cidades> Listar()
    {  
        return new List <Cidades>()
        {
            new Cidades {id=10,nome="Santa Catarina", uf="SP", habitantes=156},
            new Cidades {id=47,nome="Curitiba", uf="PR", habitantes=876},
            new Cidades {id=94,nome="Suzano", uf="SP", habitantes=456},
            new Cidades {id=51,nome="Paraty", uf="RJ", habitantes=432},
            new Cidades {id=77,nome="Mariana", uf="MG", habitantes=764}
        };
    }
    }

    
}