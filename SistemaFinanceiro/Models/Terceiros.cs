using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Models
{
    public class Terceiros
    {
        public int Id { get; set; }

        public DateTime? DataCadastro { get; set; } = DateTime.Now;

        [Required]
        public string Nome { get; set; }
        public string Cnh { get; set; }

        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public virtual ICollection<Financeriros> ListaDeFinanceriros { get; set; } = new List<Financeriros>();
       
    }
}
