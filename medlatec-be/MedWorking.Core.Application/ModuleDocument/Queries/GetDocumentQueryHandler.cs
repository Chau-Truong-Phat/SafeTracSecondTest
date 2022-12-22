using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MedWorking.Core.Application.ModuleDocument.Models;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.Static;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace MedWorking.Core.Application.ModuleDocument.Queries
{
    public class GetDocumentQueryHandler
     : IRequestHandler<GetAdvisoryOfficeByIdQuery, List<long?>>
     , IRequestHandler<GetDocumentReferenceQuery, List<Document>>
     , IRequestHandler<GetDocumentCodeQuery, string>
     , IRequestHandler<GetDocumentByIdQuery, DocumentDetailModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDocumentQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<long?>> Handle(GetAdvisoryOfficeByIdQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<ViewGetImplementOfficeOfPatternDoc, bool>> expCommon = p => p.PatternDocId == request.PatternDocId;

            var dataOfficePattern = await _unitOfWork.GetRepository<ViewGetImplementOfficeOfPatternDoc>().GetByWhere(predicate: expCommon).ToListAsync(cancellationToken);
            var obj1 = dataOfficePattern.Select(x => x.OfficeId);

            Expression<Func<ViewGetImplementOfficeOfConfigStep, bool>> expCommonConfigStep = p => p.ConfigType == 2;

            var dataOfficeConfigStep = await _unitOfWork.GetRepository<ViewGetImplementOfficeOfConfigStep>().GetByWhere(predicate: expCommonConfigStep).ToListAsync(cancellationToken);
            var obj2 = dataOfficeConfigStep.Select(x => x.OfficeImplementId);

            var result = obj1.Concat(obj2).Distinct().ToList();

            return result;
        }

        public async Task<List<Document>> Handle(GetDocumentReferenceQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Document, bool>> expCommon = p => p.Status != EnumStatusDoc.DraftDoc;
            var data = await _unitOfWork.GetRepository<Document>().GetByWhere(predicate: expCommon).ToListAsync(cancellationToken);
            var result = _mapper.Map<List<Document>>(data);

            return result;
        }

        public async Task<string> Handle(GetDocumentCodeQuery request, CancellationToken cancellationToken)
        {
            string strPrefixDocCode = "VB" + DateTime.Now.ToString("MMddyyyy") + "-";
            List<string> arrDocumentCode = await _unitOfWork.GetRepository<Document>().GetByWhere(predicate: p => p.DocumentCode!.StartsWith(strPrefixDocCode)).Select(v => v.DocumentCode!).ToListAsync(cancellationToken);
            string strGen = AutoGenCode.AutoGenerateCode(arrDocumentCode, strPrefixDocCode);
            string prefix = strGen.Split('-')[0];
            string postfix = int.Parse(strGen.Split('-')[1]).ToString();
            return prefix + " - " + postfix;
        }

        public async Task<DocumentDetailModel> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            DocumentDetailModel objDocumentDetailModel = new();
            Expression<Func<ViewDocumentDetailById, bool>> expCommon = p => p.Id == request.Id;
            var dataDocumentDetail = await _unitOfWork.GetRepository<ViewDocumentDetailById>().GetByWhere(predicate: expCommon).FirstOrDefaultAsync(cancellationToken);
            if(dataDocumentDetail != null)
            {
                var resultDataDocument = _mapper.Map<DocumentDetailModel>(dataDocumentDetail);
                ApprovalGeneralDocument objModel = new();
                var dataApprovalGeneralDocument = await _unitOfWork.GetRepository<ViewApprovalGeneralDocumentProcess>().GetByWhere(x => x.GroupDocumentId == resultDataDocument.GroupDocId).OrderByDescending(x => x.CreateDate).FirstOrDefaultAsync(cancellationToken);
                if(dataApprovalGeneralDocument != null)
                {
                    objModel.ApprovalGeneralDocumentId = dataApprovalGeneralDocument.Id;
                    var dataOffices = await _unitOfWork.GetRepository<TextBrowsingStep>().GetByWhere(x => x.ApprovalGeneralDocumentProcessId == dataApprovalGeneralDocument.Id).OrderBy(v => v.Stt).ToListAsync(cancellationToken);
                    if (dataOffices.Count > 0)
                    {
                        objModel.ListTextBrowsingStepGeneral = dataOffices;
                    }
                    resultDataDocument.ApprovalGeneralDocumentModel = objModel;
                }
                objDocumentDetailModel = resultDataDocument;
            }
            return objDocumentDetailModel;
        }
    }
}
