using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_EFTemplate.EntidadeDAL
{
    public class CadastroContext : DbContext
    {
        public CadastroContext()
            : base("CadastroContext")
        {
            Database.SetInitializer<CadastroContext>(null);// desabilitar a criação do banco.
        }

        public DbSet<Empregado> empregados { get; set; }
        public DbSet<Departamento> departamentos { get; set; }
    }
}
