using AutoMapper;
using MediatR;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace MedWorking.Core.Application.ModuleCheckTimeApplication.Queries;

public class GetListApprovalGeneralDocProcessQueryHandler
    : IRequestHandler<GetListApprovalGeneralDocProcessQuery, bool>
    , IRequestHandler<GetListApprovalGeneralDocProcessUnitQuery, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly MedWorkingContext _context;
    public GetListApprovalGeneralDocProcessQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, MedWorkingContext context)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = context;
    }

    public async Task<bool> Handle(GetListApprovalGeneralDocProcessQuery request, CancellationToken cancellationToken)
    {
        var listAppDocGeneralProcess = await _unitOfWork.GetRepository<EntityFramework.Models.ViewApprovalGeneralDocumentProcess>().GetByWhere(predicate: null!).AsNoTracking().ToListAsync(cancellationToken);
        var groupDocCheck = listAppDocGeneralProcess.GroupBy(x => x.GroupDocumentId).Where(g => g.Count() > 1).Select(y => y.Key);
        var listPattern = listAppDocGeneralProcess.GroupBy(x => x.PatternDocId).Where(g => g.Count() > 1).Select(y => y.Key);

        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                foreach (var itemcheck in groupDocCheck)
                {
                    var data = listAppDocGeneralProcess.Where(p => p.GroupDocumentId == itemcheck && listPattern.Count() > 0 && DateTime.Compare(p.TimeApplication!.Value, DateTime.UtcNow) <= 0).OrderByDescending(x => x.CreateDate).ToList();

                    if (data!.Count > 1 && data.First().Active == true && DateTime.Compare(data.First().TimeApplication!.Value, DateTime.UtcNow) <= 0)
                    {
                        data.ForEach(x => x.Active = false);
                        data.First().Active = true;

                        var obj = _mapper.Map<List<EntityFramework.Models.ApprovalGeneralDocumentProcess>>(data);
                        _unitOfWork.GetRepository<EntityFramework.Models.ApprovalGeneralDocumentProcess>().Update(obj);
                        await _unitOfWork.SaveChangesAsync();

                        await transaction.CommitAsync(cancellationToken);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                return false;
                throw;
            }
        }
    }

        public async Task<bool> Handle(GetListApprovalGeneralDocProcessUnitQuery request, CancellationToken cancellationToken)
        {
            var listAppDocGeneralProcessUnit = await _unitOfWork.GetRepository<EntityFramework.Models.ViewApprovalGeneralDocumentProcessUnit>().GetByWhere(predicate: null!).AsNoTracking().ToListAsync(cancellationToken);
            var groupDocCheck = listAppDocGeneralProcessUnit.GroupBy(x => x.GroupDocumentId).Where(g => g.Count() > 1).Select(y => y.Key);
            var listPattern = listAppDocGeneralProcessUnit.GroupBy(x => x.PatternDocId).Where(g => g.Count() > 1).Select(y => y.Key);
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var itemcheck in groupDocCheck)
                    {
                        var data = listAppDocGeneralProcessUnit.Where(p => p.GroupDocumentId == itemcheck && listPattern.Count() > 0 && DateTime.Compare(p.TimeApplication!.Value, DateTime.UtcNow) <= 0).OrderByDescending(x => x.CreateDate).ToList();

                        if (data!.Count > 1 && data.First().Active == true && DateTime.Compare(data.First().TimeApplication!.Value, DateTime.UtcNow) <= 0)
                        {
                            data.ForEach(x => x.Active = false);
                            data.First().Active = true;

                            var obj = _mapper.Map<List<EntityFramework.Models.ApprovalGeneralDocumentProcessUnit>>(data);
                            _unitOfWork.GetRepository<EntityFramework.Models.ApprovalGeneralDocumentProcessUnit>().Update(obj);

                            await _unitOfWork.SaveChangesAsync();
                            await transaction.CommitAsync(cancellationToken);
                        }
                    }
                    return true;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return false;
                    throw;
                }
            }
        }
    }