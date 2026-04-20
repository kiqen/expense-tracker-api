using System.ComponentModel.DataAnnotations;

namespace Expense_Trackera.Dtos;

public class CreateCategoryDto
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(100, ErrorMessage = "Name can have max 100 characters")]
    public string Name { get; set; } = string.Empty;

}