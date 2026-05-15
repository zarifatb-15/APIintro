using System.ComponentModel.DataAnnotations;
using FluentValidation;
using WebApplication1.Attributes;

namespace WebApplication1.Dtos.Categories;

public class CategoryCreatDto
{
    // [MaxLength(100)]
    public string Name { get; set; } =null!;
    public string Description { get; set; } =null!;
    // [FileTypes("image/jpeg", "image/png", "image/gif")]
    // [FileLength(5)]
    public IFormFile Photo { get; set; }=null!;
}

public class CategoryCreatDtoValidator : AbstractValidator<CategoryCreatDto>
{
    public CategoryCreatDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name cannot exceed 100 characters.");
        
        RuleFor(c => c.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(500)
            .WithMessage("Description cannot exceed 500 characters.");
        
        RuleFor(c => c.Photo)
            .NotNull()
            .WithMessage("Photo is required.")
            .Must(file => file.ContentType == "image/jpeg" || file.ContentType == "image/png" || file.ContentType == "image/gif")
            .WithMessage("Only JPEG, PNG, and GIF files are allowed.")
            .Must(file => file.Length <= 2 * 1024 * 1024) // 5 MB
            .WithMessage("File size must be less than or equal to 5 MB.");
    }
}