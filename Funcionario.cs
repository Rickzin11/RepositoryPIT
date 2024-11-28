using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pjt_Software.Contexts;
using Pjt_Software.Validators;

namespace Pjt_Software.Models;

/*===== Funcionario =====*/

    public class Funcionario
{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]     
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O cargo é obrigatório.")]
        [StringLength(50, ErrorMessage = "O cargo não pode exceder 50 caracteres.")]
        public string Cargo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail não é válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve ter 11 dígitos.")]
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "O salário é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O salário deve ser um valor positivo.")]
        public double Salario { get; set; } = 0.0;
        
}