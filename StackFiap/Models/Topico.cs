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
        [Display(Name ="Autor")]
        public int AutorId { get; set; }
        [Display(Name ="Autor")]
        public Autor Autor { get; set; }
        [Display(Name ="Data Criação")]
        public DateTime DataCriacao { get; set; }
        public bool Aberto { get; set; } = false;
    }
}
