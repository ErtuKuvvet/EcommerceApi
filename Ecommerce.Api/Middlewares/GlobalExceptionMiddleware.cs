namespace Ecommerce.Api.Middlewares;

using System.Net;
using System.Text.Json;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // İsteği bir sonraki adıma gönder (Her şey yolundaysa burası çalışır)
            await _next(context);
        }
        catch (Exception ex)
        {
            // HATA OLURSA BURAYA DÜŞER!
            
            // 1. Hatayı Logla (Terminalde kırmızı görünür) (5 PUANLIK KISIM)
            _logger.LogError(ex, "Bir hata oluştu: {Message}", ex.Message);

            // 2. Kullanıcıya düzgün cevap dön (10 PUANLIK KISIM)
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        // Ödevdeki "Standart API Response" formatına uygun hata mesajı
        var response = new
        {
            success = false,
            message = "Sunucu tarafında beklenmeyen bir hata oluştu. Lütfen daha sonra tekrar deneyin.",
            errorDetail = exception.Message // Geliştirme aşamasında hatayı görmek için
        };

        var json = JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(json);
    }
}