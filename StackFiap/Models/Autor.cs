﻿using System;
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
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        [Required]
        public string Email { get; set; }
    }
}
