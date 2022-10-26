namespace Biblioteca.Application.Results
{
    public class RequestResult
    {
        public int StatusCode { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }

        public RequestResult Ok(object data)
        {
            StatusCode = 200;
            Message = "Requisição realizada com sucesso";
            Data = data;
            return this;
        }

        public RequestResult BadRequest(string detail, object data = null)
        {
            StatusCode = 400;
            Message = $"Falha ao realizar a requisição. Mais detalhes: {detail}";
            Data = data;
            return this;
        }
        public RequestResult NoContext()
        {
            StatusCode = 204;
            Message = $"Sem conteúdo";
            return this;
        }
        public RequestResult NotFound()
        {
            StatusCode = 404;
            Message = $"Não encontrado.";
            return this;
        }
    }
}