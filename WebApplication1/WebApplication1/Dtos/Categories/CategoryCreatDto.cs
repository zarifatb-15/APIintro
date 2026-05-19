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
    public IFormFile? Photo { get; set; }
}

public class CategoryCreatDtoValidator : AbstractValidator<CategoryCreatDto>
{
    public CategoryCreatDtoValidator()
    {
        RuleFor(c => c.Photo)
            .Cascade(CascadeMode.Stop)

            .NotNull()
            .WithMessage("Photo is required.")

            .Must(file =>
                file!.ContentType == "image/jpeg" ||
                file.ContentType == "image/png" ||
                file.ContentType == "image/gif")
            .WithMessage("Only JPEG, PNG, and GIF files are allowed.")

            .Must(file => file!.Length <= 2 * 1024 * 1024)
            .WithMessage("File size must be less than or equal to 5 MB.");
    }
}