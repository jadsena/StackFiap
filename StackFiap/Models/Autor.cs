using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StackFiap.Models
{
    public class Autor
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Nome")]
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        [Required]
        [Display(Name ="E-mail")]
        public string Email { get; set; }
    }
}
