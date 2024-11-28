using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pjt_Software.Models;
using Pjt_Software.Validators;

namespace Pjt_Software.Models;


/*===== Empresa =====*/

public class Empresa
{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail da empresa é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail não é válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(8, MinimumLength = 3, ErrorMessage = "A senha deve ter entre {2} e {1} caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, uma letra minúscula e um número.")]
        public string Senha { get; set; } = string.Empty;

}
