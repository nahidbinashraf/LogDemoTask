using System.Text;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        // Log the request information
        await LogRequestAsync(context.Request);

        await _next(context);
    }

    private async Task LogRequestAsync(HttpRequest request)
    {
        string projectRoot = Directory.GetCurrentDirectory();
        string logFilePath = Path.Combine(projectRoot, "LogFile.txt");

        await using (var logFileStream = new StreamWriter(logFilePath, append: true))
        {

            string logMessage = $"Request: {request.Method} {request.Path} {request.QueryString}\n" +
                $"Request Headers: {{string.Join(\", \", request.Headers)\n";            

            await logFileStream.WriteLineAsync(logMessage);

            if ((request.Method == HttpMethods.Post || request.Method == HttpMethods.Put || request.Method == HttpMethods.Delete) && request.ContentLength > 0)
            {
                request.EnableBuffering();
                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer, 0, buffer.Length);
                var requestBody = Encoding.UTF8.GetString(buffer);

                request.Body.Position = 0;
                await logFileStream.WriteLineAsync($"Request Body: {requestBody}\n");
            }
        }
    }
}
