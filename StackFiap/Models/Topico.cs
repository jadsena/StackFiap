using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StackFiap.Models
{
    public class Topico
    {
        public int Id { get; set; }
        [Required]
        public string Texto { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Aberto { get; set; } = false;
    }
}
