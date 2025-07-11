namespace codePuls.Application.Exceptions
{
    public class RepositoryException:Exception
    {
        public RepositoryException(string message, Exception innerException = null) : base(message, innerException) { }

        public bool IsTransient { get; init; }
        public string Operation { get; init; }

        public string ErrorType { get; init; }
        public string ErrorCode { get; init; }
    }
}
