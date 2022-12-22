using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModulUserRole.Models;

public class DetailDecentralizeModel
{
    public long Id { get; set; }
    public long Parent { get; set; }
    public string Name { get; set; } 
    public List<Decentralize>? ListFunctionName { get; set; }

}
