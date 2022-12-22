using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace MedWorking.Core.Application.ModuleDocument.Commands.ActionCommands
{
    public class DeleteDocumentRequestCommand : IRequest<DocumentCommandResponse>
    {
        public Guid Id { get; set;}
    }
}