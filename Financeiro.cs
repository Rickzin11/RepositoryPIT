using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pjt_Software.Contexts;
using Pjt_Software.Validators;

namespace Pjt_Software.Models
{
    public class Financeiro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int FinanceiroId { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O lucro é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O lucro deve ser um valor positivo.")]
        public double Lucro { get; set; }

        [Required(ErrorMessage = "As despesas são obrigatórias.")]
        [Range(0, double.MaxValue, ErrorMessage = "As despesas devem ser um valor positivo.")]
        public double Despesas { get; set; }

    }
}