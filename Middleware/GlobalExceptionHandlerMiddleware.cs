using Microsoft.Data.SqlClient;

namespace SoftoneStudentManagmentSystem.Middleware
{
    public class GlobalExceptionHandlerMiddleware:IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> logger;

        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> _logger)
        {
            this.logger = _logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (SqlException ex1)
            {
                SaveLog(ex1);
                throw new Exception("Please check the server is runing or the internet is working and contact administrator ASAP");
            }
            catch (Exception ex)
            {
                SaveLog(ex);
                //handle exception
                throw new Exception("Error encountered in " + ex.Message, ex);
            }
          
        }
        private void SaveLog(Exception ex)
        {
            var traceId = Guid.NewGuid();
            this.logger.LogError($"Error occure while processing the request, TraceId : ${traceId}," +
                $" Message : ${ex.Message}, StackTrace: ${ex.StackTrace}");

        }
    }
}
