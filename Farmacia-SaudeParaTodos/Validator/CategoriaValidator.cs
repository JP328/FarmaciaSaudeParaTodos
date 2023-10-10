using Farmacia_SaudeParaTodos.Model;
using FluentValidation;

namespace Farmacia_SaudeParaTodos.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator() 
        {
            RuleFor(c => c.Titulo)
               .NotEmpty()
               .MinimumLength(3)
               .MaximumLength(255);

            RuleFor(c => c.Descricao)
               .NotEmpty()
               .MinimumLength(10)
               .MaximumLength(2000);
        }
    }
}
