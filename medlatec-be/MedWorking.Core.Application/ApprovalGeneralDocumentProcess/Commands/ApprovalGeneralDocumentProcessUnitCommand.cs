﻿using MediatR;
using MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Models;

namespace MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Commands;

public class ApprovalGeneralDocumentProcessUnitCommand : ApprovalGeneralDocumentProcessUnitModel, IRequest<ApprovalGeneralDocumentProcessUnitCommandRespone>
{
}
