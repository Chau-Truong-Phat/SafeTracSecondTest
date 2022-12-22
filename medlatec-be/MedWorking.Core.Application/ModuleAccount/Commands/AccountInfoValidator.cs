using FluentValidation;
using MedWorking.Core.Common.UnitOfWork;

namespace MedWorking.Core.Application.ModuleAccount.Commands;

public class AccountInfoValidator : AbstractValidator<AccountInfoCommand>
{
    public AccountInfoValidator(IUnitOfWork unitOfWork)
    {
    }
    
}
