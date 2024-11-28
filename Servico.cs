using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pjt_Software.Contexts;
using Pjt_Software.Validators;

namespace Pjt_Software.Models;

    /*===== Servico =====*/

public class Servico
{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]     
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do serviço é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do serviço não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "A descrição não pode exceder 500 caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser um valor positivo.")]
        public double Preco { get; set; } = 0.0;

}
