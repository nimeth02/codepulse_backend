namespace codePuls.Application.Common.ResponseModels
{
    public class SuccessResponse<T> : BaseResponse
    {
        public T Data { get; set; }
    }
}
