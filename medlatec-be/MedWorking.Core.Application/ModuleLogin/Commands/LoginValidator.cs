using FluentValidation;
using MedWorking.Core.Common.UnitOfWork;

namespace MedWorking.Core.Application.ModuleLogin.Commands;

public class LoginValidator : AbstractValidator<LoginCommand>
{
    public LoginValidator()
    {
        RuleFor(x => x).Custom((request, context) => {
            if (request.UserName == "" || request.Password == "")
            {
                context.AddFailure("Vui lòng nhập tài khoản và mật khẩu.");
            }
        });



    }
}
