using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Models
{
    public class Financeriros
    {
        public int Id { get; set; }

        [Required]
        public int? TerceirosId { get; set; }

        [ForeignKey("TerceirosId")]
        public virtual Terceiros Terceiros {get; set;}

        [Required]
        public DateTime DataCadastro { get; set; }

        [Required]
        public DateTime? DataReferencia { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public decimal? Valor { get; set; }
    }
}
