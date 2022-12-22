using AutoMapper;
using FluentValidation.Results;
using MediatR;
using MedWorking.Core.Application.ModuleConfigBrowsingStep.Commands.ActionCommands;
using MedWorking.Core.Application.ModuleConfigBrowsingStep.Models;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace MedWorking.Core.Application.ModuleConfigBrowsingStep.Commands;

public class ConfigBrowsingStepCommandHandler
    : IRequestHandler<AddConfigBrowsingStepCommand, ConfigBrowsingStepCommandResponse>
    , IRequestHandler<EditConfigBrowsingStepCommand, ConfigBrowsingStepCommandResponse>
    , IRequestHandler<DeleteConfigBrowsingStepCommand, ConfigBrowsingStepCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly MedWorkingContext _context;

    public ConfigBrowsingStepCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, MedWorkingContext medWorkingContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = medWorkingContext;
    }
    public async Task<ConfigBrowsingStepCommandResponse> Handle(AddConfigBrowsingStepCommand request, CancellationToken cancellationToken)
    {
        ConfigBrowsingStepCommandValidator validator = new ConfigBrowsingStepCommandValidator(EnumActionName.ADD);
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new ConfigBrowsingStepCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var data = _mapper.Map<ConfigureBrowsingStep>(request);
                data.Id = Guid.NewGuid();
                data.CreateDate = DateTime.UtcNow;
                data.UpdateDate = DateTime.UtcNow;
                if (request.ListOffice!.Count > 0)
                {
                    await InsertAndUpdateConfigBrowsingStep(request.ListOffice, data.Id);
                }

                await _unitOfWork.GetRepository<ConfigureBrowsingStep>().InsertAsync(data,cancellationToken);
                await _unitOfWork.SaveChangesAsync();
                var result = _mapper.Map<ConfigBrowsingStepModel>(data);
                result.ListOffice = request.ListOffice;
                await transaction.CommitAsync(cancellationToken);

                return new ConfigBrowsingStepCommandResponse { isSuccess = true, Result = result, Message = ErrorMessage.Add_Success };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new ConfigBrowsingStepCommandResponse(validationResult.Errors) { Message = ErrorMessage.ErrorAdd };
            }
        }
    }
    public async Task<ConfigBrowsingStepCommandResponse> Handle(EditConfigBrowsingStepCommand request, CancellationToken cancellationToken)
    {
        ConfigBrowsingStepCommandValidator validator = new ConfigBrowsingStepCommandValidator(EnumActionName.EDIT);
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new ConfigBrowsingStepCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }

        var data = await _unitOfWork.GetRepository<ConfigureBrowsingStep>().GetFirstOrDefaultAsync(predicate: x => x.Id == request.Id);
        if (data != null)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var objConfigBrowsingStep = _mapper.Map<ConfigureBrowsingStep>(request);
                    objConfigBrowsingStep.CreateDate = data.CreateDate;
                    objConfigBrowsingStep.CreateUser = request.CreateUser;
                    if (request.ListOffice!.Count > 0)
                    {
                        await InsertAndUpdateConfigBrowsingStep(request.ListOffice, request.Id);
                    }
                    _unitOfWork.GetRepository<ConfigureBrowsingStep>().Update(objConfigBrowsingStep);
                    await _unitOfWork.SaveChangesAsync();
                    var result = _mapper.Map<ConfigBrowsingStepModel>(objConfigBrowsingStep);
                    result.ListOffice = request.ListOffice;

                    await transaction.CommitAsync(cancellationToken);
                    return new ConfigBrowsingStepCommandResponse { isSuccess = true, Result = result, Message = ErrorMessage.Edit_Success };
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return new ConfigBrowsingStepCommandResponse(validationResult.Errors) { Message = ErrorMessage.ErrorAdd };
                }
            }
        }
        else
        {
            return new ConfigBrowsingStepCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error };
        }
    }
    public async Task<ConfigBrowsingStepCommandResponse> Handle(DeleteConfigBrowsingStepCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = new ();
        var data = await _unitOfWork.GetRepository<ConfigureBrowsingStep>().GetFirstOrDefaultAsync(predicate: x => x.Id == request.Id);
        if (data != null)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var listObjStep = await _unitOfWork.GetRepository<TextBrowsingStep>().GetByWhere(x => x.ConfigureBrowsingStepId == data.Id).ToListAsync(cancellationToken);
                    var listObjStepUnit = await _unitOfWork.GetRepository<TextBrowsingStepsUnit>().GetByWhere(x => x.ConfigureBrowsingStepId == data.Id).ToListAsync(cancellationToken);
                    if (listObjStep.Count > 0 || listObjStepUnit.Count > 0)
                    {
                        return new ConfigBrowsingStepCommandResponse(validationResult.Errors) { Message = ErrorMessage.Eror_DeleteStepActive };
                    }

                    await RemoveImplementingAgency(data.Id);

                    _unitOfWork.GetRepository<ConfigureBrowsingStep>().Delete(data);
                    await _unitOfWork.SaveChangesAsync();

                    await transaction.CommitAsync(cancellationToken);
                    return new ConfigBrowsingStepCommandResponse { isSuccess = true, Message = ErrorMessage.Delete_Success };
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return new ConfigBrowsingStepCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error_Delete };
                }
            }
        }
        else
        {
            return new ConfigBrowsingStepCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error };
        }
    }
    private async Task InsertAndUpdateConfigBrowsingStep(List<OfficeImplement> lstOfficeId, Guid configStepId)
    {
        await RemoveImplementingAgency(configStepId);

        var listObj = new List<ImplementingAgency>();
        var listObjEmployee = new List<UserImplement>();

        foreach (var itemOffice in lstOfficeId)
        {
            ImplementingAgency model = new();
            model.Id = Guid.NewGuid();
            model.ConfigStepId = configStepId;
            model.ApprovalLevel = itemOffice.ApprovalLevel;
            model.Description = itemOffice.Description;
            model.OfficeImplementId = itemOffice.OfficeImplementId;
            listObj.Add(model);
            foreach (var itemUser in itemOffice.ListUserImplements!)
            {
                UserImplement modelEmployee = new ();
                modelEmployee.Id = Guid.NewGuid();
                modelEmployee.OfficeImplementId = itemOffice.OfficeImplementId;
                modelEmployee.ConfigureBrowsingStepId = configStepId;
                modelEmployee.EmployeeId = itemUser;
                listObjEmployee.Add(modelEmployee);
            }
        }
        if(listObjEmployee.Count >0)
        {
            await _unitOfWork.GetRepository<UserImplement>().InsertAsync(listObjEmployee);
            await _unitOfWork.SaveChangesAsync();
        }
        await _unitOfWork.GetRepository<ImplementingAgency>().InsertAsync(listObj);
        await _unitOfWork.SaveChangesAsync();
    }
    private async Task RemoveImplementingAgency(Guid configStepId)
    {
        _unitOfWork.GetRepository<ImplementingAgency>().DeleteByWhere(x => x.ConfigStepId == configStepId);
        await _unitOfWork.SaveChangesAsync();

        _unitOfWork.GetRepository<UserImplement>().DeleteByWhere(x => x.ConfigureBrowsingStepId == configStepId);
        await _unitOfWork.SaveChangesAsync();
    }
}
