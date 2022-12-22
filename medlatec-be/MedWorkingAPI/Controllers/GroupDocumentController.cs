using MediatR;
using MedWorking.Core.Application.ModuleCategory.ModuleGroupDocument.Commands.ActionCommands;
using MedWorking.Core.Application.ModuleCategory.ModuleGroupDocument.Queries;
using MedWorking.Core.Application.ModuleGroupDocument.Commands.ActionCommands;
using MedWorking.Core.Application.ModuleGroupDocument.Queries;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedWorkingAPI.Controllers;

[Route("api/group-document")]
[ApiController]
[Authorize]
public class GroupDocumentController : ControllerBase
{
    private readonly IMediator? _mediator;
    private readonly ILogger<GroupDocumentController> _logger;
    public GroupDocumentController(ILogger<GroupDocumentController> logger,IServiceProvider serviceProvider)
    {
        _logger = logger;
        _mediator = serviceProvider.GetService<IMediator>();
    }

    [HttpPost("get-group-document-by-paging")]
    public async Task<IActionResult> GetPagedListAsync([FromBody] GetGroupDocumentListQuery request)
    {
        _logger.LogInformation("Call " + nameof(GetPagedListAsync) + " API");
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpGet("get-detail-group-document-by-id/{id}")]
    public async Task<IActionResult> GetListGroupDocumentByIdAsync(string id)
    {
        _logger.LogInformation("Call " + nameof(GetListGroupDocumentByIdAsync) + " API");
        GetGroupDocumentByIdQuery request = new();
        request.GroupDocId = id;
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpGet("get-all-group-document")]
    public async Task<IActionResult> GetAllGroupDocumentAsync()
    {
        _logger.LogInformation("Call " + nameof(GetAllGroupDocumentAsync) + " API");
        GetGroupDocumentAllListQuery request = new();
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpPost("add-group-document")]
    public async Task<IActionResult> AddGroupDocumentAsync([FromBody] AddGroupDocumentRequestCommand request)
    {
        _logger.LogInformation("Call " + nameof(AddGroupDocumentAsync) + " API");
        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }

    [HttpGet("get-detail-config-column-by-type/{type}")]
    public async Task<IActionResult> GetListConfigColumnByTypeAsync(int type)
    {
        _logger.LogInformation("Call " + nameof(AddGroupDocumentAsync) + " API");
        GetConfigColumnByTypeQuery request = new();
        request.ViewType = type;
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpGet("get-gen-code")]
    public async Task<IActionResult> GetGenCodeAsync()
    {
        _logger.LogInformation("Call " + nameof(GetGenCodeAsync) + " API");
        GetGenGroupDocumentQuery request = new();
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpPost("add-config-column")]
    public async Task<IActionResult> AddConfigColumnAsync([FromBody] AddConfigColumnRequestCommand request)
    {
        _logger.LogInformation("Call " + nameof(AddConfigColumnAsync) + " API");
        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }

    [HttpPut("edit-group-document")]
    public async Task<IActionResult> EditGroupDocumentAsync([FromBody] EditGroupDocumentRequestCommand request)
    {
        _logger.LogInformation("Call " + nameof(EditGroupDocumentAsync) + " API");
        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }

    [HttpDelete("delete-group-document/{id}")]
    public async Task<IActionResult> DeleteGroupDocumentAsync(string id)
    {
        _logger.LogInformation("Call " + nameof(DeleteGroupDocumentAsync) + " API");
        DeleteGroupDocumentRequestCommand request = new();
        request.GroupDocId = id;
        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }

}
