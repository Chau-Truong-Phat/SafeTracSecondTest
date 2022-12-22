using MediatR;
using MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Commands.ActionCommands;
using MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Queries;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedWorkingAPI.Controllers
{
    [Route("api/approval-general-document-process")]
    [ApiController]
    [Authorize]
    public class ApprovalGeneralDocProcessController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ApprovalGeneralDocProcessController> _logger;
        public ApprovalGeneralDocProcessController(ILogger<ApprovalGeneralDocProcessController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _mediator = serviceProvider.GetService<IMediator>()!;
        }

        [HttpPost("get-by-paging")]
        public async Task<IActionResult> GetPagedListAsync([FromBody] GetApprovalGeneralDocProcessPagingQuery request)
        {
            _logger.LogInformation("Call " + nameof(GetPagedListAsync) + " API");
            var result = await _mediator.Send(request);
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
            GetApprovalGeneralDocProcessByIdQuery request = new();
            request.Id = id;
            var result = await _mediator.Send(request);
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
            GetPatternDocByGroupDocGeneralIdQuery request = new();
            request.GroupDocumentId = id;
            var result = await _mediator.Send(request);
            if (result == null)
            {
                throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddApprovalGeneralDocumentProcessAsync([FromBody] AddApprovalGeneralDocProcessRequestCommand request)
        {
            _logger.LogInformation("Call " + nameof(AddApprovalGeneralDocumentProcessAsync) + " API");
            var userName = User!.Identity!.Name;
            request.CreateUser = userName;
            request.CreateDate = DateTime.UtcNow;
            var result = await _mediator.Send(request);
            if (!result.isSuccess)
            {
                throw new BadRequestException(result.Message!);
            }
            return Ok(result);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditApprovalGeneralDocumentProcessAsync([FromBody] EditApprovalGeneralDocProcessRequestCommand request)
        {
            _logger.LogInformation("Call " + nameof(EditApprovalGeneralDocumentProcessAsync) + " API");
            var userName = User!.Identity!.Name;
            request.UpdateUser = userName;
            request.UpdateDate = DateTime.UtcNow;
            var result = await _mediator.Send(request);
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
            DeleteApprovalGeneralDocProcessRequestCommand request = new DeleteApprovalGeneralDocProcessRequestCommand();
            request.Id = id;
            var result = await _mediator.Send(request);
            if (!result.isSuccess)
            {
                throw new BadRequestException(result.Message!);
            }
            return Ok(result);
        }
    }
}