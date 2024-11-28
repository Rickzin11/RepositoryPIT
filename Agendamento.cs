using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pjt_Software.Contexts;
using Pjt_Software.Validators;

namespace Pjt_Software.Models;

/*===== Agendamento =====*/

public class Agendamento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "O e-mail não é válido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O número de celular é obrigatório.")]
    [RegularExpression(@"^\(?\d{2}\)?\s?\d{5}-\d{4}$", ErrorMessage = "O número de celular deve estar no formato (XX) XXXXX-XXXX.")]
    public string NumeroCelular { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "A data é obrigatória.")]
    [FutureOrPresent] // Usando o atributo de validação personalizado
    public DateOnly Data { get; set; }

    [Required(ErrorMessage = "A hora é obrigatória.")]
    public TimeOnly Hora { get; set; }

}

