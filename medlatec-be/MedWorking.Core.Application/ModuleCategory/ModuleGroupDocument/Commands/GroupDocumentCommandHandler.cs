using AutoMapper;
using FluentValidation.Results;
using MediatR;
using MedWorking.Core.Application.ModuleCategory.ModuleGroupDocument.Commands;
using MedWorking.Core.Application.ModuleCategory.ModuleGroupDocument.Commands.ActionCommands;
using MedWorking.Core.Application.ModuleCategory.ModuleGroupDocument.Models;
using MedWorking.Core.Application.ModuleGroupDocument.Commands.ActionCommands;
using MedWorking.Core.Application.ModuleGroupDocument.Models;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MedWorking.Core.Application.ModuleGroupDocument.Commands;

public class GroupDocumentCommandHandler
    : IRequestHandler<AddGroupDocumentRequestCommand, GroupDocumentCommandResponse>
    , IRequestHandler<EditGroupDocumentRequestCommand, GroupDocumentCommandResponse>
    , IRequestHandler<DeleteGroupDocumentRequestCommand, GroupDocumentCommandResponse>
    , IRequestHandler<AddConfigColumnRequestCommand, ConfigColumnCommandReponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GroupDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<GroupDocumentCommandResponse> Handle(AddGroupDocumentRequestCommand request, CancellationToken cancellationToken)
    {
        GroupDocumentValidator validator = new GroupDocumentValidator(EnumActionName.ADD,_unitOfWork);
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new GroupDocumentCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }

        var data = _mapper.Map<GroupDocument>(request);
        data.GroupDocId = Guid.NewGuid();
        data.CreateDate = DateTime.UtcNow;
        await _unitOfWork.GetRepository<GroupDocument>().InsertAsync(data,cancellationToken);
        await _unitOfWork.SaveChangesAsync();
        var result = _mapper.Map<GroupDocumentModel>(data);
        return new GroupDocumentCommandResponse { isSuccess = true, Result = result, Message = ErrorMessage.Add_Success };
    }
    public async Task<ConfigColumnCommandReponse> Handle(AddConfigColumnRequestCommand request, CancellationToken cancellationToken)
    {
        var configColumn = await _unitOfWork.GetRepository<ConfigColumn>().GetByWhere(predicate: x => x.ViewType == request.ViewType).FirstOrDefaultAsync(cancellationToken);
        if (configColumn != null)
        {
            string jsonObject = JsonConvert.SerializeObject(request.ListColumns);
            configColumn.InfoJson = jsonObject;

            _unitOfWork.GetRepository<ConfigColumn>().Update(configColumn);
            await _unitOfWork.SaveChangesAsync();

            var result = _mapper.Map<ConfigColumnModel>(configColumn);
            result.ListColumns = request.ListColumns;
            return new ConfigColumnCommandReponse { isSuccess = true, Result = result, Message = ErrorMessage.Edit_Success };
        }
        else
        {
            var data = _mapper.Map<ConfigColumn>(request);
            data.Id = Guid.NewGuid();

            data.CreateDate = DateTime.UtcNow;
            string jsonObject = JsonConvert.SerializeObject(request.ListColumns);
            data.InfoJson = jsonObject;

            await _unitOfWork.GetRepository<ConfigColumn>().InsertAsync(data,cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            var result = _mapper.Map<ConfigColumnModel>(data);
            result.ListColumns = request.ListColumns;
            return new ConfigColumnCommandReponse { isSuccess = true, Result = result, Message = ErrorMessage.Add_Success };
        }
    }
    public async Task<GroupDocumentCommandResponse> Handle(EditGroupDocumentRequestCommand request, CancellationToken cancellationToken)
    {
        GroupDocumentValidator validator = new GroupDocumentValidator(EnumActionName.EDIT,_unitOfWork);
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new GroupDocumentCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }

        var data = await _unitOfWork.GetRepository<GroupDocument>().GetFirstOrDefaultAsync(predicate: x => x.GroupDocId == request.GroupDocId);
        if (data != null)
        {
            var objDoc = _mapper.Map<GroupDocument>(request);
            objDoc.CreateDate = data.CreateDate;
            _unitOfWork.GetRepository<GroupDocument>().Update(objDoc);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<GroupDocumentModel>(objDoc);
            return new GroupDocumentCommandResponse { isSuccess = true, Result = result, Message = ErrorMessage.Edit_Success };
        }
        else
        {
            return new GroupDocumentCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error };
        }
    }

    public async Task<GroupDocumentCommandResponse> Handle(DeleteGroupDocumentRequestCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = new ValidationResult();
        var data = await _unitOfWork.GetRepository<GroupDocument>().GetFirstOrDefaultAsync(predicate: x => x.GroupDocId.ToString() == request.GroupDocId && x.DocActive == false);
        if (data != null)
        {
            var datachecks =await _unitOfWork.GetRepository<PatternDocument>().GetByWhere(predicate: x => x.GroupDocId == data.GroupDocId).ToListAsync(cancellationToken);
            if (datachecks.Count >0)
            {
                return new GroupDocumentCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error_PatternDocExistCannotDelete };
            }
            _unitOfWork.GetRepository<GroupDocument>().Delete(data);
            await _unitOfWork.SaveChangesAsync();
            return new GroupDocumentCommandResponse { isSuccess = true, Message = ErrorMessage.Delete_Success };
        }
        else
        {
            return new GroupDocumentCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error_DeleteGroupDocument };
        }
    }
}
