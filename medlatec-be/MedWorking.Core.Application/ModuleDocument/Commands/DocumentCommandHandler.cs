using AutoMapper;
using FluentValidation.Results;
using MediatR;
using MedWorking.Core.Application.ModuleDocument.Commands.ActionCommands;
using MedWorking.Core.Application.ModuleDocument.Models;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;
using System.Linq.Expressions;

namespace MedWorking.Core.Application.ModuleDocument.Commands;

public class DocumentCommandHandler
    : IRequestHandler<AddDocumentRequestCommand, DocumentCommandResponse>
    , IRequestHandler<AddAdvisoryStaffCommand, AdvisoryStaffCommandResponse>
    , IRequestHandler<BrowseDocumentRequestCommand, DocumentCommandResponse>
    , IRequestHandler<EditDocumentRequestCommand, DocumentCommandResponse>
    , IRequestHandler<DeleteDocumentRequestCommand, DocumentCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly MedWorkingContext _context;

    public DocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, MedWorkingContext medWorkingContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = medWorkingContext;
    }

    public async Task<DocumentCommandResponse> Handle(AddDocumentRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new DocumentCommandValidator(EnumActionName.ADD, _unitOfWork);
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new DocumentCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }

        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var data = _mapper.Map<Document>(request);
                data.Id = Guid.NewGuid();
                data.CreateDate = DateTime.UtcNow;
                data.UpdateDate = DateTime.UtcNow;
                data.Status = EnumStatusDoc.DraftDoc;

                // đơn vị tham mưu
                await InsertAndUpdateDocumentAdvisory(request.ListAdvisoryUnit!, data.Id);
                // đơn vị thực hiện
                await InsertAndUpdateDocumentImplementation(request.ListImplementUnit!, data.Id);
                // văn bản liên quan
                await InsertAndUpdateDocumentReference(request.ListDocReference!, data.Id);
                // ý kiến
                await InsertAndUpdateDocumentComment(request.MsgComment!, data.Id);

                await _unitOfWork.GetRepository<Document>().InsertAsync(data, cancellationToken);
                await _unitOfWork.SaveChangesAsync();
                var result = _mapper.Map<DocumentModel>(data);
                await transaction.CommitAsync(cancellationToken);
                return new DocumentCommandResponse { isSuccess = true, Result = result, Message = ErrorMessage.Add_Success };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new DocumentCommandResponse(validationResult.Errors) { Message = ErrorMessage.ErrorAdd };
            }
        }
    }

    public async Task<AdvisoryStaffCommandResponse> Handle(AddAdvisoryStaffCommand request, CancellationToken cancellationToken)
    {
        AdvisoryStaffCommandvalidator validator = new AdvisoryStaffCommandvalidator();
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new AdvisoryStaffCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var data = _mapper.Map<AdvisoryOffice>(request);
                data.Id = Guid.NewGuid();
                //thêm mới User khi chuyển tiếp văn bản
                await InsertAdvisoryOffice(request.ListAdvisoryUser, data.Id);

                await _unitOfWork.GetRepository<AdvisoryOffice>().InsertAsync(data, cancellationToken);
                await _unitOfWork.SaveChangesAsync();
                var result = _mapper.Map<AdvisoryStaffModel>(request);
                await transaction.CommitAsync(cancellationToken);
                return new AdvisoryStaffCommandResponse { isSuccess = true, Result = result, Message = ErrorMessage.Add_Success };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new AdvisoryStaffCommandResponse(validationResult.Errors) { Message = ErrorMessage.ErrorAdd };
            }
        }    
    }
    private async Task InsertAdvisoryOffice(List<AdvisoryUser> listAdvisoryUser, Guid AdvisoryOfficeId)
    {
        var listObj = new List<AdvisoryStaff>();
        foreach (var itemUser in listAdvisoryUser)
        {
            var model = new AdvisoryStaff();
            model.Id = Guid.NewGuid();
            model.AdvisoryOfficeId = AdvisoryOfficeId;
            model.AdvisoryUserId = itemUser.AdvisoryUserId;
            model.AdvisoryUserName = itemUser.AdvisoryUserName;
            listObj.Add(model);
        }
        await _unitOfWork.GetRepository<AdvisoryStaff>().InsertAsync(listObj);
        await _unitOfWork.SaveChangesAsync();
    }
    private async Task InsertAndUpdateDocumentAdvisory(List<DocumentAdvisory> lstDocumentAdvisory, Guid DocId)
    {
        if (lstDocumentAdvisory != null && lstDocumentAdvisory.Count > 0)
        {
            await RemoveDocumentAdvisory(DocId);
            var listObj = new List<DocumentAdvisory>();
            foreach (var itemDocumentAdvisory in lstDocumentAdvisory)
            {
                var model = new DocumentAdvisory();
                model.Id = Guid.NewGuid();
                model.DocId = DocId;
                model.OfficeId = itemDocumentAdvisory.OfficeId;
                listObj.Add(model);
            }
            await _unitOfWork.GetRepository<DocumentAdvisory>().InsertAsync(listObj);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    private async Task InsertAndUpdateDocumentImplementation(List<DocumentImplementation> lstDocumentImplementation, Guid DocId)
    {
        if (lstDocumentImplementation != null && lstDocumentImplementation.Count > 0)
        {
            await RemoveDocumentImplementation(DocId);
            var listObj = new List<DocumentImplementation>();
            foreach (var itemDocumentImplementation in lstDocumentImplementation)
            {
                var model = new DocumentImplementation();
                model.Id = Guid.NewGuid();
                model.DocId = DocId;
                model.OfficeId = itemDocumentImplementation.OfficeId;
                listObj.Add(model);
            }
            await _unitOfWork.GetRepository<DocumentImplementation>().InsertAsync(listObj);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    private async Task InsertAndUpdateDocumentReference(List<DocumentReference> lstDocumentReference, Guid DocId)
    {
        if (lstDocumentReference != null && lstDocumentReference.Count > 0)
        {
            await RemoveDocumentReference(DocId);
            var listObj = new List<DocumentReference>();
            foreach (var itemDocumentReference in lstDocumentReference)
            {
                var model = new DocumentReference();
                model.Id = Guid.NewGuid();
                model.DocId = DocId;
                model.DocName = itemDocumentReference.DocName;
                model.DocRefId = itemDocumentReference.DocRefId;
                model.DocRefName = itemDocumentReference.DocRefName;
                listObj.Add(model);
            }
            await _unitOfWork.GetRepository<DocumentReference>().InsertAsync(listObj);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    private async Task InsertAndUpdateDocumentComment(DocumentComment data, Guid DocId)
    {
        if (data != null)
        {
            var model = new DocumentComment();
            model.Id = Guid.NewGuid();
            model.OfficeId = data.OfficeId;
            model.UserId = data.UserId;
            model.MsgComment = data.MsgComment;
            model.Type = data.Type;
            model.CreateUser = data.CreateUser;
            model.CreateDate = data.CreateDate;
            model.OfficeName = data.OfficeName;
    
            await _unitOfWork.GetRepository<DocumentComment>().InsertAsync(model);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    private async Task RemoveDocumentAdvisory(Guid Id)
    {
        var count = _unitOfWork.GetRepository<DocumentAdvisory>().GetByWhere(x => x.DocId == Id).Count();
        if (count > 0)
        {
            _unitOfWork.GetRepository<DocumentAdvisory>().DeleteByWhere(x => x.DocId == Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
    private async Task RemoveDocumentImplementation(Guid Id)
    {
        var count = _unitOfWork.GetRepository<DocumentImplementation>().GetByWhere(x => x.DocId == Id).Count();
        if (count > 0)
        {
            _unitOfWork.GetRepository<DocumentImplementation>().DeleteByWhere(x => x.DocId == Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    private async Task RemoveDocumentReference(Guid Id)
    {
        var count = _unitOfWork.GetRepository<DocumentReference>().GetByWhere(x => x.DocId == Id).Count();
        if (count > 0)
        {
            _unitOfWork.GetRepository<DocumentReference>().DeleteByWhere(x => x.DocId == Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task<DocumentCommandResponse> Handle(BrowseDocumentRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new DocumentCommandValidator(EnumActionName.BROWSE, _unitOfWork);
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new DocumentCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }
        var data = await _unitOfWork.GetRepository<Document>().GetFirstOrDefaultAsync(predicate: x => x.Id == request.Id);
        if (data == null)
        {
            return new DocumentCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error };
        }

        data.Status = EnumStatusDoc.BrowseDoc;

        _unitOfWork.GetRepository<Document>().Update(data);
        await _unitOfWork.SaveChangesAsync();

        var result = _mapper.Map<DocumentModel>(data);

        return new DocumentCommandResponse { isSuccess = true, Result = result, Message = "Trình duyệt thành công" };
    }

    public async Task<DocumentCommandResponse> Handle(EditDocumentRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new DocumentCommandValidator(EnumActionName.EDIT, _unitOfWork);
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new DocumentCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }

        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                if (!String.IsNullOrEmpty(request.Id.ToString()))
                {
                    var data = _mapper.Map<Document>(request);

                    Expression<Func<Document, bool>> expCommon = _ => _.Id.Equals(data.Id);
                    var entity = _unitOfWork.GetRepository<Document>().GetFirstOrDefault(predicate: expCommon);

                    entity.DocName = data.DocName;
                    entity.Priority = data.Priority;
                    entity.Description = data.Description;
                    entity.ExpirationDate = data.ExpirationDate;
                    entity.Explaination = data.Explaination;
                    entity.Notes = data.Notes;

                    _unitOfWork.GetRepository<Document>().Update(entity);

                    // đơn vị tham mưu
                    await InsertAndUpdateDocumentAdvisory(request.ListAdvisoryUnit!, data.Id);
                    // đơn vị thực hiện
                    await InsertAndUpdateDocumentImplementation(request.ListImplementUnit!, data.Id);
                    // văn bản liên quan
                    await InsertAndUpdateDocumentReference(request.ListDocReference!, data.Id);
                    // ý kiến
                    await InsertAndUpdateDocumentComment(request.MsgComment!, data.Id);

                    await _unitOfWork.SaveChangesAsync();
                    var result = _mapper.Map<DocumentModel>(data);
                    await transaction.CommitAsync(cancellationToken);
                    return new DocumentCommandResponse { isSuccess = true, Result = result, Message = "Update success" };
                }
                else
                    throw new Exception();

            }
            catch (Exception e)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new DocumentCommandResponse(validationResult.Errors) { Message = "Update fail" };
            }
        }
    }

    public async Task<DocumentCommandResponse> Handle(DeleteDocumentRequestCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = new();
        var data = await _unitOfWork.GetRepository<Document>().GetFirstOrDefaultAsync(predicate: x => x.Id == request.Id && x.Status == EnumStatusDoc.DraftDoc);
        if (data != null)
        {
            using (var transacion = _context.Database.BeginTransaction())
            {
                try
                {

                    _unitOfWork.GetRepository<Document>().Delete(data);
                    await _unitOfWork.SaveChangesAsync();

                    await transacion.CommitAsync(cancellationToken);
                    return new DocumentCommandResponse { isSuccess = true, Message = ErrorMessage.Delete_Success };
                }
                catch (Exception)
                {
                    await transacion.RollbackAsync(cancellationToken);
                    return new DocumentCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error_Delete };
                }
            }
        }
        else
        {
            return new DocumentCommandResponse(validationResult.Errors) { Message = "Không được hủy những văn bản đang được trình duyệt. Vui lòng kiểm tra lại." };
        }
        throw new NotImplementedException();
    }
}