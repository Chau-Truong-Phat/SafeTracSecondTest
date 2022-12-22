using MediatR;

namespace MedWorkingAPI.Services.BackgroundJob
{
    public interface IBackgroundJobService
    {
        void ExcuteJobHourly();
    }
}
