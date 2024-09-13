namespace OrderManagement.Application
{
    public class ResponseModel
    {
        public bool IsSuccess {  get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Data {  get; set; }
        public object? Errors {  get; set; }
    }
}
