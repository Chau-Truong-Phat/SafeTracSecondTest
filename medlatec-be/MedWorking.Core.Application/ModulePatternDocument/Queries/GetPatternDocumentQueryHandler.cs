using AutoMapper;
using MediatR;
using MedWorking.Core.Application.ModulePatternDocument.Models;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.Static;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.Common.UnitOfWork.Collections;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedWorking.Core.Application.ModulePatternDocument.Queries;

public class GetPatternDocumentQueryHandler : IRequestHandler<GetAllListPatternDocQuery, IPagedList<ViewSampleDocument>>
                                             , IRequestHandler<GetGenCodePatternDocumentQuery, string>
                                             , IRequestHandler<GetPatternDocumentByIdQuery, PatternDocumentDetailModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetPatternDocumentQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IPagedList<ViewSampleDocument>> Handle(GetAllListPatternDocQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<ViewSampleDocument, bool>> expCommon = p => ((string.IsNullOrEmpty(request.FullTextSearch)
        || (p.PatternDocCode!.ToLower().Contains(request.FullTextSearch.ToLower()) || p.PatternDocName!.ToLower().Contains(request.FullTextSearch.ToLower())))
        && ((request.ListDocType!.First() == 0) || request.ListDocType!.Contains(p.DocType!.Value))
        && ((request.ListGroupDocumentId!.First() == "") || request.ListGroupDocumentId!.Contains(p.GroupDocId.ToString()!)));

        var data = await _unitOfWork.GetRepository<ViewSampleDocument>().GetPagedListAsync(predicate: expCommon, orderBy: p => p.OrderByDescending(p => p.CreateDate), null!, request.PageNumber, request.PageSize, request.RowModify, false, cancellationToken);
        return data;
    }

    public async Task<string> Handle(GetGenCodePatternDocumentQuery request, CancellationToken cancellationToken)
    {
        List<string> arrGroupDocCode = await _unitOfWork.GetRepository<PatternDocument>().GetByWhere(predicate: p => p.PatternDocCode!.StartsWith(EnumActionName.DocumentTemplate.ToString())).Select(v => v.PatternDocCode!).ToListAsync(cancellationToken);
        string strGen = AutoGenCode.AutoGenerateCode(arrGroupDocCode, EnumActionName.DocumentTemplate);
        return strGen;
    }
    public async Task<PatternDocumentDetailModel> Handle(GetPatternDocumentByIdQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<ViewSampleDocument, bool>> expCommon = p => p.PatternDocId == request.Id;
        var data = await _unitOfWork.GetRepository<ViewSampleDocument>().GetByWhere(predicate: expCommon).FirstOrDefaultAsync(cancellationToken);
        var result = _mapper.Map<PatternDocumentDetailModel>(data);
        if (data != null)
        {
            result.ListOffices = await GetOffice(result.PatternDocId);
        }
        return result!;
    }
    private async Task<List<OfficeDetailModel>> GetOffice(Guid patternId)
    {
        List<OfficeDetailModel> lstDataOffice = new();
        if (patternId != Guid.Empty)
        {
            var modelUserIdRoles = await _unitOfWork.GetRepository<PatternDocOffice>().GetByWhere(x => x.PatternDocId == patternId).ToListAsync();
            var dataOffices = await _unitOfWork.GetRepository<Office>().GetByWhere(predicate: null!).ToListAsync();
            foreach (var item in modelUserIdRoles)
            {
                var dataOffice = dataOffices.FirstOrDefault(x => x.Id == item.OfficeId);
                if (dataOffice != null)
                {
                    var result = _mapper.Map<OfficeDetailModel>(dataOffice);
                    if (dataOffice.Parent == 0)
                    {
                        var dataChild = dataOffices.Where(x => x.Parent == dataOffice.Id).ToList();
                        var resultOfficeChild = _mapper.Map<List<OfficeDetailModel>>(dataChild);
                        result.ListChild = resultOfficeChild!;
                    }
                    lstDataOffice.Add(result);
                }
            }
        }
        return lstDataOffice;
    }
}
