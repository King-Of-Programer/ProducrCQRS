using FluentValidation;
using MediatR;
using ProducrCQRS.Models;
using ProducrCQRS.Profiles;

namespace ProducrCQRS.CQRS.Command
{
    public class CreateProductCommandRequst : IRequest<Result<ProductViewProfile>>
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string Code { set; get; }
        public Guid CategoryId { set; get; }
        public int Discount { set; get; }
        public int Quantity { set; get; }

    }

    public class CreateProductValidator : AbstractValidator<CreateProductCommandRequst>
    {
        public  CreateProductValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Product name cannot be empty");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater then 0");
            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage("Code name cannot be empty")
                .Matches(@"^\d{13}$")
                .WithMessage("Barcode must contain exactly 13 digits");
            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("CategoryId name cannot be empty");

            RuleFor(x => x.Discount)
                .InclusiveBetween(0, 100)
                .WithMessage("Price must be greater then 0 and less then 100");

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater then 0");

        }
    }

}
