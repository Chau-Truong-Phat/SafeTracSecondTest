using Hangfire;
using MediatR;
using MedWorking.Core.Application.ModuleCheckTimeApplication.Queries;

namespace MedWorkingAPI.Services.BackgroundJob
{
    public class BackgroundJobService : IBackgroundJobService
    {
      
        private readonly IRecurringJobManager _recurringJobManager;


        public BackgroundJobService(IRecurringJobManager recurringJobManager)
        {
            _recurringJobManager = recurringJobManager;
        }

        public void ExcuteJobHourly()
        {
            var job1 = new GetListApprovalGeneralDocProcessQuery();
            _recurringJobManager.AddOrUpdate<MediatorHangfireBridge<bool>>("ChangeStatusApprovalGeneralDocumentProcess", bridge => bridge.Send(job1), Cron.Daily(17,00), null);

            var job2 = new GetListApprovalGeneralDocProcessUnitQuery();
            _recurringJobManager.AddOrUpdate<MediatorHangfireBridge<bool>>("ChangeStatusApprovalGeneralDocumentProcessUnit", bridge => bridge.Send(job2), Cron.Daily(17,00), null);
        }
    }
}
