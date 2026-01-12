namespace Ecommerce.Service;

// <T> demek: "İçine her türlü veriyi (Product, User, List) alabilir" demektir.
public class ServiceResponse<T>
{
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    // Başarılı cevaplar için kısa yol
    public static ServiceResponse<T> SuccessResponse(T data, string message = "İşlem başarılı")
    {
        return new ServiceResponse<T> { Success = true, Data = data, Message = message };
    }

    // Hatalı cevaplar için kısa yol
    public static ServiceResponse<T> ErrorResponse(string message)
    {
        return new ServiceResponse<T> { Success = false, Message = message };
    }
}