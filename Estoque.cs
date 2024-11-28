using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pjt_Software.Contexts;
using Pjt_Software.Validators;

namespace Pjt_Software.Models;

/*===== Estoque =====*/

public class Estoque
{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do item é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do item não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição não pode exceder 500 caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O preço de compra é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O preço de compra deve ser um valor positivo.")]
        public double PrecoCompra { get; set; }

        [Required(ErrorMessage = "O preço de venda é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O preço de venda deve ser um valor positivo.")]
        public double PrecoVenda { get; set; }

}