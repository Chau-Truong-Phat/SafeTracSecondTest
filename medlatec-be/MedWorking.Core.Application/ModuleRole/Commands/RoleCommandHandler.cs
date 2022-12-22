using AutoMapper;
using FluentValidation.Results;
using MediatR;
using MedWorking.Core.Application.ModuleRole.Commands.ActionCommands;
using MedWorking.Core.Application.ModuleRole.Models;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace MedWorking.Core.Application.ModuleRole.Commands;

public class RoleCommandHandler : IRequestHandler<AddRoleCommand, RoleCommandResponse>, IRequestHandler<EditRoleCommand, RoleCommandResponse>, IRequestHandler<DeleteRoleCommand, RoleCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly MedWorkingContext _context;

    public RoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, MedWorkingContext context)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = context;
    }

    public async Task<RoleCommandResponse> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var validator = new RoleValidator(_unitOfWork,EnumActionName.ADD);
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new RoleCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var data = _mapper.Map<Role>(request);
                data.Id = Guid.NewGuid();
                data.CreateDate = DateTime.UtcNow;
                data.UpdateDate = DateTime.UtcNow;
                if (request.ListRole!.Count > 0)
                {
                    await InsertRole(request.ListRole, data.Id);
                }
                await _unitOfWork.GetRepository<Role>().InsertAsync(data, cancellationToken);
                await _unitOfWork.SaveChangesAsync();

                var result = _mapper.Map<RoleModel>(data);
                await transaction.CommitAsync(cancellationToken);
                return new RoleCommandResponse { isSuccess = true, Result = result, Message = ErrorMessage.Add_Success };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new RoleCommandResponse(validationResult.Errors) { Message = ErrorMessage.Eror_UserRole };
            }
        }
    }

    public async Task<RoleCommandResponse> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        var validator = new RoleValidator(_unitOfWork,EnumActionName.EDIT);
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new RoleCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }
        var data = await _unitOfWork.GetRepository<Role>().GetFirstOrDefaultAsync(predicate: x => x.Id == request.Id);
        if (data != null)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (request.ListRole!.Count > 0)
                    {
                        await InsertRole(request.ListRole, data.Id);
                    }
                    data.CreateUser = (request.CreateUser != null) ? request.CreateUser : data.CreateUser;
                    data.CreateDate = (request.CreateDate != null) ? request.CreateDate : data.CreateDate;
                    data.UpdateUser = request.UpdateUser;
                    data.RoleCode = request.RoleCode;
                    data.RoleName = request.RoleName;
                    data.Description = request.Description;
                    var objRole = _mapper.Map<Role>(data);
                    objRole.UpdateDate = DateTime.UtcNow;

                    _unitOfWork.GetRepository<Role>().Update(objRole);
                    await _unitOfWork.SaveChangesAsync();

                    var result = _mapper.Map<RoleModel>(objRole);

                    await transaction.CommitAsync(cancellationToken);
                    return new RoleCommandResponse { isSuccess = true, Result = result, Message = ErrorMessage.Edit_Success };
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return new RoleCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error };
                }
            }
        }
        else
        {
            return new RoleCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error };
        }
    }

    public async Task<RoleCommandResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = new ValidationResult();
        var data = await _unitOfWork.GetRepository<Role>().GetFirstOrDefaultAsync(predicate: x => x.Id == request.Id);
        if (data != null)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var userRoles = await _unitOfWork.GetRepository<UserIdRole>().GetByWhere(predicate: x => x.RoleId == data.Id).ToListAsync(cancellationToken);
                    if (userRoles.Count > 0)
                    {
                        return new RoleCommandResponse(validationResult.Errors) { Message = ErrorMessage.Eror_NotExistDelete };
                    }
                    await RemoveRole(data.Id);

                    _unitOfWork.GetRepository<Role>().Delete(data);
                    await DeleteRoleDecentralize(request.Id);

                    await _unitOfWork.SaveChangesAsync();
                    await transaction.CommitAsync(cancellationToken);
                    return new RoleCommandResponse { isSuccess = true, Message = ErrorMessage.Delete_Success };
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return new RoleCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error_Delete };
                }
            }

        }
        else
        {
            return new RoleCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error_Delete };
        }
    }
    private async Task InsertRole(List<ListRoleModel> lstRole, Guid roleId)
    {
        await RemoveRole(roleId);
        var lstDecRoles = new List<RoleDecentralize>();
        foreach (var item in lstRole)
        {
            var model = new RoleDecentralize();
            model.Id = Guid.NewGuid();
            model.RoleId = roleId;
            model.DecentralizeId = item.Id;
            model.ParentId = item.Parent;
            lstDecRoles.Add(model);
        }
        await _unitOfWork.GetRepository<RoleDecentralize>().InsertAsync(lstDecRoles);
        await _unitOfWork.SaveChangesAsync();
    }

    private async Task RemoveRole(Guid roleId)
    {
         _unitOfWork.GetRepository<RoleDecentralize>().DeleteByWhere(x => x.RoleId == roleId);
        await _unitOfWork.SaveChangesAsync();
    }
    private async Task DeleteRoleDecentralize(Guid RoleId)
    {
        _unitOfWork.GetRepository<RoleDecentralize>().DeleteByWhere(x => x.RoleId == RoleId);
        await _unitOfWork.SaveChangesAsync();
    }
}
