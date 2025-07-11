namespace codePuls.Application.Common.ResponseModels
{
    public class ErrorResponse : BaseResponse
    {
        public string ErrorCode { get; set; }
        public Dictionary<string, string[]>? Errors { get; set; }
    }
}
