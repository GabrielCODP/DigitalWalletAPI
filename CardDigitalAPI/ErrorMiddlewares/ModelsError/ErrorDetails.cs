using System.Text.Json;

namespace CardDigitalAPI.ErrorMiddlewares.ModelsError
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        //Rastreio da pilha
        public string? Trace { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
