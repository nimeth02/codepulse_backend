
namespace codePuls.Application.Common.ResponseModels
{
    public abstract class BaseResponse
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
