using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Mvc_EFTemplate.EntidadeDAL
{
    [Table("Empregados")]
    public class Empregado
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Sobrenome { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [ForeignKey("Departamento")]
        public int DepartamentoId { get; set; }

        public Departamento Departamento { get; set; }
    }
}
