using AutoMapper;
using MediatR;
using MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Models;
using MedWorking.Core.Application.ModulePatternDocument.Models;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.Common.UnitOfWork.Collections;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Queries;

public class GetApprovalGeneralDocProcessQueryHandler
    : IRequestHandler<GetApprovalGeneralDocProcessPagingQuery, IPagedList<ViewApprovalGeneralDocumentProcess>>
    , IRequestHandler<GetPatternDocByGroupDocGeneralIdQuery, List<PatternDocumentModel>>
    , IRequestHandler<GetApprovalGeneralDocProcessByIdQuery, ApprovalGeneralDocumentProcessModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetApprovalGeneralDocProcessQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<PatternDocumentModel>> Handle(GetPatternDocByGroupDocGeneralIdQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<PatternDocument, bool>> expCommon = p => p.GroupDocId == request.GroupDocumentId && p.PatternDocActive == true;
        var data = await _unitOfWork.GetRepository<PatternDocument>().GetByWhere(predicate: expCommon).ToListAsync(cancellationToken);
        var result = _mapper.Map<List<PatternDocumentModel>>(data);
        return result;
    }

    public async Task<IPagedList<ViewApprovalGeneralDocumentProcess>> Handle(GetApprovalGeneralDocProcessPagingQuery request, CancellationToken cancellationToken)
    {
            Expression<Func<ViewApprovalGeneralDocumentProcess, bool>> expCommon = p =>
             (((request.ListGroupDocumentId!.First() == "") || request.ListGroupDocumentId!.Contains(p.GroupDocumentId.ToString()!))
            && ((request.ListPatternDocumentId!.First() == "") || string.Join(";",request.ListPatternDocumentId!.ToArray()).Contains(p.PatternDocId!)))
            || (((request.ListGroupDocumentId!.First() == "") || request.ListGroupDocumentId!.Contains(p.GroupDocumentId.ToString()!))
            && ((request.ListPatternDocumentId!.First() == "") || p.PatternDocId!.Contains(string.Join(";", request.ListPatternDocumentId!.ToArray()))));

            var data = await _unitOfWork.GetRepository<ViewApprovalGeneralDocumentProcess>().GetPagedListAsync(predicate: expCommon, orderBy: p => p.OrderByDescending(p => p.CreateDate), null!, request.PageNumber, request.PageSize, request.RowModify, false, cancellationToken);
            return data;
    }

    public async Task<ApprovalGeneralDocumentProcessModel> Handle(GetApprovalGeneralDocProcessByIdQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<ViewApprovalGeneralDocumentProcess, bool>> expCommon = p => p.Id == request.Id;
        var data = await _unitOfWork.GetRepository<ViewApprovalGeneralDocumentProcess>().GetByWhere(predicate: expCommon).FirstOrDefaultAsync(cancellationToken);
        var result = _mapper.Map<ApprovalGeneralDocumentProcessModel>(data);
        if (data != null)
        {
            var dataOffices = await _unitOfWork.GetRepository<TextBrowsingStep>().GetByWhere(x => x.ApprovalGeneralDocumentProcessId == data.Id).OrderBy(v => v.Stt).ToListAsync(cancellationToken);
            if (dataOffices.Count > 0)
            {
                result.ListTextBrowsingStepGeneral = dataOffices;
            }
            var patternDocuments = await _unitOfWork.GetRepository<PatternDocDetailByGroupDocGeneral>().GetByWhere(x => x.ApprovalGeneralDocumentProcessId == data.Id).ToListAsync(cancellationToken);
            if (patternDocuments.Count > 0)
            {
                result.ListPatternDocumentGeneral = patternDocuments;
            }
        }
        return result;
    }
}