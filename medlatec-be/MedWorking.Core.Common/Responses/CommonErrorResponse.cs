namespace MedWorking.Core.Common.Responses
{
    public class CommonErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public string Draw { get; set; } 
        public CommonErrorResponse(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }
        public CommonErrorResponse(int code, string message, string draw)
        {
            this.Code= code;
            this.Draw = draw;
            this.Message= message;
        }
    }

}