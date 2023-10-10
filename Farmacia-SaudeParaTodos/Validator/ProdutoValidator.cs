using Farmacia_SaudeParaTodos.Model;
using FluentValidation;

namespace Farmacia_SaudeParaTodos.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator() 
        {
            RuleFor(p => p.Nome)
               .NotEmpty()
               .MinimumLength(3)
               .MaximumLength(255);

            RuleFor(p => p.DataFabricacao)
                .NotEmpty()
                .GreaterThanOrEqualTo(u => DateTime.Today.AddYears(-20)).WithMessage("Insira uma data de Fabricação valida!")
                .LessThanOrEqualTo(u => DateTime.Today).WithMessage("Insira uma data de Fabricação válida!");

            RuleFor(p => p.Preco)
                .GreaterThan(0)
                .PrecisionScale(8, 2, false);
        }
    }
}
