namespace BLL.Entities
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; }
        public int StatusCode { get; set; } = 0;
    }
}
