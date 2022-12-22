using MediatR;
using MedWorking.Core.Application.ModuleDecentralizeDocument.Commands.ActionCommands;
using MedWorking.Core.Application.ModuleDecentralizeDocument.Queries;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Exceptions;
using MedWorking.Core.Common.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedWorkingAPI.Controllers;

[Route("api/decentralize-document")]
[ApiController]
[Authorize]
public class DecentralizeDocumentController : ControllerBase
{
    private readonly IMediator? _mediator;
    private readonly ILogger<DecentralizeDocumentController> _logger;
    public DecentralizeDocumentController(ILogger<DecentralizeDocumentController> logger ,IServiceProvider serviceProvider)
    {
        _logger = logger;
        _mediator = serviceProvider.GetService<IMediator>();
    }

    [HttpPost("get-decentralize-document-by-paging")]
    public async Task<IActionResult> GetPagedListDecentralizeDocumentAsync([FromBody] GetAllListDecentralizeDocQuery request)
    {
        _logger.LogInformation("Call " + nameof(GetPagedListDecentralizeDocumentAsync) + " API");
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpPost("add-decentralize-document")]
    public async Task<IActionResult> AddDecentralizeDocumentAsync([FromBody] AddDecentralizeDocumentRequestCommand request)
    {
        _logger.LogInformation("Call " + nameof(AddDecentralizeDocumentAsync) + " API");
        var userName = User!.Identity!.Name;
        request.CreateUser = userName;

        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }

    [HttpPut("edit-decentralize-document")]
    public async Task<IActionResult> EditDecentralizeDocumentAsync([FromBody] EditDecentralizeDocumentRequestCommand request)
    {
        _logger.LogInformation("Call " + nameof(EditDecentralizeDocumentAsync) + " API");
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

    [HttpDelete("delete-decentralize-document/{id}")]
    public async Task<IActionResult> DeleteDecentralizeDocumentAsync(Guid id)
    {
        _logger.LogInformation("Call " + nameof(DeleteDecentralizeDocumentAsync) + " API");
        DeleteDecentralizeDocumentRequestCommand request = new();
        request.Id = id;
        var result = await _mediator!.Send(request);

        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }

    [HttpGet("get-detail-decentralize-document/{id}")]
    public async Task<IActionResult> GetdetailDecentralizeDocumentAsync(Guid id)
    {
        _logger.LogInformation("Call " + nameof(GetdetailDecentralizeDocumentAsync) + " API");
        GetDecentralizeDocumentByIdQuery request = new();
        request.DecentralizeDocId = id;
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }
    [HttpGet("get-user-by-officeid/{id}")]
    public async Task<IActionResult> GetDetailUserByOffice(long id)
    {
        _logger.LogInformation("Call " + nameof(GetDetailUserByOffice) + " API");
        GetUserByOfficeIdQuery request = new();
        request.OfficeId = id;
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }
}