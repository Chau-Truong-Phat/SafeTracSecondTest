using Hangfire;
using MediatR;
using MedWorking.Core.Application.ModuleCheckTimeApplication.Queries;
using MedWorkingAPI.Services.BackgroundJob;

namespace MedWorkingAPI.Extensions
{
    public static class BackgroundJobExtension
    {
        public static void AddBackgroundJobService(this IServiceProvider services)
        {
            var _backgroundJob = services.GetService<IBackgroundJobService>()!;
            _backgroundJob.ExcuteJobHourly();
        }
    }
}
