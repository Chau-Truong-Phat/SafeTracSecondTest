using AutoMapper;
using FluentValidation.Results;
using MediatR;
using MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Commands.ActionCommands;
using MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Models;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;


namespace MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Commands;

public class ApprovalGeneralDocProcessCommandHandler
    : IRequestHandler<AddApprovalGeneralDocProcessRequestCommand, ApprovalGeneralDocProcessCommandResponse>
    , IRequestHandler<EditApprovalGeneralDocProcessRequestCommand, ApprovalGeneralDocProcessCommandResponse>
    , IRequestHandler<DeleteApprovalGeneralDocProcessRequestCommand, ApprovalGeneralDocProcessCommandResponse>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly MedWorkingContext _context;

    public ApprovalGeneralDocProcessCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, MedWorkingContext medWorkingContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = medWorkingContext;
    }

    public async Task<ApprovalGeneralDocProcessCommandResponse> Handle(AddApprovalGeneralDocProcessRequestCommand request, CancellationToken cancellationToken)
    {
        var groupDoc =await _unitOfWork.GetRepository<GroupDocument>().GetByWhere(x => x.GroupDocId == request.GroupDocumentId).FirstOrDefaultAsync(cancellationToken) ;
        var paternDocs = _unitOfWork.GetRepository<PatternDocument>().GetByWhere(x => x.GroupDocId == request.GroupDocumentId && request.ListPatternDocumentGeneral!.Select(x => x.PatternDocumentId).Contains(x.PatternDocId)).Select(x=>x.PatternDocName).ToList();
        string patternDocName = string.Join(",", paternDocs);
        
        var validator = new ApprovalGeneralDocProcessCommandValidator(_unitOfWork, EnumActionName.ADD,groupDoc!.GroupDocName!, patternDocName!,request.TimeApplication);
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new ApprovalGeneralDocProcessCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }

        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var data = _mapper.Map<EntityFramework.Models.ApprovalGeneralDocumentProcess>(request);
                data.Id = Guid.NewGuid();
                data.CreateDate = DateTime.UtcNow;
                data.UpdateDate = DateTime.UtcNow;

                await InsertAndUpdatePatternDocByGroupDocGeneral(request.ListPatternDocumentGeneral!, data.Id, data.GroupDocumentId);

                await InsertAndUpdateTextBrowsingStep(request.ListTextBrowsingStepGeneral!, data.Id);

                await _unitOfWork.GetRepository<EntityFramework.Models.ApprovalGeneralDocumentProcess>().InsertAsync(data, cancellationToken);
                await _unitOfWork.SaveChangesAsync();
                var result = _mapper.Map<ApprovalGeneralDocumentProcessModel>(data);
                result.ListPatternDocumentGeneral = request.ListPatternDocumentGeneral;
                result.ListTextBrowsingStepGeneral = request.ListTextBrowsingStepGeneral;

                await transaction.CommitAsync(cancellationToken);
                return new ApprovalGeneralDocProcessCommandResponse { isSuccess = true, Result = result, Message = ErrorMessage.Add_Success };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new ApprovalGeneralDocProcessCommandResponse(validationResult.Errors) { Message = ErrorMessage.ErrorAdd };
            }
        }

    }

    public async Task<ApprovalGeneralDocProcessCommandResponse> Handle(EditApprovalGeneralDocProcessRequestCommand request, CancellationToken cancellationToken)
    {
        var groupDoc = await _unitOfWork.GetRepository<GroupDocument>().GetByWhere(x => x.GroupDocId == request.GroupDocumentId).FirstOrDefaultAsync(cancellationToken);
        var paternDocs = _unitOfWork.GetRepository<PatternDocument>().GetByWhere(x => x.GroupDocId == request.GroupDocumentId && request.ListPatternDocumentGeneral!.Select(x => x.PatternDocumentId).Contains(x.PatternDocId)).Select(x => x.PatternDocName).ToList();
        string patternDocName = string.Join(",", paternDocs);
        if(paternDocs != null) { groupDoc!.GroupDocName = null; }
        var validator = new ApprovalGeneralDocProcessCommandValidator(_unitOfWork, EnumActionName.EDIT, groupDoc!.GroupDocName!, patternDocName!, request.TimeApplication);

        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new ApprovalGeneralDocProcessCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }
        var data = await _unitOfWork.GetRepository<EntityFramework.Models.ApprovalGeneralDocumentProcess>().GetFirstOrDefaultAsync(predicate: x => x.Id == request.Id);
        if (data != null)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var obj = _mapper.Map<EntityFramework.Models.ApprovalGeneralDocumentProcess>(request);
                    obj.CreateDate = data.CreateDate;
                    obj.CreateUser = data.CreateUser;

                    if (data.TimeApplication < DateTime.UtcNow)
                    {
                        obj.GroupDocumentId = data.GroupDocumentId;
                        obj.TimeApplication = data.TimeApplication;
                        obj.Description = request.Description;
                        obj.Active = request.Active;
                        obj.UpdateUser = request.UpdateUser;
                        obj.UpdateDate = request.UpdateDate;
                    }

                    await InsertAndUpdateTextBrowsingStep(request.ListTextBrowsingStepGeneral!, data.Id);

                    if (data.TimeApplication > DateTime.Now)
                    {
                        await InsertAndUpdatePatternDocByGroupDocGeneral(request.ListPatternDocumentGeneral!, data.Id, obj.GroupDocumentId);
                    }

                    _unitOfWork.GetRepository<EntityFramework.Models.ApprovalGeneralDocumentProcess>().Update(obj);
                    await _unitOfWork.SaveChangesAsync();

                    var result = _mapper.Map<ApprovalGeneralDocumentProcessModel>(obj);
                    result.ListPatternDocumentGeneral = request.ListPatternDocumentGeneral!;
                    result.ListTextBrowsingStepGeneral = request.ListTextBrowsingStepGeneral!;

                    await transaction.CommitAsync(cancellationToken);
                    return new ApprovalGeneralDocProcessCommandResponse { isSuccess = true, Result = result, Message = ErrorMessage.Edit_Success };
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return new ApprovalGeneralDocProcessCommandResponse(validationResult.Errors) { Message = ErrorMessage.ErrorEdit };
                }
            }
        }
        else
        {
            return new ApprovalGeneralDocProcessCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error };
        }
    }

    public async Task<ApprovalGeneralDocProcessCommandResponse> Handle(DeleteApprovalGeneralDocProcessRequestCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = new();
        var data = await _unitOfWork.GetRepository<EntityFramework.Models.ApprovalGeneralDocumentProcess>().GetFirstOrDefaultAsync(predicate: x => x.Id == request.Id && x.Active == false);
        if (data != null)
        {
            using (var transacion = _context.Database.BeginTransaction())
            {
                try
                {
                    await RemoveTextBrowsingSteps(data.Id);
                    await RemovePatternDocGeneral(data.Id);

                    _unitOfWork.GetRepository<EntityFramework.Models.ApprovalGeneralDocumentProcess>().Delete(data);
                    await _unitOfWork.SaveChangesAsync();

                    await transacion.CommitAsync(cancellationToken);
                    return new ApprovalGeneralDocProcessCommandResponse { isSuccess = true, Message = ErrorMessage.Delete_Success };
                }
                catch (Exception)
                {
                    await transacion.RollbackAsync(cancellationToken);
                    return new ApprovalGeneralDocProcessCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error_Delete };
                }
            }
        }
        else
        {
            return new ApprovalGeneralDocProcessCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error_ApprovalGeneralDocProcessDelete };
        }
    }

    private async Task InsertAndUpdatePatternDocByGroupDocGeneral(List<PatternDocDetailByGroupDocGeneral> lstPatternDocGeneral, Guid Id, Guid? GroupDocumentId)
    {
        await RemovePatternDocGeneral(Id);
        var listObj = new List<PatternDocDetailByGroupDocGeneral>();
        foreach (var itemPatternDoc in lstPatternDocGeneral)
        {
            var model = new PatternDocDetailByGroupDocGeneral();
            model.Id = Guid.NewGuid();
            model.GroupDocumentId = GroupDocumentId;
            model.PatternDocumentId = itemPatternDoc.PatternDocumentId;
            model.ApprovalGeneralDocumentProcessId = Id;
            listObj.Add(model);
        }
        await _unitOfWork.GetRepository<PatternDocDetailByGroupDocGeneral>().InsertAsync(listObj);
        await _unitOfWork.SaveChangesAsync();
    }

    private async Task RemovePatternDocGeneral(Guid Id)
    {
         _unitOfWork.GetRepository<PatternDocDetailByGroupDocGeneral>().DeleteByWhere(x => x.ApprovalGeneralDocumentProcessId == Id);
        await _unitOfWork.SaveChangesAsync();
    }

    private async Task InsertAndUpdateTextBrowsingStep(List<TextBrowsingStep> lstStep, Guid textBrowsingId)
    {
        await RemoveTextBrowsingSteps(textBrowsingId);

        var listObj = new List<TextBrowsingStep>();
        foreach (var itemStep in lstStep)
        {
            var model = new TextBrowsingStep();
            model.Id = Guid.NewGuid();
            model.Stt = itemStep.Stt;
            model.ConfigureBrowsingStepId = itemStep.ConfigureBrowsingStepId;
            model.ApprovalGeneralDocumentProcessId = textBrowsingId;
            listObj.Add(model);
        }
        await _unitOfWork.GetRepository<TextBrowsingStep>().InsertAsync(listObj);
        await _unitOfWork.SaveChangesAsync();
    }

    private async Task RemoveTextBrowsingSteps(Guid Id)
    {
        _unitOfWork.GetRepository<TextBrowsingStep>().DeleteByWhere(x => x.ApprovalGeneralDocumentProcessId == Id);
        await _unitOfWork.SaveChangesAsync();
    }
}