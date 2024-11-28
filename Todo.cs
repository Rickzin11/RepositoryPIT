using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pjt_Software.Contexts;
using Pjt_Software.Validators;

namespace Pjt_Software.Models;

public class Todo
{
    public int Id { get; set; }

    [Display (Name = "Titulo")]
    [Required(ErrorMessage ="O campo {0} é obrigatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
    public string Title { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    
    [Display (Name = "Data de entrega")]
    [Required(ErrorMessage ="O campo {0} é obrigatorio")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [FutureOrPresent]
    public DateOnly DeadLine { get; set; }
    public DateOnly? FinishedAt{ get; set; }

}




