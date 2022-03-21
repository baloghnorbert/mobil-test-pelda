namespace Solution.Core.Models
{
    public class ServiceResponse
    {
        public bool HasError { get; set; } = false;
        public string ErrorMessage { get; set; } = "Success";

        public ServiceResponse()
        {
        }

        public ServiceResponse(bool hasError, string errorMessage)
        {
            HasError = hasError;
            ErrorMessage = errorMessage;
        }
    }

    public class ServiceResponse<T> : ServiceResponse where T : class, new()
    {
        public T Object { get; set; }

        public ServiceResponse()
        {
        }

        public ServiceResponse(T @object)
        {
            Object = @object;
        }

        public ServiceResponse(bool hasError, string errorMessage, T @object) : base(hasError, errorMessage)
        {
            Object = @object;
        }
    }
}
