using MediatR;
using MedWorking.Core.Application.ModuleConfigBrowsingStep.Queries;
using MedWorking.Core.Application.ModuleDocument.Commands.ActionCommands;
using MedWorking.Core.Application.ModuleDocument.Models;
using MedWorking.Core.Application.ModuleDocument.Queries;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedWorkingAPI.Controllers;
[Route("api/document")]
[ApiController]
[Authorize]

public class DocumentController : Controller
{
    private readonly IMediator _mediator;
    private readonly ILogger<ApprovalGeneralDocProcessController> _logger;
    public DocumentController(ILogger<ApprovalGeneralDocProcessController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _mediator = serviceProvider.GetService<IMediator>()!;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddDocumentAsync([FromBody] AddDocumentRequestCommand request)
    {
        _logger.LogInformation("Call " + nameof(AddDocumentAsync) + " API");
        var userName = User!.Identity!.Name;
        request.CreateUser = userName;
        request.CreateDate = DateTime.UtcNow;
        var result = await _mediator.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        
        return Ok();
    }

    [HttpPost("add-advisory-office")]
    public async Task<IActionResult> AddAdvisoryOfficeAsync([FromBody] AddAdvisoryStaffCommand request)
    {
        _logger.LogInformation("Call " + nameof(AddAdvisoryOfficeAsync) + " API");
        var result = await _mediator.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }

        return Ok(result);
    }
    [HttpGet("get-gen-document-code")]
    public async Task<IActionResult> GetGenDocumentCodeAsync()
    {
        _logger.LogInformation("Call " + nameof(GetGenDocumentCodeAsync) + " API");
        GetDocumentCodeQuery request = new();
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpGet("get-all-document-reference")]
    public async Task<IActionResult> GetAllDocumentAsync()
    {
        _logger.LogInformation("Call " + nameof(GetAllDocumentAsync) + " API");
        GetDocumentReferenceQuery request = new();
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpGet("get-advisory-office-by-id")]
    public async Task<IActionResult> GetImplementOfficeByIdAsync(Guid patternDocId )
    {
        _logger.LogInformation("Call " + nameof(GetImplementOfficeByIdAsync) + " API");
        GetAdvisoryOfficeByIdQuery request = new();
        request.PatternDocId = patternDocId;
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_AccountNotFoundException);
        }
        return Ok(result);
    }

    [HttpPut("browse-doc")]
    public async Task<IActionResult> BrowseDocumentAsync([FromBody]BrowseDocumentRequestCommand request)
    {
        _logger.LogInformation("Call " + nameof(BrowseDocumentAsync) + " API");
        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }
    [HttpPost("edit")]
    public async Task<IActionResult> EditDocumentAsync([FromBody] EditDocumentRequestCommand request)
    {
        _logger.LogInformation("Call " + nameof(EditDocumentAsync) + " API");
        var userName = User!.Identity!.Name;
        request.UpdateUser = userName;
        request.UpdateDate = DateTime.UtcNow;
        var result = await _mediator.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }

        return Ok();
    }

    [HttpGet("get-document-detail-by-id/{id}")]
    public async Task<IActionResult> GetDocumentDetailAsync(Guid id)
    {
        _logger.LogInformation("Call " + nameof(GetDocumentDetailAsync) + " API");
        GetDocumentByIdQuery request = new();
        request.Id = id;
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
        }
        return Ok(result);
    }

    [HttpGet("get-detail-document")]
    public async Task<IActionResult> DetailDocumentProcessAsync()
    {
        try
        {
            var data = new DetailDocumentModel()
            {
                DocumentCode = "VB15112022 - 1",
                GroupDocId = Guid.Parse("1e2d5ca2-f2e7-416f-af4c-5487b6e56811"),
                PatternDocId = Guid.Parse("196cccc4-a4ee-4b65-82e7-1a8494e35a1a"),
                DocName = "Đơn xin nghỉ phép ngày 01/12/2022 - 03/12/2022",
                Priority = 0,
                ExpirationDate = DateTime.Now,
                ListAdvisoryUnit = new List<long>() { 12556, 12533, 12119 },
                ListImplementUnit = new List<long>() { 12159, 12077, 12519 },
                ListRelatedDocument = new List<string>() { "VB15112022 - 2", "VB15112022 - 3", "VB15112022 - 5" },
                Explaination = "viết diễn giải",
                Notes = "viết note",
                Description = "nội dung văn bản",
                MsgComment = "ý kiến bổ sung",
                historyDocument = new List<DocHis>()
                {
                    new DocHis()
                    {
                        HisUpdateTime = DateTime.Now,
                        HisUpdateUser = "Admin",
                        Action = "thêm mới văn bản"
                    },
                    new DocHis()
                    {
                        HisUpdateTime = DateTime.Now,
                        HisUpdateUser = "Admin",
                        Action = "chỉnh sửa"
                    },
                }
            };
            return Ok(data);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return Ok();
    }

    [HttpGet("document-process")]
    public async Task<IActionResult> DocumentProcessAsync()
    {
        try
        {
            var data = new List<DocumentProcessModel>()
            {
                new DocumentProcessModel()
                {
                    StepName = "Bước 1",
                    BrowsingProcess = new BrowsingProcess()
                    {
                        ImplementOffices = new List<ImplementOffice>()
                        {
                            new ImplementOffice()
                            {
                                OfficeName = "Ban CNTT",
                                ImplementUsers = new List<ImplementUser>()
                                {
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn A",
                                        StatusApproval = "Chưa duyệt"
                                    },
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn B",
                                        StatusApproval = "Chưa duyệt"
                                    },
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn C",
                                        StatusApproval = "Chưa duyệt"
                                    }
                                }
                            },
                            new ImplementOffice()
                            {
                                OfficeName = "Ban Pháp chế",
                                ImplementUsers = new List<ImplementUser>()
                                {
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn 1A",
                                        StatusApproval = "Chưa duyệt"
                                    },
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn 2B",
                                        StatusApproval = "Chưa duyệt"
                                    },
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn C2",
                                        StatusApproval = "Chưa duyệt"
                                    }
                                }
                            }
                        }
                    }
                },
                new DocumentProcessModel()
                {
                    StepName = "Bước 2"
                    ,
                    BrowsingProcess = new BrowsingProcess()
                    {
                        ImplementOffices = new List<ImplementOffice>()
                        {
                            new ImplementOffice()
                            {
                                OfficeName = "Ban CNTT",
                                ImplementUsers = new List<ImplementUser>()
                                {
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn A",
                                        StatusApproval = "Chưa duyệt"
                                    },
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn B",
                                        StatusApproval = "Chưa duyệt"
                                    },
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn C",
                                        StatusApproval = "Chưa duyệt"
                                    }
                                }
                            },
                            new ImplementOffice()
                            {
                                OfficeName = "Ban Pháp chế",
                                ImplementUsers = new List<ImplementUser>()
                                {
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn 1A",
                                        StatusApproval = "Chưa duyệt"
                                    },
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn 2B",
                                        StatusApproval = "Chưa duyệt"
                                    },
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn C2",
                                        StatusApproval = "Chưa duyệt"
                                    }
                                }
                            }
                        }
                    }
                },
                new DocumentProcessModel()
                {
                    StepName = "Bước 3"
                    ,
                    BrowsingProcess = new BrowsingProcess()
                    {
                        ImplementOffices = new List<ImplementOffice>()
                        {
                            new ImplementOffice()
                            {
                                OfficeName = "Ban CNTT",
                                ImplementUsers = new List<ImplementUser>()
                                {
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn 22A",
                                        StatusApproval = "Chưa duyệt"
                                    },
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn 22B",
                                        StatusApproval = "Chưa duyệt"
                                    },
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn 22C",
                                        StatusApproval = "Chưa duyệt"
                                    }
                                }
                            },
                            new ImplementOffice()
                            {
                                OfficeName = "Ban Pháp chế",
                                ImplementUsers = new List<ImplementUser>()
                                {
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn 122A",
                                        StatusApproval = "Chưa duyệt"
                                    },
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn 222B",
                                        StatusApproval = "Chưa duyệt"
                                    },
                                    new ImplementUser()
                                    {
                                        UserName = "Nguyễn văn 22C2",
                                        StatusApproval = "Chưa duyệt"
                                    }
                                }
                            }
                        }
                    }
                }
            };
            return Ok(data);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return Ok();
    }

    [HttpGet("get-all-document")]
    public async Task<IActionResult> GetAllDocumentProcessAsync()
    {
        var listData = new List<ListDocumentModel>()
        {
            new ListDocumentModel()
            {
                DocumentCode = "Med Tây Hồ",
                GroupDocumentName = "Đơn xin",
                PatternDocumentName = "Đơn xin nghỉ phép",
                DocumentName = "Đơn xin nghỉ phép 15/11 - 16/11",
                PriorityName = "Bình thường",
                Status = 1,
                CreateDate = DateTime.Now,
                CreateUser = "Đào Thị Linh Hương",
                ProposalOfficeName = "Ban CNTT",
                Notes = "văn bản nháp"
            },
            new ListDocumentModel()
            {
                DocumentCode = "Med Tây Hồ",
                GroupDocumentName = "Đơn xin",
                PatternDocumentName = "Đơn xin cấp tài khoản",
                DocumentName = "Đơn xin cấp tài khoản HRMED",
                PriorityName = "Bình thường",
                Status = 2,
                CreateDate = DateTime.Now,
                CreateUser = "Đào Thị Linh Hương",
                ProposalOfficeName = "Ban CNTT",
                Notes = "văn bản trình duyệt"            
            },
            new ListDocumentModel()
            {
                DocumentCode = "Med Tây Hồ",
                GroupDocumentName = "Đơn đề xuất",
                PatternDocumentName = "Đề xuất tuyển dụng",
                DocumentName = "Đơn đề xuất tuyển tụng quý 1 năm 2023",
                PriorityName = "Bình thường",
                Status = 3,
                CreateDate = DateTime.Now,
                CreateUser = "Lê Thị Vân Anh",
                ProposalOfficeName = "Ban Pháp Chế",
                Notes = "văn bản đã xử lý"            
            }
        };
        
        return Ok(listData);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteDocumentAsync(Guid id)
    {
        _logger.LogInformation("Call " + nameof(DeleteDocumentAsync) + " API");
        DeleteDocumentRequestCommand request = new DeleteDocumentRequestCommand();
        request.Id = id;
        var result = await _mediator.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        return Ok(result);
    }
}