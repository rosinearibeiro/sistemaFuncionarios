﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //validações

namespace Projeto.Services.Models
{
    public class FuncionarioEdicaoModel
    {
        [Required]
        public int IdFuncionario { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Salario { get; set; }

        [Required]
        public DateTime DataAdmissao { get; set; }
    }
}