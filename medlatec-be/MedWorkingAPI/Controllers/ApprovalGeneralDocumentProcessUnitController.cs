using MediatR;
using MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Commands.ActionCommand;
using MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Queries;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedWorkingAPI.Controllers;

[Route("api/approval-general-document-process-unit")]
[ApiController]
[Authorize]
public class ApprovalGeneralDocumentProcessUnitController : ControllerBase
{
    private readonly IMediator? _mediator;
    private readonly ILogger<ApprovalGeneralDocumentProcessUnitController> _logger;
    public ApprovalGeneralDocumentProcessUnitController(ILogger<ApprovalGeneralDocumentProcessUnitController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _mediator = serviceProvider.GetService<IMediator>();
    }
    [HttpPost("get-by-paging")]
    public async Task<IActionResult> GetPagedListAsync([FromBody] GetApprovalGeneralDocumentProcessUnitPagingQuery request)
    {
        _logger.LogInformation("Call " + nameof(GetPagedListAsync) + " API");
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpGet("get-detail-by-id/{id}")]
    public async Task<IActionResult> GetDetailByIdAsync(Guid id)
    {
        _logger.LogInformation("Call " + nameof(GetDetailByIdAsync) + " API");
        GetApprovalGeneralDocumentProcessUnitByIdQuery request = new();
        request.Id = id;
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }
    [HttpPost("get-list-detail-by-id")]
    public async Task<IActionResult> GetListDetailByIdAsync([FromBody] GetPatternDocumentByListGroupDocumentIdQuery request)
    {
        _logger.LogInformation("Call " + nameof(GetListDetailByIdAsync) + " API");
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }
    [HttpGet("get-pattern-document-by-id/{id}")]
    public async Task<IActionResult> GetPatternDocumentByGroupDocument(Guid id)
    {
        _logger.LogInformation("Call " + nameof(GetPatternDocumentByGroupDocument) + " API");
        GetPatternDocumentByGroupDocumentIdQuery request = new();
        request.GroupDocumentId = id;
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }
    [HttpPost("add")]
    public async Task<IActionResult> AddApprovalGeneralDocumentProcessUnitAsync([FromBody] AddApprovalGeneralDocumentProcessUnitcommand request)
    {
        _logger.LogInformation("Call " + nameof(AddApprovalGeneralDocumentProcessUnitAsync) + " API");
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

    [HttpPut("edit")]
    public async Task<IActionResult> EditApprovalGeneralDocumentProcessUnitAsync([FromBody] EditApprovalGeneralDocumentProcessUnit request)
    {
        _logger.LogInformation("Call " + nameof(EditApprovalGeneralDocumentProcessUnitAsync) + " API");
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

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteApprovalGeneralDocumentProcessUnitAsync(Guid id)
    {
        _logger.LogInformation("Call " + nameof(DeleteApprovalGeneralDocumentProcessUnitAsync) + " API");
        DeleteApprovalGeneralDocumentProcessUnit request = new();
        request.Id = id;
        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }
}
