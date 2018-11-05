using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackFiap.Models
{
    public class Pergunta : Topico
    {
        //Melhor Resposta
        public int MelhorRespostaId { get; set; }
        public Resposta MelhorResposta { get; set; }
        public ICollection<Resposta> Respostas { get; set; }
    }
}
