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
             .NotEmpty();

            RuleFor(p => p.Preco)
                .GreaterThan(0)
                .PrecisionScale(8, 2, false);
        }
    }
}
