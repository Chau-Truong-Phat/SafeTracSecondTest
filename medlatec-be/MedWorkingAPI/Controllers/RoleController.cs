using MediatR;
using MedWorking.Core.Application.ModuleRole.Commands.ActionCommands;
using MedWorking.Core.Application.ModuleRole.Queries;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MedWorkingAPI.Controllers;

[Route("api/role")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IMediator? _mediator;
    private readonly ILogger<RoleController> _logger;
    public RoleController(ILogger<RoleController> logger,IServiceProvider serviceProvider)
    {
        _logger = logger;
        _mediator = serviceProvider.GetService<IMediator>();
    }

    [HttpPost("get-role-by-paging")]
    public async Task<IActionResult> GetPagedListRoleAsync([FromBody] GetRoleListQuery request)
    {
        _logger.LogInformation("Call " + nameof(GetPagedListRoleAsync) + " API");
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpGet("get-detail-role-by-id/{id}")]
    public async Task<IActionResult> GetPagedListRoleAsync(Guid id)
    {
        _logger.LogInformation("Call " + nameof(GetPagedListRoleAsync) + " API");
        GetRoleByIdQuery request = new();
        request.RoleId = id;
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpGet("get-all-role")]
    public async Task<IActionResult> GetAllRoleAsync()
    {
        _logger.LogInformation("Call " + nameof(GetAllRoleAsync) + " API");
        GetRoleAllListQuery request = new();
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpPost("add-role")]
    public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleCommand request)
    {
        _logger.LogInformation("Call " + nameof(AddRoleAsync) + " API");
        var userName = User!.Identity!.Name;
        request.CreateUser = userName;
        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }

    [HttpPut("edit-role")]
    public async Task<IActionResult> EditRoleAsync([FromBody] EditRoleCommand request)
    {
        _logger.LogInformation("Call " + nameof(EditRoleAsync) + " API");
        var userName = User!.Identity!.Name;
        request.UpdateUser = userName;
        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }

    [HttpDelete("delete-role/{id}")]
    public async Task<IActionResult> DeleteRoleAsync(Guid id)
    {
        _logger.LogInformation("Call " + nameof(DeleteRoleAsync) + " API");
        DeleteRoleCommand request = new();
        request.Id = id;
        var result = await _mediator!.Send(request);

        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }

    [HttpGet("get-gen-code")]
    public async Task<IActionResult> GetGenCodeAsync()
    {
        _logger.LogInformation("Call " + nameof(GetGenCodeAsync) + " API");
        GetGenRoleCodeQuery request = new();
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpGet("get-list-decentralize")]
    public async Task<IActionResult> GetListDecentralizeAsync()
    {
        _logger.LogInformation("Call " + nameof(GetListDecentralizeAsync) + " API");
        GetAllListRoleQuery request = new();
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }
}
