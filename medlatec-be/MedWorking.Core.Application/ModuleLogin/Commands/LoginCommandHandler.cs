using AutoMapper;
using FluentValidation.Results;
using MediatR;
using MedWorking.Core.Application.ModuleLogin.Models;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace MedWorking.Core.Application.ModuleLogin.Commands;

public class LoginCommandHandler : IRequestHandler<LoginRequest, LoginCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public LoginCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<LoginCommandResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        LoginValidator validator = new LoginValidator();
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new LoginCommandResponse(validationResult.Errors) { isSuccess = false ,Message = validationResult.Errors[0].ErrorMessage };
        }

        var accountInfo =await _unitOfWork.GetRepository<Account>().GetByWhere(x => x.UserName!.ToLower() == request.UserName!.ToLower()).FirstOrDefaultAsync(cancellationToken);
        if (accountInfo != null)
        {
            if (accountInfo.PasswordHash != request.Password)
            {
                return new LoginCommandResponse { isSuccess = false, Message = ErrorMessage.Eror_Login };
            }
            else
            {
                var result = _mapper.Map<AccountLoginModel>(accountInfo);
                return new LoginCommandResponse { isSuccess = true, Result = result };
            }
        }
        else {
            return new LoginCommandResponse { isSuccess = false, Message = ErrorMessage.Eror_LoginExits };
        }
    }
}
