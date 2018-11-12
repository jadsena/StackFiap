using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackFiap.Core.Models
{
    public class Resposta : Topico
    {
        public int PerguntaId { get; set; }
        public Pergunta Pergunta { get; set; }
    }
}
