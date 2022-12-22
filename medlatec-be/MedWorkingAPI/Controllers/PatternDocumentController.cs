using MediatR;
using MedWorking.Core.Application.ModulePatternDocument.Commands.ActionCommands;
using MedWorking.Core.Application.ModulePatternDocument.Queries;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Exceptions;
using MedWorking.Core.Common.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedWorkingAPI.Controllers;

[Route("api/pattern-document")]
[ApiController]
[Authorize]
public class PatternDocumentController : ControllerBase
{
    private readonly IMediator? _mediator;
    private readonly ILogger<PatternDocumentController> _logger;
    public PatternDocumentController(ILogger<PatternDocumentController> logger,IServiceProvider serviceProvider)
    {
        _logger = logger;
        _mediator = serviceProvider.GetService<IMediator>();
    }

    [HttpPost("get-pattern-document-by-paging")]
    public async Task<IActionResult> GetPagedListPatternDocumentAsync([FromBody] GetAllListPatternDocQuery request)
    {
        _logger.LogInformation("Call " + nameof(GetPagedListPatternDocumentAsync) + " API");
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpPost("add-pattern-document")]
    public async Task<IActionResult> AddPatternDocumentAsync([FromBody] AddPatternDocumentRequestCommand request)
    {
        _logger.LogInformation("Call " + nameof(AddPatternDocumentAsync) + " API");
        var userName = User!.Identity!.Name;
        request.CreateUser = userName;
        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }

    [HttpPut("edit-pattern-document")]
    public async Task<IActionResult> EditPatternDocumentAsync([FromBody] EditPatternDocumentRequestCommand request)
    {
        _logger.LogInformation("Call " + nameof(EditPatternDocumentAsync) + " API");
        var userName = User!.Identity!.Name;
        request.CreateUser = userName;
        request.UpdateUser = userName;
        request.UpdateDate = DateTime.UtcNow;
        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }

    [HttpDelete("delete-pattern-document/{id}")]
    public async Task<IActionResult> DeletePatternDocumentAsync(Guid id)
    {
        _logger.LogInformation("Call " + nameof(DeletePatternDocumentAsync) + " API");
        DeletePatternDocumentRequestCommand request = new DeletePatternDocumentRequestCommand();
        request.PatternDocId = id;
        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }

    [HttpGet("get-gen-code-pattern-doc")]
    public async Task<IActionResult> GetGenCodePatternDocAsync()
    {
        _logger.LogInformation("Call " + nameof(GetGenCodePatternDocAsync) + " API");
        GetGenCodePatternDocumentQuery request = new GetGenCodePatternDocumentQuery();

        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }
    [HttpGet("get-detail-patternDocument/{id}")]
    public async Task<IActionResult> GetdetailPatternDocumentAsync(Guid id)
    {
        _logger.LogInformation("Call " + nameof(GetdetailPatternDocumentAsync) + " API");
        GetPatternDocumentByIdQuery request = new GetPatternDocumentByIdQuery();
        request.Id = id;
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }
}