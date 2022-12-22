using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModuleRole.Models;

public class ListDecentralizeModel
{
    public long Id { get; set; }
    public long Parent { get; set; }
    public string Name { get; set; }
    public List<Decentralize>? ListFunctionName { get; set; } 
}
