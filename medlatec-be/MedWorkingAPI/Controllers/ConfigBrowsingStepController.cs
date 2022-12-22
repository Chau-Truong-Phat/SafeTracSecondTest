using MediatR;
using MedWorking.Core.Application.ModuleConfigBrowsingStep.Commands.ActionCommands;
using MedWorking.Core.Application.ModuleConfigBrowsingStep.Queries;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedWorkingAPI.Controllers;

[Route("api/config-browsing-step")]
[ApiController]
[Authorize]
public class ConfigBrowsingStepController : ControllerBase
{
    private readonly IMediator? _mediator;
    private readonly ILogger<ConfigBrowsingStepController> _logger;
    public ConfigBrowsingStepController(ILogger<ConfigBrowsingStepController> logger,IServiceProvider serviceProvider)
    {
        _logger = logger;
        _mediator = serviceProvider.GetService<IMediator>();
    }
    [HttpPost("get-by-paging")]
    public async Task<IActionResult> GetPagedListConfigBrowsingStepAsync([FromBody] GetAllListConfigBrowsingStepPagingQuery request)
    {
        _logger.LogInformation("Call " + nameof(GetPagedListConfigBrowsingStepAsync) + " API");
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpGet("get-detail-by-id/{id}")]
    public async Task<IActionResult> GetPagedListGroupDocumentAsync(Guid id)
    {
        _logger.LogInformation("Call " + nameof(GetPagedListGroupDocumentAsync) + " API");
        GetConfigBrowsingStepByIdQuery request = new();
        request.Id = id;
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }
    [HttpPost("get-account-by-officeid")]
    public async Task<IActionResult> GetListAccountAsync([FromBody] GetListAccountByOfficeIdQuery request)
    {
        _logger.LogInformation("Call " + nameof(GetListAccountAsync) + " API");
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }
    [HttpGet("get-all-step")]
    public async Task<IActionResult> GetAllStepAsync()
    {
        _logger.LogInformation("Call " + nameof(GetAllStepAsync) + " API");
        GetListConfigBrowsingStepQuery request = new GetListConfigBrowsingStepQuery();
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpGet("get-all-step-unit/{officeId}")]
    public async Task<IActionResult> GetAllStepUnitAsync(long officeId)
    {
        _logger.LogInformation("Call " + nameof(GetAllStepUnitAsync) + " API");
        GetListConfigBrowsingStepUnitQuery request = new();
        request.OfficeId = officeId;
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpPost("add-config-browsing-step")]
    public async Task<IActionResult> AddConfigBrowsingStepAsync([FromBody] AddConfigBrowsingStepCommand request)
    {
        _logger.LogInformation("Call " + nameof(AddConfigBrowsingStepAsync) + " API");
        var userName = User!.Identity!.Name;
        request.CreateUser = userName;
        request.CreateDate = DateTime.UtcNow;
        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }

    [HttpPut("edit-config-browsing-step")]
    public async Task<IActionResult> EditConfigBrowsingStepAsync([FromBody] EditConfigBrowsingStepCommand request)
    {
        _logger.LogInformation("Call " + nameof(EditConfigBrowsingStepAsync) + " API");
        var userName = User!.Identity!.Name;
        request.UpdateUser = userName;
        request.UpdateDate = DateTime.UtcNow;
        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }

    [HttpDelete("delete-config-browsing-step/{id}")]
    public async Task<IActionResult> DeleteConfigBrowsingStepAsync(Guid id)
    {
        _logger.LogInformation("Call " + nameof(DeleteConfigBrowsingStepAsync) + " API");
        DeleteConfigBrowsingStepCommand request = new();
        request.Id = id;
        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }
}
