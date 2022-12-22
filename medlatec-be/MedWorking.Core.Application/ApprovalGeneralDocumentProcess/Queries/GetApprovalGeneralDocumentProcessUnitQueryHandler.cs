using AutoMapper;
using MediatR;
using MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Models;
using MedWorking.Core.Application.ModulePatternDocument.Models;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.Common.UnitOfWork.Collections;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Queries;

public class GetApprovalGeneralDocumentProcessUnitQueryHandler 
    : IRequestHandler<GetApprovalGeneralDocumentProcessUnitPagingQuery, IPagedList<ViewApprovalGeneralDocumentProcessUnit>>
    , IRequestHandler<GetPatternDocumentByGroupDocumentIdQuery, List<PatternDocumentModel>>
    , IRequestHandler<GetApprovalGeneralDocumentProcessUnitByIdQuery, ApprovalGeneralDocumentProcessUnitModel>
    , IRequestHandler<GetPatternDocumentByListGroupDocumentIdQuery, List<PatternDocumentModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetApprovalGeneralDocumentProcessUnitQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<PatternDocumentModel>> Handle(GetPatternDocumentByGroupDocumentIdQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<PatternDocument, bool>> expCommon = p => p.GroupDocId == request.GroupDocumentId && p.PatternDocActive == true;
        var data = await _unitOfWork.GetRepository<PatternDocument>().GetByWhere(predicate: expCommon).ToListAsync(cancellationToken);
        var result = _mapper.Map<List<PatternDocumentModel>>(data);
        return result;
    }
    public async Task<List<PatternDocumentModel>> Handle(GetPatternDocumentByListGroupDocumentIdQuery request, CancellationToken cancellationToken)
    {
        List<PatternDocumentModel> lstData = new();
        if(request.ListGroupDocumentId!.First() == "")
        {
            var data =await _unitOfWork.GetRepository<PatternDocument>().GetByWhere(predicate: null!).ToListAsync(cancellationToken);
            if(data.ToList().Count >0)
            {
                lstData.AddRange(_mapper.Map<List<PatternDocumentModel>>(data));
            }
        }   
        else
        {
            var data = await _unitOfWork.GetRepository<PatternDocument>().GetByWhere(x => x.PatternDocActive == true && request.ListGroupDocumentId!.Contains(x.GroupDocId.ToString()!) ).ToListAsync(cancellationToken);
            if(data.Count >0)
                lstData.AddRange(_mapper.Map<List<PatternDocumentModel>>(data));
        }
        return lstData;
    }
    public async Task<IPagedList<ViewApprovalGeneralDocumentProcessUnit>> Handle(GetApprovalGeneralDocumentProcessUnitPagingQuery request, CancellationToken cancellationToken)
    {
        List<long>? listOfficeId = new();
        if(request.ListOfficeId!.Count >0 && request.ListOfficeId!.First() != 0)
        {
            var dataParents = await _unitOfWork.GetRepository<Office>().GetByWhere(x => request.ListOfficeId.Contains(x.Id) && x.Parent == 0).Select(v => v.Id).ToListAsync(cancellationToken);
            var childOffices =await _unitOfWork.GetRepository<Office>().GetByWhere(predicate: null!).ToListAsync(cancellationToken);
            foreach (var itemParent in dataParents)
            {
                listOfficeId.Add(itemParent);
                var lstChildOffice = childOffices.Where(v => v.Parent == itemParent).Select(p => p.Id).ToList();
                listOfficeId.AddRange(lstChildOffice);
            }
            var dataChilds = await _unitOfWork.GetRepository<Office>().GetByWhere(x => request.ListOfficeId.Contains(x.Id) && x.Parent != 0).Select(v => v.Id).ToListAsync(cancellationToken);
            listOfficeId.AddRange(dataChilds);
        }
        Expression<Func<ViewApprovalGeneralDocumentProcessUnit, bool>> expCommon = p =>
                    ((request.ListOfficeId!.First() == 0) || (request.ListOfficeId!.Contains(p.OfficeId!.Value ) || listOfficeId.Contains(p.OfficeId.Value))) 
                && ((((request.ListGroupDocumentId!.First() == "") || request.ListGroupDocumentId!.Contains(p.GroupDocumentId.ToString()!))
                && ((request.ListPatternDocumentId!.First() == "") || string.Join(";", request.ListPatternDocumentId!.ToArray()).Contains(p.PatternDocId!)))
                || (((request.ListGroupDocumentId!.First() == "") || request.ListGroupDocumentId!.Contains(p.GroupDocumentId.ToString()!))
                && ((request.ListPatternDocumentId!.First() == "") || p.PatternDocId!.Contains(string.Join(";", request.ListPatternDocumentId!.ToArray())))));
        var data = await _unitOfWork.GetRepository<ViewApprovalGeneralDocumentProcessUnit>().GetPagedListAsync(predicate: expCommon, orderBy: p => p.OrderByDescending(p => p.CreateDate), null!, request.PageNumber, request.PageSize, request.RowModify, false, cancellationToken);
        return data;
    }
    public async Task<ApprovalGeneralDocumentProcessUnitModel> Handle(GetApprovalGeneralDocumentProcessUnitByIdQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<ViewApprovalGeneralDocumentProcessUnit, bool>> expCommon = p => p.Id == request.Id;
        var data = await _unitOfWork.GetRepository<ViewApprovalGeneralDocumentProcessUnit>().GetByWhere(predicate: expCommon).FirstOrDefaultAsync(cancellationToken);
        ApprovalGeneralDocumentProcessUnitModel dataModel = new();
        if (data != null)
        {
            var result = _mapper.Map<ApprovalGeneralDocumentProcessUnitModel>(data);
            var dataOffices = await _unitOfWork.GetRepository<TextBrowsingStepsUnit>().GetByWhere(x => x.ApprovalGeneralDocumentProcessUnitId == data.Id).OrderBy(v => v.Stt).ToListAsync(cancellationToken);
            if(dataOffices.Count >0)
            {
                result.ListTextBrowsingStep = dataOffices;
            }
            var patternDocuments = await _unitOfWork.GetRepository<PatternDocumentDetailByGroupDocument>().GetByWhere(x => x.ApprovalGeneralDocumentProcessUnitId == data.Id).ToListAsync(cancellationToken);
            if (patternDocuments.Count > 0)
            {
                result.ListPatternDocument = patternDocuments;
            }
            dataModel = result;
        }
        return dataModel;
    }
}
