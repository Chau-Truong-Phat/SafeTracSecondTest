using MediatR;
using MedWorking.Core.Application.ModuleLogin.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MedWorking.Core.Startup.MediatRs;

public static class MediatRStartup
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(LoginCommandHandler).Assembly);
    }
}