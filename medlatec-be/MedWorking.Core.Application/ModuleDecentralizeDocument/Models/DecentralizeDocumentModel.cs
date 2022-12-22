namespace MedWorking.Core.Application.ModuleDecentralizeDocument.Models
{
    public class DecentralizeDocumentModel
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public bool DecentralizeDocState { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateUser { get; set; }
        public long OfficeId { get; set; }

        public List<DecentralizeDocUserModel>? ListDecentralizeDocUsers {get; set;}
    }
    
}
