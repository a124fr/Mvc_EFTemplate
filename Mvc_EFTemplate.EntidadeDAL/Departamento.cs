﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Mvc_EFTemplate.EntidadeDAL
{
    [Table("Departamentos")]
    public class Departamento
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public IList<Empregado> Empregados { get; set; }
    }
}
