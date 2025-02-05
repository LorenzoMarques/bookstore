using System.Net;

namespace bookstore.Exceptions
{
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public HttpException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public static HttpException NotFound(string message = "Recurso não encontrado") =>
            new HttpException(HttpStatusCode.NotFound, message);

        public static HttpException BadRequest(string message = "Requisição inválida") =>
            new HttpException(HttpStatusCode.BadRequest, message);

        public static HttpException Unauthorized(string message = "Acesso não autorizado") =>
            new HttpException(HttpStatusCode.Unauthorized, message);

        public static HttpException InternalServerError(string message = "Erro interno do servidor") =>
            new HttpException(HttpStatusCode.InternalServerError, message);
    }
}
