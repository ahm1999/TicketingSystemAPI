namespace TicketingSystem.Shared.Common
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public T? ResponsePayload { get; set; } 

        public string? Message  { get; set; }

        public ServiceResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public ServiceResponse(bool success,T responsePayload,string message):this(success,message)
        {
            ResponsePayload = responsePayload;
        }

    }
}
