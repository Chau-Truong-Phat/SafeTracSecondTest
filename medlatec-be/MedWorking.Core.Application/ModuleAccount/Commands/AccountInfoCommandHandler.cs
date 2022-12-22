using AutoMapper;
using FluentValidation.Results;
using MediatR;
using MedWorking.Core.Application.ModuleAccount.Commands.ActionCommands;
using MedWorking.Core.Application.ModuleAccount.Models;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModuleAccount.Commands;

public class AccountInfoCommandHandler  : IRequestHandler<UpdateAccountInfoCommand, AccountInfoCommandResponse>
                                         
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly MedWorkingContext _context;
    public AccountInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, MedWorkingContext context)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = context;
    }

    public async Task<AccountInfoCommandResponse> Handle(UpdateAccountInfoCommand request, CancellationToken cancellationToken)
    {
        AccountInfoValidator validator = new AccountInfoValidator(_unitOfWork);
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new AccountInfoCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }
        var data = await _unitOfWork.GetRepository<Account>().GetFirstOrDefaultAsync(predicate: x => x.UserName!.ToLower() == request.UserName!.ToLower());
        if (data != null)
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    data.CreateDate = request.CreateDate;
                    data.CreateUser = request.CreateUser;
                    data.UpdateUser = request.UpdateUser;
                    data.UpdateDate = DateTime.UtcNow;
                    data.AvatarUrl = (request.AvatarUrl != null) ? request.AvatarUrl : data.AvatarUrl;
                    data.SignatureUrl = (request.SignatureUrl != null) ? request.SignatureUrl : data.SignatureUrl;
                    data.SerialNumber = (request.SerialNumber != null) ? request.SerialNumber : data.SerialNumber;
                    _unitOfWork.GetRepository<Account>().Update(data);
                    await _unitOfWork.SaveChangesAsync();
                    var result = _mapper.Map<AccountInfoModel>(data);

                    await transaction.CommitAsync(cancellationToken);
                    return new AccountInfoCommandResponse { isSuccess = true, Result = result, Message = ErrorMessage.Edit_Success };
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return new AccountInfoCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error };
                }
            }
        }
        else
        {
            return new AccountInfoCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error};
        }
    }
}
