using MediatR;
using MedWorking.Core.Application.ModuleApprovation.Commands.ActionCommands;
using MedWorking.Core.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedWorkingAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ApprovationController : ControllerBase
{
    private readonly IMediator? _mediator;
    private readonly ILogger<ApprovationController> _logger;
    public ApprovationController(ILogger<ApprovationController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _mediator = serviceProvider.GetService<IMediator>();
    }

    [HttpPost("approve")]
    public async Task<IActionResult> Approve([FromBody] ApproveApprovationCommand request)
    {
        _logger.LogInformation("Call " + nameof(Approve) + " API");
        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }
}

