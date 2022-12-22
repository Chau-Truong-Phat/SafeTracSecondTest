using AutoMapper;
using FluentValidation.Results;
using MediatR;
using MedWorking.Core.Application.ModulUserRole.Commands.ActionCommands;
using MedWorking.Core.Application.ModulUserRole.Models;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModulUserRole.Commands;

public class UserRoleCommandHandler
                                : IRequestHandler<AddUserRoleRequestCommand, UserRoleCommandResponse>
                                , IRequestHandler<EditUserRoleRequestCommand, UserRoleCommandResponse>
                                , IRequestHandler<DeleteUserRoleRequestCommand, UserRoleCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly MedWorkingContext _context;

    public UserRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, MedWorkingContext medWorkingContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = medWorkingContext;
    }
    public async Task<UserRoleCommandResponse> Handle(AddUserRoleRequestCommand request, CancellationToken cancellationToken)
    {
        var employee = _unitOfWork.GetRepository<Account>().GetByWhere(x => x.EmployeeId == request.EmployeeCode).FirstOrDefault();
        UserRoleValidator validator = new UserRoleValidator(_unitOfWork, employee?.FullName!);
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new UserRoleCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var data = _mapper.Map<UserRole>(request);
                data.UserId = Guid.NewGuid();
                data.CreateDate = DateTime.UtcNow;
                data.UpdateDate = DateTime.UtcNow;
                if (request.ListRole!.Count > 0)
                {
                   await InsertUserRole(request.ListRole, data.UserId);
                }
                await _unitOfWork.GetRepository<UserRole>().InsertAsync(data,cancellationToken);
                await _unitOfWork.SaveChangesAsync();
                var result = _mapper.Map<UserRoleModel>(data);
                await transaction.CommitAsync(cancellationToken);
                return new UserRoleCommandResponse { isSuccess = true, Result = result, Message = ErrorMessage.Add_Success };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new UserRoleCommandResponse(validationResult.Errors) { Message = ErrorMessage.Eror_UserRole };
            }
        }
    }

    public async Task<UserRoleCommandResponse> Handle(EditUserRoleRequestCommand request, CancellationToken cancellationToken)
    {
        var employee = _unitOfWork.GetRepository<Account>().GetByWhere(x => x.EmployeeId == request.EmployeeCode).FirstOrDefault();
        UserRoleValidator validator = new UserRoleValidator(_unitOfWork, employee?.FullName!);
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new UserRoleCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }

        var data = await _unitOfWork.GetRepository<UserRole>().GetFirstOrDefaultAsync(predicate: x => x.UserId == request.UserId);
        if (data != null)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var objDoc = _mapper.Map<UserRole>(request);
                    objDoc.CreateDate = data.CreateDate;
                    if (request.ListRole!.Count > 0)
                    {
                        await InsertUserRole(request.ListRole, data.UserId);
                    }
                    _unitOfWork.GetRepository<UserRole>().Update(objDoc);
                    await _unitOfWork.SaveChangesAsync();

                    var result = _mapper.Map<UserRoleModel>(objDoc);
                    await transaction.CommitAsync(cancellationToken);
                    return new UserRoleCommandResponse { isSuccess = true, Result = result, Message = ErrorMessage.Edit_Success };
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return new UserRoleCommandResponse(validationResult.Errors) { Message = ErrorMessage.Eror_UserRole };
                }
            }
        }
        else
        {
            return new UserRoleCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error };
        }
    }

    public async Task<UserRoleCommandResponse> Handle(DeleteUserRoleRequestCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = new ValidationResult();
        var data = await _unitOfWork.GetRepository<UserRole>().GetFirstOrDefaultAsync(predicate: x => x.UserId == request.UserId);
        if (data != null)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _unitOfWork.GetRepository<UserIdRole>().DeleteByWhere(x => x.UserId == data.UserId);
                    await _unitOfWork.SaveChangesAsync();

                    await RemoveUserIdRole(data.UserId);

                    _unitOfWork.GetRepository<UserRole>().Delete(data);
                    await _unitOfWork.SaveChangesAsync();

                    await transaction.CommitAsync(cancellationToken);
                    return new UserRoleCommandResponse { isSuccess = true, Message = ErrorMessage.Delete_Success };
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return new UserRoleCommandResponse(validationResult.Errors) { Message = ErrorMessage.Eror_UserRole };
                }
            }
        }
        else
        {
            return new UserRoleCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error_Delete };
        }
    }

    private async Task InsertUserRole(List<Guid> lstRole,Guid userId)
    {
        await RemoveUserIdRole(userId);

        var lstUserRoles = new List<UserIdRole>();
        foreach (var item in lstRole)
        {
            var model = new UserIdRole();
            model.Id = Guid.NewGuid();
            model.UserId = userId;
            model.RoleId = item;
            lstUserRoles.Add(model);
        }    
         await _unitOfWork.GetRepository<UserIdRole>().InsertAsync(lstUserRoles);
         await _unitOfWork.SaveChangesAsync();
    }
    private async Task RemoveUserIdRole(Guid userId)
    {
         _unitOfWork.GetRepository<UserIdRole>().DeleteByWhere(x => x.UserId == userId);
        await _unitOfWork.SaveChangesAsync();
    }
}
