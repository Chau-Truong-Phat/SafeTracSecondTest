using AutoMapper;
using MediatR;
using MedWorking.Core.Application.ModuleConfigBrowsingStep.Models;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.Common.UnitOfWork.Collections;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedWorking.Core.Application.ModuleConfigBrowsingStep.Queries;

public class GetConfigBrowsingStepQueryHandler : IRequestHandler<GetAllListConfigBrowsingStepPagingQuery, IPagedList<ViewConfigureBrowsingStep>>
                                                  , IRequestHandler<GetListConfigBrowsingStepUnitQuery, List<ConfigBrowsingStepModel>>
                                                  , IRequestHandler<GetListConfigBrowsingStepQuery, List<ConfigBrowsingStepModel>>
                                                  , IRequestHandler<GetConfigBrowsingStepByIdQuery, ConfigBrowsingStepModel>
                                                  , IRequestHandler<GetListAccountByOfficeIdQuery, List<AccountDetailByOfficeIdModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetConfigBrowsingStepQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IPagedList<ViewConfigureBrowsingStep>> Handle(GetAllListConfigBrowsingStepPagingQuery request, CancellationToken cancellationToken)
    {
        List<long>? listOfficeId = new();
        if (request.ListOfficeId!.Count > 0 && request.ListOfficeId!.First() != "")
        {
            var dataParents = await _unitOfWork.GetRepository<Office>().GetByWhere(x => request.ListOfficeId.Contains(x.Id.ToString()) && x.Parent == 0).Select(v => v.Id).ToListAsync(cancellationToken);
            var childOffices = await _unitOfWork.GetRepository<Office>().GetByWhere(predicate: null!).ToListAsync(cancellationToken);
            foreach (var itemParent in dataParents)
            {
                listOfficeId.Add(itemParent);
                var listChildOffices = childOffices.Where(v => v.Parent == itemParent).Select(p => p.Id).ToList();
                listOfficeId.AddRange(listChildOffices);
            }
            var dataChilds = await _unitOfWork.GetRepository<Office>().GetByWhere(x => request.ListOfficeId.Contains(x.Id.ToString()) && x.Parent != 0).Select(v => v.Id).ToListAsync(cancellationToken);
            listOfficeId.AddRange(dataChilds);
        }
        Expression<Func<ViewConfigureBrowsingStep, bool>> expCommon = p =>
        (string.IsNullOrEmpty(request.FullTextSearch)
        || p.StepName!.ToLower().Contains(request.FullTextSearch.ToLower()))
        && ((request.ScopeApplication == 0) || p.ScopeApplication == request.ScopeApplication)
        && ((request.ListOfficeId!.First() == "") || request.ListOfficeId!.Contains(p.OfficeId.ToString()!) || listOfficeId.Contains(p.OfficeId!.Value));

        var data = await _unitOfWork.GetRepository<ViewConfigureBrowsingStep>().GetPagedListAsync(predicate: expCommon, orderBy: p => p.OrderByDescending(p => p.CreateDate), null!, request.PageNumber, request.PageSize, request.RowModify, false, cancellationToken);
        return data;
    }
    public async Task<List<ConfigBrowsingStepModel>> Handle(GetListConfigBrowsingStepQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<ConfigureBrowsingStep, bool>> expCommon = p => p.ScopeApplication == EnumCapDuyet.GeneralApplication && p.Active == true;
        var data = await _unitOfWork.GetRepository<ConfigureBrowsingStep>().GetByWhere(predicate: expCommon).ToListAsync(cancellationToken);
        var result = _mapper.Map<List<ConfigBrowsingStepModel>>(data);

        return result;
    }
    public async Task<List<AccountDetailByOfficeIdModel>> Handle(GetListAccountByOfficeIdQuery request, CancellationToken cancellationToken)
    {
        List<AccountDetailByOfficeIdModel> lstAccount = new();
        var offices = await _unitOfWork.GetRepository<Office>().GetByWhere(predicate: null!).ToListAsync(cancellationToken);
        var accounts =await _unitOfWork.GetRepository<Account>().GetByWhere(predicate: null!).ToListAsync(cancellationToken);
        foreach (var itemOffice in request.ListOfficeIds!)
        {
            AccountDetailByOfficeIdModel model = new();
            var office = offices.FirstOrDefault(x => x.Id == itemOffice);
            if (office != null)
            {
                model.Id = office.Id;
                model.OfficeName = office.OfficeName;
                var account = accounts.Where(x => x.Office == itemOffice).ToList();
                if (account.Count > 0)
                {
                    model.ListAccounts = _mapper.Map<List<AccountDetail>>(account);
                }
                lstAccount.Add(model);
            }
        }
        return lstAccount;
    }
    public async Task<List<ConfigBrowsingStepModel>> Handle(GetListConfigBrowsingStepUnitQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<ConfigureBrowsingStep, bool>> expCommon = p => p.ScopeApplication == EnumCapDuyet.ApplyUnit && p.Active == true && p.OfficeId == request.OfficeId;
        var data = await _unitOfWork.GetRepository<ConfigureBrowsingStep>().GetByWhere(predicate: expCommon).ToListAsync(cancellationToken);
        var result = _mapper.Map<List<ConfigBrowsingStepModel>>(data);
        return result;
    }
    public async Task<ConfigBrowsingStepModel> Handle(GetConfigBrowsingStepByIdQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<ViewConfigureBrowsingStep, bool>> expCommon = p => p.ConfigureBrowsingStepId == request.Id;
        var data = await _unitOfWork.GetRepository<ViewConfigureBrowsingStep>().GetByWhere(predicate: expCommon).FirstOrDefaultAsync(cancellationToken);
        var result = _mapper.Map<ConfigBrowsingStepModel>(data);
        result.IsUseStep = false;
        if (data != null)
        {
            if (data.ScopeApplication == EnumCapDuyet.ApplyUnit)
            {
                var dataStep = await _unitOfWork.GetRepository<TextBrowsingStepsUnit>().GetByWhere(x => x.ConfigureBrowsingStepId == data.ConfigureBrowsingStepId).ToListAsync(cancellationToken);
                if (dataStep.Count > 0)
                {
                    result.IsUseStep = true;
                }
            }
            else
            {
                var dataStep = await _unitOfWork.GetRepository<TextBrowsingStep>().GetByWhere(x => x.ConfigureBrowsingStepId == data.ConfigureBrowsingStepId).ToListAsync(cancellationToken);
                if (dataStep.Count > 0)
                {
                    result.IsUseStep = true;
                }
            }
            result.ListOffice = await GetListOfficeImplement(data.ConfigureBrowsingStepId);
        }
        return result;
    }

    public async Task<List<OfficeImplement>> GetListOfficeImplement(Guid? configBrowsingStepId)
    {
        var dataOffice = await _unitOfWork.GetRepository<ImplementingAgency>().GetByWhere(x => x.ConfigStepId == configBrowsingStepId).ToListAsync();
        var dataUsers = await _unitOfWork.GetRepository<UserImplement>().GetByWhere(predicate: null!).ToListAsync();
        var resultDataOffice = _mapper.Map<List<OfficeImplement>>(dataOffice);
        foreach (var itemOffice in resultDataOffice)
        {
            var dataUser = dataUsers.Where(x => x.OfficeImplementId == itemOffice.OfficeImplementId && x.ConfigureBrowsingStepId == itemOffice.ConfigStepId).Select(v => v.EmployeeId).ToList();
            if (dataUser.Count > 0)
            {
                itemOffice.ListUserImplements = dataUser!;
            }
        }
        return resultDataOffice;
    }
}
