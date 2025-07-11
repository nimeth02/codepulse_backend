using codePuls.Application.Common.ResponseModels;
using codePuls.Application.Exceptions;
using codePuls.Application.Exeptions;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace codePuls.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception caught in middleware.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            int statusCode;
            var errorResponse = new ErrorResponse
            {
                Success = false
            };

            switch (exception)
            {
               
                case ValidationException validationEx:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Message = "Validation failed";
                    errorResponse.ErrorCode = "VALIDATION_ERROR";
                    errorResponse.Errors =(Dictionary<string, string[]> ?)validationEx.Errors; 
                    break;                 
            
                case NotFoundException notFoundEx:
                    statusCode = (int)HttpStatusCode.NotFound;
                    errorResponse.Message = notFoundEx.Message;
                    errorResponse.ErrorCode = "NOT_FOUND";
                    break;

                case RepositoryException repoEx:
                    statusCode = repoEx.IsTransient ? 503 : 500;
                    errorResponse.Message = "A database error occurred. Please try again later.";
                    errorResponse.ErrorCode = "REPO_ERROR"; 
                    break;

                case UnauthorizedAccessException unauthEx:
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    errorResponse.Message = unauthEx.Message;
                    errorResponse.ErrorCode = "UNAUTHORIZED";
                    break;

                case ApplicationException appEx:
                    statusCode = 400;
                    errorResponse.Message = appEx.Message;
                    errorResponse.ErrorCode = "APP_ERROR";
                    break;

                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;                
                    errorResponse.Message = "An unexpected error occurred.";
                    errorResponse.ErrorCode = "INTERNAL_SERVER_ERROR";
                    break;
            }
            errorResponse.StatusCode = statusCode;
            response.StatusCode = statusCode;
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return response.WriteAsync(JsonSerializer.Serialize(errorResponse, options));
        }


    }
}
