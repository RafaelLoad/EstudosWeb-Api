using Estudos.Domain.Entities;
using FluentValidation;

//nome, telefone, email, ddd

namespace Estudos.Domain.Validator
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().WithMessage("Endereço Email é obrigatório").EmailAddress().WithMessage("Digite um email valido");
            RuleFor(x => x.CPF).NotEmpty().WithMessage("CPF é obrigatório").IsValidCPF();
            RuleFor(x => x.RG).NotEmpty().WithMessage("RF é obrigatório").MaximumLength(9);

            RuleFor(x => x.Endereco.CEP).NotEmpty().WithMessage("Por favor, digite o CEP");
            RuleFor(x => x.Endereco.Numero).GreaterThan(0);

            RuleForEach(x => x.Contato).ChildRules(contato => {

                contato.RuleFor(x => x.Telefone).NotEmpty().WithMessage("Telefone é obrigatório").GreaterThan(9);
                contato.RuleFor(x => x.DDD).NotEmpty().WithMessage("DDD é obrigatório").GreaterThan(2);
                contato.RuleFor(x => x.Tipo).NotEmpty().WithMessage("O campo tipo é obrigatório");
            });

        }
    }
}
